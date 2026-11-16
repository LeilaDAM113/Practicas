from dataclasses import dataclass, field
from fastapi import Header, HTTPException, Depends
from app.config import settings

ROL_SEGURIDAD="SEGURIDAD_INFORMATICA"
ROL_PM="PROJECT MANAGER"

@dataclass
class Usuario:
    oid:str
    nombre: str
    email: str
    roles: list[str] = field(default_factory=list)

    @property
    def es_seguridad(self)->bool:
        return ROL_SEGURIDAD in self.roles
    
    @property
    def es_pm(self)->bool:
        return ROL_PM in self.roles

#Usuarios de prueba para probar sin Microsoft
USUARIOS_PRUEBA={
    "pm-a": Usuario("prueba-pm-a", "PM Prueba A", "pm.a@netkia.es", [ROL_PM]),
    "pm-b": Usuario("prueba-pm-b", "PM Prueba B", "pm.b@netkia.es", [ROL_PM]),
    "seguridad": Usuario("prueba-seg", "Seguridad Prueba", "seguridad@netkia.es", [ROL_SEGURIDAD]),
}

def get_current_user(x_usuario_prueba:str|None = Header(None))-> Usuario:
    """Devuelve el usuario que hace la petición"""
    if settings.modo_prueba:
     return USUARIOS_PRUEBA.get(x_usuario_prueba or "pm-a", USUARIOS_PRUEBA["pm-a"])

     #Login con el token de MICROSOFT
    raise HTTPException(401, "Login real todavía no implementado")

def requiere_pm(usuario:Usuario=Depends(get_current_user))-> Usuario:
   """Igual que el método anterior, pero da error 403 si no es PM"""
   if not usuario.es_pm:
      raise HTTPException(403,"Solo un Project Manager puede hacer eso")
   return usuario