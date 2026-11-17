from datetime import datetime
from pydantic import BaseModel, ConfigDict, Field
from app.models import Entorno, TipoTecnologia, Exposicion

class AplicacionIn(BaseModel):
    nombre: str = Field(min_length=1, max_length=150)
    entorno: Entorno
    url: str | None = None
    exposicion: Exposicion
    tipo_tecnologia: TipoTecnologia
    framework_nombre: str | None = None
    framework_version: str | None = None
    lenguaje: str | None = None
    lenguaje_version: str | None = None
    gestor_paquetes: str | None = None
    gestor_version: str | None = None
    url_repositorio: str | None = None


class AplicacionOut(AplicacionIn):
    model_config = ConfigDict(from_attributes=True)
    id: int
    proyecto_id: int

class ProyectoIn(BaseModel):
    """Lo que manda el front para crear/editar un proyecto"""
    nombre: str = Field(min_length=1, max_length=150)
    cliente: str = Field(min_length=1, max_length=150)
    responsable: str = Field(min_length=1, max_length=150)
    mantenimiento_contratado: bool=False

class ProyectoOut(ProyectoIn):
    """Lo que devuelve la API"""
    model_config=ConfigDict(from_attributes=True)

    id:int
    creado_por_nombre: str
    creado_en:datetime
    puede_editar: bool=False   
    aplicaciones: list[AplicacionOut]=[] 

class ResultadoBusqueda(AplicacionOut):
    """Una aplicación + datos de su proyecto, para el buscador"""
    proyecto_nombre:str
    cliente:str
    responsable:str    

class HallazgoOut(BaseModel):
    model_config = ConfigDict(from_attributes=True)
    paquete: str
    version: str
    ecosistema: str
    vuln_id: str
    alias: str | None
    severidad: str
    resumen: str
    version_corregida: str | None
    aproximado: bool


class AnalisisOut(BaseModel):
    model_config = ConfigDict(from_attributes=True)
    id: int
    fichero: str
    total_paquetes: int
    total_vulnerables: int
    realizado_por: str
    realizado_en: datetime
    hallazgos: list[HallazgoOut]
