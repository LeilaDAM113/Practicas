"""Cliente de OSV.dev (base de datos de vulnerabilidades de código abierto, gratuita y sin clave)."""
import asyncio
from dataclasses import dataclass

import httpx

from app.config import settings
from app.vulnerabilidades.parsers import Paquete

LOTE = 1000  # máximo de consultas por petición en /querybatch


@dataclass
class HallazgoDTO:
    paquete: Paquete
    vuln_id: str
    alias: str | None
    severidad: str
    resumen: str
    version_corregida: str | None


def severidad(vuln: dict) -> str:
    sev = (vuln.get("database_specific") or {}).get("severity")
    if sev:
        return str(sev).upper()          # GitHub Advisories: LOW / MODERATE / HIGH / CRITICAL
    for afectado in vuln.get("affected", []):
        sev = (afectado.get("ecosystem_specific") or {}).get("severity")
        if sev:
            return str(sev).upper()
    return "DESCONOCIDA"


def version_corregida(vuln: dict, paquete: Paquete) -> str | None:
    corregidas = []
    for afectado in vuln.get("affected", []):
        if (afectado.get("package") or {}).get("name") != paquete.nombre:
            continue
        for rango in afectado.get("ranges", []):
            corregidas += [e["fixed"] for e in rango.get("events", []) if "fixed" in e]
    return ", ".join(dict.fromkeys(corregidas)) or None


async def consultar_osv(paquetes: list[Paquete]) -> list[HallazgoDTO]:
    ids_por_paquete: dict[Paquete, list[str]] = {}
    url = settings.osv_url

    async with httpx.AsyncClient(timeout=60) as cliente:
        # 1) Qué vulnerabilidades afectan a cada paquete/versión
        for i in range(0, len(paquetes), LOTE):
            lote = paquetes[i:i + LOTE]
            r = await cliente.post(f"{url}/querybatch", json={"queries": [
                {"package": {"name": p.nombre, "ecosystem": p.ecosistema}, "version": p.version}
                for p in lote
            ]})
            r.raise_for_status()
            for p, res in zip(lote, r.json().get("results", [])):
                ids = [v["id"] for v in (res or {}).get("vulns", [])]
                if ids:
                    ids_por_paquete[p] = ids

        # 2) Detalle de cada vulnerabilidad (querybatch solo devuelve los IDs)
        detalles: dict[str, dict] = {}
        semaforo = asyncio.Semaphore(10)

        async def detalle(vid: str):
            async with semaforo:
                r = await cliente.get(f"{url}/vulns/{vid}")
                r.raise_for_status()
                detalles[vid] = r.json()

        todos = {vid for ids in ids_por_paquete.values() for vid in ids}
        await asyncio.gather(*(detalle(v) for v in todos))

    hallazgos = []
    for p, ids in ids_por_paquete.items():
        for vid in ids:
            d = detalles[vid]
            hallazgos.append(HallazgoDTO(
                paquete=p,
                vuln_id=vid,
                alias=", ".join(d.get("aliases", [])) or None,   # aquí suelen venir los CVE
                severidad=severidad(d),
                resumen=(d.get("summary") or d.get("details") or "").strip()[:1000],
                version_corregida=version_corregida(d, p),
            ))
    return hallazgos
