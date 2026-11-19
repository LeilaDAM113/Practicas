from fastapi import APIRouter, Depends, Query
from packaging.version import InvalidVersion, Version
from sqlalchemy import or_, select
from sqlalchemy.orm import Session
from app.auth import Usuario, get_current_user
from app.db import get_db
from app.models import Aplicacion, Entorno, Exposicion, Proyecto, TipoTecnologia
from app.permisos import filtrar_visibles
from app.schemas import AplicacionOut, ResultadoBusqueda

router= APIRouter(prefix="/api/buscar", tags=["buscar"])


"""La versión es anterior al limite? Si no se puede comparar, la mostramos para revisarla"""
def _menor_que(version: str | None, limite: str) -> bool:
    if version is None:
        return True
    try:
        return Version(version) < Version(limite)
    except InvalidVersion:
        return True 

@router.get("", response_model=list[ResultadoBusqueda])
def buscar(
    q: str | None = Query(None, description="Framework, lenguaje, gestor, aplicacion o proyecto"),
    version_menor_que: str | None = Query(None, description="Ej: 0.115.0"),
    entorno: Entorno | None = None,
    exposicion: Exposicion | None = None,
    tipo_tecnologia: TipoTecnologia | None = None,
    db: Session = Depends(get_db),
    u: Usuario = Depends(get_current_user),
):
    consulta=filtrar_visibles(select(Aplicacion, Proyecto).join(Proyecto), u)
    if q:
        like = f"%{q.strip()}%"
        consulta = consulta.where(or_(
            Aplicacion.framework_nombre.ilike(like),
            Aplicacion.lenguaje.ilike(like),
            Aplicacion.gestor_paquetes.ilike(like),
            Aplicacion.nombre.ilike(like),
            Proyecto.nombre.ilike(like),
            Proyecto.cliente.ilike(like),
        ))
    if entorno:
        consulta = consulta.where(Aplicacion.entorno == entorno)
    if exposicion:
        consulta = consulta.where(Aplicacion.exposicion == exposicion)
    if tipo_tecnologia:
        consulta = consulta.where(Aplicacion.tipo_tecnologia == tipo_tecnologia)

    resultados = []
    for aplicacion, proyecto in db.execute(consulta.order_by(Proyecto.nombre, Aplicacion.nombre)):
        if version_menor_que and not _menor_que(aplicacion.framework_version, version_menor_que.strip()):
            continue
        resultados.append(ResultadoBusqueda(
            **AplicacionOut.model_validate(aplicacion).model_dump(),
            proyecto_nombre=proyecto.nombre, cliente=proyecto.cliente, responsable=proyecto.responsable,
        ))
    return resultados    