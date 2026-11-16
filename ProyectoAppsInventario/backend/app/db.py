from sqlalchemy import create_engine
from sqlalchemy.orm import DeclarativeBase, sessionmaker
from app.config import settings
# Motor de la bd
engine = create_engine(settings.database_url, pool_pre_ping=True)
# Cada petición a la API abrirá su propia sesión
SessionLocal = sessionmaker(bind=engine, autoflush=False, expire_on_commit=False)
# Clase base de la que heredarán las tablas
class Base(DeclarativeBase):
    pass

def get_db():
    """"Abre una sesión para cada petición y cierra al terminar"""
    with SessionLocal() as db:
        yield db
