import enum
from datetime import datetime
from sqlalchemy import Enum, ForeignKey, String, UniqueConstraint, func
from sqlalchemy.orm import Mapped, mapped_column, relationship
from app.db import Base

#Enumerados
class Entorno(str, enum.Enum):
    DEV = "Dev"
    TEST = "Test"
    PROD = "Prod"

class Exposicion(str, enum.Enum):
    PUBLICO = "Publico"
    PRIVADO = "Privado"
    LIMITADO = "Limitado"

class TipoTecnologia(str, enum.Enum):
    FRAMEWORK = "Framework"
    DESARROLLO_PROPIO = "Desarrollo propio"
    HERRAMIENTA = "Herramienta"

def _enum(clase,nombre):
    #Guarda en la bd el valor interno, es decir de DEV guarda Dev y así con los demás
    return Enum(clase, name=nombre, values_callable=lambda x: [i.value for i in x])

class Proyecto(Base):
    __tablename__="proyectos"

    #Columnas de la tabla
    id: Mapped[int]= mapped_column (primary_key=True)
    nombre: Mapped[str]= mapped_column (String(150))
    cliente: Mapped[str]= mapped_column (String(150))
    responsable: Mapped [str]= mapped_column (String(150))
    mantenimiento_contratado: Mapped [bool]= mapped_column (default=False)

    #Quien lo ha creado (PM solo verá los campos donde este campo sea él)
    creado_por_oid: Mapped [str]= mapped_column(String(64), index=True)
    creado_por_nombre: Mapped [str]= mapped_column(String(150))
    creado_en: Mapped[datetime]= mapped_column(server_default=func.now())

    aplicaciones: Mapped[list["Aplicacion"]] = relationship(back_populates="proyecto" , cascade="all , delete-orphan" , order_by="Aplicacion.nombre" ,
   )

class Aplicacion(Base):
        __tablename__="aplicaciones"
        __table_args__= (UniqueConstraint("proyecto_id", "nombre", "entorno", name="uq_aplicacion_proyecto_nombre_entorno"),
                         )
        id: Mapped [int]= mapped_column (primary_key=True)
        proyecto_id: Mapped [int]= mapped_column(ForeignKey("proyectos.id", ondelete="CASCADE"), index=True)
        nombre: Mapped [str]= mapped_column (String(150))
        entorno: Mapped [Entorno]= mapped_column (_enum(Entorno, "entorno"))
        url : Mapped [ str | None]= mapped_column (String(500))
        exposicion : Mapped [str]= mapped_column (_enum(Exposicion, "exposicion"))
        tipo_tecnologia: Mapped [str]= mapped_column (_enum(TipoTecnologia, "tipo_tecnologia"))

        framework_nombre: Mapped [str | None]= mapped_column (String(100), index=True)
        framework_version: Mapped [str | None]= mapped_column (String(50))
        lenguaje: Mapped [str | None]= mapped_column (String(50), index=True)
        lenguaje_version: Mapped [str | None]= mapped_column(String(50))
        gestor_paquetes: Mapped [str | None]= mapped_column(String(50))
        gestor_version: Mapped [str | None]= mapped_column(String(50))
        url_repositorio: Mapped [str | None]= mapped_column(String(500))

        #Proyecto al que pertenece
        proyecto: Mapped["Proyecto"]=relationship(back_populates="aplicaciones")

