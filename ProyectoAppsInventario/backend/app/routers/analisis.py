import httpx
from fastapi import APIRouter, Depends, HTTPException, UploadFile
from sqlalchemy import select
from sqlalchemy.orm import Session, selectinload

from app.auth import Usuario, get_current_user
from app.db import get_db
from app.models import Analisis, Hallazgo
from app.permisos import obtener_aplicacion
from app.schemas import AnalisisOut
from app.vulnerabilidades.osv import consultar_osv
from app.vulnerabilidades.parsers import parsear

router = APIRouter(prefix="/api/aplicaciones", tags=["analisis"])

MAX_BYTES = 10 * 1024 * 1024
ORDEN = {"CRITICAL": 0, "HIGH": 1, "MODERATE": 2, "MEDIUM": 2, "LOW": 3}


@router.post("/{app_id}/analisis", response_model=AnalisisOut, status_code=201)
async def analizar(app_id: int, fichero: UploadFile,
                   db: Session = Depends(get_db), u: Usuario = Depends(get_current_user)):
    # Ver la aplicación es suficiente: Seguridad también puede analizar
    obtener_aplicacion(db, app_id, u)

    contenido = await fichero.read(MAX_BYTES + 1)
    if len(contenido) > MAX_BYTES:
        raise HTTPException(413, "Fichero demasiado grande (máx. 10 MB)")
    try:
        paquetes = parsear(fichero.filename, contenido)
    except ValueError as e:
        raise HTTPException(400, str(e))

    try:
        hallazgos = await consultar_osv(paquetes)
    except httpx.HTTPError:
        raise HTTPException(502, "No se ha podido consultar OSV.dev. Inténtalo más tarde.")

    hallazgos.sort(key=lambda h: (ORDEN.get(h.severidad, 9), h.paquete.nombre, h.vuln_id))
    analisis = Analisis(
        aplicacion_id=app_id,
        fichero=(fichero.filename or "desconocido")[:100],
        total_paquetes=len(paquetes),
        total_vulnerables=len({h.paquete for h in hallazgos}),
        realizado_por=u.nombre or u.email,
        hallazgos=[Hallazgo(
            paquete=h.paquete.nombre[:200], version=h.paquete.version[:100],
            ecosistema=h.paquete.ecosistema, vuln_id=h.vuln_id[:100], alias=h.alias,
            severidad=h.severidad[:20], resumen=h.resumen, version_corregida=h.version_corregida,
            aproximado=h.paquete.aproximado,
        ) for h in hallazgos],
    )
    db.add(analisis)
    db.commit()
    db.refresh(analisis)
    return analisis


@router.get("/{app_id}/analisis", response_model=list[AnalisisOut])
def historial(app_id: int, db: Session = Depends(get_db), u: Usuario = Depends(get_current_user)):
    obtener_aplicacion(db, app_id, u)
    stmt = (select(Analisis).options(selectinload(Analisis.hallazgos))
            .where(Analisis.aplicacion_id == app_id)
            .order_by(Analisis.realizado_en.desc(), Analisis.id.desc()))
    return list(db.scalars(stmt))
