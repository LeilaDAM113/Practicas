# Curso de Arquitectura Limpia en .NET

Este proyecto es una solución estructurada bajo los principios de Clean Architecture para la gestión de partidos de fútbol.

## Estructura del Proyecto

La solución está organizada en las siguientes capas dentro del directorio `src`:

* **Soccer.Domain:** El núcleo puro de la aplicación. Contiene las entidades de negocio (`Game`, `Goal`), excepciones personalizadas y contratos de persistencia.
* **Soccer.Notification.Abstractions:** Contratos e interfaces para la abstracción del envío de notificaciones y alertas.
* **Soccer.Application:** Implementación de los casos de uso, servicios de comandos (`GameCommandService`) y servicios de consultas (`GameQueryService`).
* **Soccer.Persistence.Abstractions:** Interfaces adicionales para la abstracción de almacenamiento de datos.
* **Soccer.Persistence.InMemory:** Implementación del repositorio en memoria (`GameRepositoryInMemory`) para pruebas rápidas.
* **Soccer.WebApi:** Punto de entrada de la aplicación y exposición de los endpoints de la API.

## Pruebas Unitarias
El proyecto incluye un entorno de pruebas con **xUnit**, **Moq** y **FluentAssertions** ubicado en la carpeta `test/Soccer.Domain.UnitTests`.