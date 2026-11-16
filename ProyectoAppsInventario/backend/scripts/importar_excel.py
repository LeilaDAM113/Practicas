from openpyxl import load_workbook
from app.db import SessionLocal
from app.models import Aplicacion, Proyecto

def vacio(valor):
    """N/A o celda vacía -> None"""
    return None if valor in (None, "", "N/A") else valor

hoja = load_workbook("datos/Inventario APPs.xlsx").active
db = SessionLocal()
proyectos = {}

try:
    # con min_row=2 saltamos la fila de los títulos
    for fila in hoja.iter_rows(min_row=2, values_only=True):
        (
            proyecto, cliente, app, entorno, url, exposicion, tipo,
            framework, v_framework, lenguaje, v_lenguaje, gestor,
            v_gestor, responsable, mantenimiento, repo
        ) = fila[:16]

        if not proyecto:
            continue

        if proyecto not in proyectos:
            proyectos[proyecto] = Proyecto(
                nombre=proyecto,
                cliente=cliente,
                responsable=responsable,
                mantenimiento_contratado=(mantenimiento == "Si"),
                creado_por_oid="prueba-pm-a",
                creado_por_nombre="PM Prueba A",
            )
            db.add(proyectos[proyecto])

        proyectos[proyecto].aplicaciones.append(
            Aplicacion(
                nombre=app,
                entorno=entorno,
                url=vacio(url),
                exposicion=exposicion,
                tipo_tecnologia=tipo,
                framework_nombre=vacio(framework),
                framework_version=vacio(v_framework),
                lenguaje=vacio(lenguaje),
                lenguaje_version=vacio(v_lenguaje),
                gestor_paquetes=vacio(gestor),
                gestor_version=vacio(v_gestor), 
                url_repositorio=vacio(repo),
            )
        )

    db.commit()
    print("Importado correctamente")

except Exception as e:
    db.rollback()
    print(f"Error al importar: {e}")
finally:
    db.close()