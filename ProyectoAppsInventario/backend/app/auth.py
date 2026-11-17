"""Autenticación con Microsoft Entra ID y roles de aplicación."""
from dataclasses import dataclass, field

import jwt
from fastapi import Depends, Header, HTTPException, status
from fastapi.security import HTTPAuthorizationCredentials, HTTPBearer
from jwt import PyJWKClient

from app.config import settings

ROL_SEGURIDAD = "SEGURIDAD_INFORMATICA"
ROL_PM = "PROJECT_MANAGER"

_ISSUER = f"https://login.microsoftonline.com/{settings.tenant_id}/v2.0"
_jwks = PyJWKClient(
    f"https://login.microsoftonline.com/{settings.tenant_id}/discovery/v2.0/keys",
    cache_keys=True,
)
_bearer = HTTPBearer(auto_error=False)


@dataclass
class Usuario:
    oid: str
    nombre: str
    email: str
    roles: list[str] = field(default_factory=list)

    @property
    def es_seguridad(self) -> bool:
        return ROL_SEGURIDAD in self.roles

    @property
    def es_pm(self) -> bool:
        return ROL_PM in self.roles


# Usuarios del modo prueba (el frontend los manda en la cabecera X-Usuario-Prueba)
USUARIOS_PRUEBA = {
    "pm-a": Usuario("prueba-pm-a", "PM Prueba A", "pm.a@netkia.es", [ROL_PM]),
    "pm-b": Usuario("prueba-pm-b", "PM Prueba B", "pm.b@netkia.es", [ROL_PM]),
    "seguridad": Usuario("prueba-seg", "Seguridad Prueba", "seguridad@netkia.es", [ROL_SEGURIDAD]),
}


def get_current_user(
    creds: HTTPAuthorizationCredentials | None = Depends(_bearer),
    x_usuario_prueba: str | None = Header(None),
) -> Usuario:
    if settings.modo_prueba:
        return USUARIOS_PRUEBA.get(x_usuario_prueba or "pm-a", USUARIOS_PRUEBA["pm-a"])

    if creds is None:
        raise HTTPException(status.HTTP_401_UNAUTHORIZED, "Falta el token")

    token = creds.credentials
    try:
        clave = _jwks.get_signing_key_from_jwt(token).key
        claims = jwt.decode(
            token,
            clave,
            algorithms=["RS256"],
            audience=settings.api_client_id,
            issuer=_ISSUER,
        )
    except jwt.PyJWTError as e:
        raise HTTPException(status.HTTP_401_UNAUTHORIZED, f"Token no válido: {e}")

    usuario = Usuario(
        oid=claims["oid"],
        nombre=claims.get("name", ""),
        email=claims.get("preferred_username", ""),
        roles=claims.get("roles", []),
    )
    if not (usuario.es_seguridad or usuario.es_pm):
        raise HTTPException(status.HTTP_403_FORBIDDEN, "No tienes ningún rol asignado en esta aplicación")
    return usuario


def requiere_pm(usuario: Usuario = Depends(get_current_user)) -> Usuario:
    if not usuario.es_pm:
        raise HTTPException(status.HTTP_403_FORBIDDEN, "Solo un Project Manager puede hacer esto")
    return usuario
