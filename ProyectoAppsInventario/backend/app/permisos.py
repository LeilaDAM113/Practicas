from fastapi import HTTPException
from sqlalchemy import Select, select
from sqlalchemy.orm import Session, selectinload
from app.auth import Usuario
from app.models import Aplicacion, Proyecto


def filtrar_visibles(consulta: Select, usuario: Usuario) -> Select:
    """Seguridad ve todo (admin), el PM solo lo que ha creado él."""
    if usuario.es_seguridad:
        return consulta
    return consulta.where(Proyecto.creado_por_oid == usuario.oid)


def puede_editar(proyecto: Proyecto, usuario: Usuario) -> bool:
    """Solo el PM que lo creó puede editarlo."""
    return usuario.es_pm and proyecto.creado_por_oid == usuario.oid


def obtener_proyecto(db: Session, proyecto_id: int, usuario: Usuario, editar: bool = False) -> Proyecto:
    """Busca un proyecto comprobando los permisos; si no puede verlo, lanza error 404."""
    consulta = (select(Proyecto).options(selectinload(Proyecto.aplicaciones)).where(Proyecto.id == proyecto_id)
    )

    proyecto = db.scalar(filtrar_visibles(consulta, usuario))
    if proyecto is None:
        raise HTTPException(status_code=404, detail="Proyecto no encontrado")
    if editar and not puede_editar(proyecto, usuario):
        raise HTTPException(status_code=403, detail="No puedes modificar el proyecto")
    return proyecto

def obtener_aplicacion(db:Session, app_id:int, usuario:Usuario, editar:bool=False) -> Aplicacion:
    """Busca una aplicación y comprueba los permisos sobre su proyecto"""
    aplicacion=db.get(Aplicacion, app_id)
    if aplicacion is None:
        raise HTTPException(status_code=404, detail="Aplicación no encontrada")
    obtener_proyecto(db,aplicacion.proyecto_id,usuario,editar=editar)
    return aplicacion
