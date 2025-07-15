# UrlShortener

Solución para acortar URLs, basada en .NET 8, arquitectura limpia y buenas prácticas de desarrollo. Permite crear URLs cortas a partir de URLs largas, gestionando la persistencia y exposición mediante una API REST.

---

## Arquitectura y Diseño

La solución sigue los principios de **Clean Architecture**, separando responsabilidades en capas: Presentación (API), Aplicación (casos de uso), Infraestructura (persistencia y servicios), y Dominio (entidades y lógica de negocio).

**Patrones de diseño implementados:**
- **CQRS** (Command Query Responsibility Segregation) usando MediatR.
- **Dependency Injection** para la gestión de dependencias.
- **Repository/Unit of Work** a través de DbContext de Entity Framework.
- **DTOs y AutoMapper** para la transformación de datos entre capas.

---

## Proyectos

### 1. UrlShortener.Services.API (Presentación)
- **Tipo:** ASP.NET Core Web API
- **Responsabilidad:** Expone endpoints REST para acortar URLs.
- **Tecnologías:** ASP.NET Core, Swagger (Swashbuckle), MediatR.
- **Paquetes principales:**
  - `Swashbuckle.AspNetCore` (documentación Swagger)
  - `Microsoft.EntityFrameworkCore.Design`
- **Características:** 
  - Controlador principal: `UrlController`
  - Integración con Swagger para pruebas y documentación.
  - Inyección de servicios de aplicación e infraestructura.

### 2. UrlShortener.Application.UseCases (Aplicación)
- **Tipo:** Biblioteca de clases
- **Responsabilidad:** Contiene la lógica de negocio y casos de uso (handlers, comandos, validaciones).
- **Tecnologías:** MediatR, AutoMapper, FluentValidation.
- **Paquetes principales:**
  - `MediatR` (implementación de CQRS)
  - `AutoMapper` (mapeo de objetos)
  - `FluentValidation` (validaciones)
- **Características:**
  - Handlers para comandos y queries.
  - Interfaces para abstracción de servicios y persistencia.

### 3. UrlShortener.Persistence (Infraestructura)
- **Tipo:** Biblioteca de clases
- **Responsabilidad:** Implementa la persistencia de datos y servicios de infraestructura.
- **Tecnologías:** Entity Framework Core, MySQL.
- **Paquetes principales:**
  - `Microsoft.EntityFrameworkCore`
  - `Pomelo.EntityFrameworkCore.MySql` (proveedor MySQL)
- **Características:**
  - `ApplicationDbContext` como DbContext principal.
  - Servicios como `UrlShorteningService` para generación de códigos únicos.
  - Configuración de inyección de dependencias.

### 4. UrlShortener.Domain (Dominio)
- **Tipo:** Biblioteca de clases
- **Responsabilidad:** Define las entidades y lógica de negocio central.
- **Tecnologías:** .NET Standard
- **Características:**
  - Entidades como `ShortenedUrl`.
  - Base para la lógica de negocio y reglas de dominio.

---

## Tecnologías Utilizadas

- **.NET 8**
- **ASP.NET Core**
- **Entity Framework Core** (con MySQL)
- **MediatR**
- **AutoMapper**
- **FluentValidation**
- **Swagger (Swashbuckle)**

---

## Paquetes Principales

- `MediatR`
- `AutoMapper`
- `FluentValidation`
- `Microsoft.EntityFrameworkCore`
- `Pomelo.EntityFrameworkCore.MySql`
- `Swashbuckle.AspNetCore`

---

## Resumen de la Arquitectura

- **Presentación:** API REST con ASP.NET Core.
- **Aplicación:** Casos de uso y lógica de negocio desacoplada.
- **Infraestructura:** Persistencia y servicios externos.
- **Dominio:** Entidades y lógica de negocio pura.

---

## Ejecución

1. Configura la cadena de conexión a MySQL en `appsettings.json`.
2. Ejecuta migraciones si es necesario.
3. Levanta la API y prueba los endpoints usando Swagger.

---