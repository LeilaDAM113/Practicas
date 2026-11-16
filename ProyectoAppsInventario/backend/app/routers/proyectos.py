from fastapi import APIRouter, Depends
from sqlalchemy import select
from sqlalchemy.orm import Session
from app.auth import Usuario, get_current_user, requiere_pm
from app.db import get_db
from app.models import Proyecto
from app.permisos import filtrar_visibles, puede_editar, obtener_proyecto
from app.schemas import ProyectoIn, ProyectoOut

router= APIRouter(prefix="/api/proyectos", tags=["proyectos"])

def _a_salida(proyecto:Proyecto, usuario: Usuario)-> ProyectoOut:
    """Convierte un Proyecto de la bd en lo que devuelve la API"""
    salida=ProyectoOut.model_validate(proyecto)
    salida.puede_editar=puede_editar(proyecto,usuario)
    return salida

@router.get("", response_model=list[ProyectoOut])
def listar(db:Session=Depends(get_db), usuario: Usuario=Depends(get_current_user)):
    consulta=filtrar_visibles(select(Proyecto).order_by(Proyecto.nombre),usuario)
    return [_a_salida(p,usuario) for p in db.scalars(consulta)]

@router.post("", response_model=ProyectoOut, status_code=201)
def crear(datos:ProyectoIn, db:Session=Depends(get_db), usuario: Usuario=Depends(requiere_pm)):
    proyecto=Proyecto(
        **datos.model_dump(),
        creado_por_oid=usuario.oid,
        creado_por_nombre=usuario.nombre,
    )
    db.add(proyecto)
    db.commit()
    db.refresh(proyecto)
    return _a_salida(proyecto,usuario)

@router.get("/{proyecto_id}", response_model=ProyectoOut)
def detalle(proyecto_id: int,  db: Session = Depends(get_db), usuario: Usuario = Depends(get_current_user)):
    proyecto = obtener_proyecto(db, proyecto_id, usuario)
    return _a_salida(proyecto, usuario)

@router.put("/{proyecto_id}",response_model=ProyectoOut)
def actualizar(proyecto_id: int, datos: ProyectoIn, db: Session = Depends(get_db), usuario: Usuario = Depends(get_current_user)):
    proyecto = obtener_proyecto (db,proyecto_id, usuario, editar=True)
    for campo, valor in datos.model_dump().items():
        setattr(proyecto,campo,valor)
    db.commit()
    return _a_salida(proyecto,usuario)

@router.delete("/{proyecto_id}", status_code=204)
def borrar(proyecto_id: int, db: Session = Depends(get_db), usuario: Usuario = Depends(get_current_user)):
    proyecto=obtener_proyecto(db,proyecto_id, usuario, editar=True)
    db.delete(proyecto)
    db.commit()