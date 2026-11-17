from fastapi import Depends,FastAPI
from app.auth import Usuario, get_current_user
from app.config import settings
from app.routers import analisis, proyectos, aplicaciones, buscar

app = FastAPI(title="Inventario de Aplicaciones Netkia")
app.include_router(analisis.router)
app.include_router(proyectos.router)
app.include_router(aplicaciones.router)
app.include_router(buscar.router)

@app.get("/api/health")
def health():
    return {"ok" : True, "modo_prueba" : settings.modo_prueba}

@app.get("/api/me")
def yo(usuario:Usuario=Depends(get_current_user)):
    """Quién soy y qué roles tengo"""
    return {"nombre" : usuario.nombre, "email" : usuario.email, "roles" : usuario.roles}