from fastapi import APIRouter, Depends, HTTPException
from sqlalchemy.exc import IntegrityError
from sqlalchemy.orm import Session
from app.auth import Usuario, get_current_user
from app.db import get_db
from app.models import Aplicacion
from app.permisos import obtener_aplicacion, obtener_proyecto
from app.schemas import AplicacionIn, AplicacionOut

router = APIRouter(prefix="/api", tags=["aplicaciones"])

def _guardar(db:Session):
    """Guarda los cambios. Si la aplicación ya existe en ese entorno, error 409"""
    try:
        db.commit()
    except IntegrityError:
        db.rollback()
        raise HTTPException(409,"Ya existe una aplicación con ese nombre en ese entorno")

@router.post("/proyectos/{proyecto_id}/aplicaciones", response_model=AplicacionOut,status_code=201)
def crear(proyecto_id:int, datos: AplicacionIn, db: Session=Depends(get_db), usuario: Usuario=Depends(get_current_user)):
    obtener_proyecto(db,proyecto_id,usuario,editar=True)
    aplicacion=Aplicacion(**datos.model_dump(),proyecto_id=proyecto_id)
    db.add(aplicacion)
    _guardar(db)
    db.refresh(aplicacion)
    return aplicacion

@router.put("/aplicaciones/{app_id}", response_model=AplicacionOut)
def actualizar(app_id:int, datos:AplicacionIn, db: Session=Depends(get_db), usuario: Usuario=Depends(get_current_user)):
    aplicacion=obtener_aplicacion(db,app_id,usuario,editar=True)
    for campo, valor in datos.model_dump().items():
        setattr(aplicacion,campo,valor)
    _guardar(db)
    db.refresh(aplicacion)
    return aplicacion

@router.delete("/aplicaciones/{app_id}" , status_code=204)
def borrar(app_id:int , db: Session=Depends(get_db), usuario: Usuario=Depends(get_current_user)): 
    aplicacion=obtener_aplicacion(db,app_id,usuario, editar=True)
    db.delete(aplicacion)
    db.commit()           