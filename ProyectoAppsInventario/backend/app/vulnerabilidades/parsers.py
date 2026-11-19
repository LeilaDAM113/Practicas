"""Lee composer.lock, package-lock.json y package.json y saca (paquete, versión, ecosistema)."""
import json
import re
from dataclasses import dataclass
from pathlib import PurePath


@dataclass(frozen=True)
class Paquete:
    nombre: str
    version: str
    ecosistema: str          # nombre del ecosistema en OSV: "npm", "Packagist"
    aproximado: bool = False  # True si la versión sale de un rango (package.json)


def parsear(nombre_fichero: str | None, contenido: bytes) -> list[Paquete]:
    try:
        data = json.loads(contenido.decode("utf-8-sig"))
    except (UnicodeDecodeError, json.JSONDecodeError):
        raise ValueError("El fichero no es un JSON válido")
    if not isinstance(data, dict):
        raise ValueError("Formato no reconocido")

    nombre = PurePath(nombre_fichero or "").name.lower()
    if "lockfileVersion" in data:
        paquetes = list(_package_lock(data))
    elif nombre == "composer.lock" or "content-hash" in data:
        paquetes = list(_composer_lock(data))
    elif "dependencies" in data or "devDependencies" in data:
        paquetes = list(_package_json(data))
    else:
        raise ValueError("Sube un composer.lock, package-lock.json o package.json")

    if not paquetes:
        raise ValueError("No se ha encontrado ninguna dependencia con versión en el fichero")
    return sorted(set(paquetes), key=lambda p: (p.nombre, p.version))


def _composer_lock(data: dict):
    for seccion in ("packages", "packages-dev"):
        for p in data.get(seccion) or []:
            version = str(p.get("version", ""))
            if not p.get("name") or not version or version.startswith("dev-"):
                continue  # ramas de git sin versión, no se pueden comprobar
            yield Paquete(p["name"], version.removeprefix("v"), "Packagist")


def _es_version(v) -> bool:
    return isinstance(v, str) and v[:1].isdigit()   # descarta "file:..", "git+..", etc.


def _package_lock(data: dict):
    paquetes = data.get("packages")
    if paquetes:  # lockfileVersion 2 y 3
        for ruta, info in paquetes.items():
            if not ruta or not isinstance(info, dict) or info.get("link"):
                continue  # "" es el propio proyecto
            nombre = info.get("name") or ruta.rsplit("node_modules/", 1)[-1]
            if _es_version(info.get("version")):
                yield Paquete(nombre, info["version"], "npm")
    else:  # lockfileVersion 1
        def recorrer(deps):
            for nombre, info in (deps or {}).items():
                if not isinstance(info, dict):
                    continue
                if _es_version(info.get("version")):
                    yield Paquete(nombre, info["version"], "npm")
                yield from recorrer(info.get("dependencies"))
        yield from recorrer(data.get("dependencies"))


_VERSION = re.compile(r"(\d+)(?:\.(\d+))?(?:\.(\d+))?")


def _package_json(data: dict):
    for seccion in ("dependencies", "devDependencies"):
        for nombre, rango in (data.get(seccion) or {}).items():
            rango = str(rango)
            if rango.startswith(("file:", "link:", "git", "http", "workspace:")):
                continue
            m = _VERSION.search(rango)
            if m:
                version = ".".join(x or "0" for x in m.groups())
                yield Paquete(nombre, version, "npm", aproximado=True)
