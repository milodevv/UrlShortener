# UrlShortener

Solución para acortar URLs, basada en .NET 8, arquitectura limpia y buenas prácticas de desarrollo. Permite crear URLs cortas a partir de URLs largas, gestionando la persistencia y exposición mediante una API REST.

---

## Arquitectura y Dise�o

La solución sigue los principios de **Clean Architecture**, separando responsabilidades en capas: Presentación (API), Aplicación (casos de uso), Infraestructura (persistencia y servicios), y Dominio (entidades y lógica de negocio).

**Patrones de dise�o implementados:**

**Patrones de diseño implementados:**
- **CQRS** (Command Query Responsibility Segregation) usando MediatR.
- **Dependency Injection** para la gestión de dependencias.
- **Repository/Unit of Work** a través de DbContext de Entity Framework Core.
- **DTOs y AutoMapper** para la transformación de datos entre capas.

---

## Proyectos

### 1. UrlShortener.Services.API (Presentaci�n)

- **Tipo:** ASP.NET Core Web API
- **Responsabilidad:** Expone endpoints REST para acortar URLs y recuperar URLs largas.
- **Tecnologías:** ASP.NET Core, Swagger (Swashbuckle), MediatR.
- **Paquetes principales:**
  - `Swashbuckle.AspNetCore` (documentación Swagger)
  - `Microsoft.EntityFrameworkCore.Design`
- **Características:**
  - Controlador principal: `UrlController` con endpoints:
    - `POST /api/url/shorten` para acortar URLs
    - `GET /api/url/{shortUrl}` para recuperar la URL original
  - Integración con Swagger para pruebas y documentación.
  - Inyección de servicios de aplicación e infraestructura.
  - Configuración de CORS abierta para desarrollo.

### 2. UrlShortener.Application.UseCases (Aplicaci�n)

- **Tipo:** Biblioteca de clases
- **Responsabilidad:** Contiene la lógica de negocio y casos de uso (handlers, comandos, validaciones).
- **Tecnologías:** MediatR, AutoMapper, FluentValidation.
- **Paquetes principales:**
  - `MediatR` (implementación de CQRS)
  - `AutoMapper` (mapeo de objetos)
  - `FluentValidation` y `FluentValidation.DependencyInjectionExtensions` (validaciones)
  - `Microsoft.AspNetCore.Diagnostics`, `Microsoft.AspNetCore.Http.Abstractions` (soporte para excepciones y HTTP)
- **Características:**
  - Handlers para comandos y queries.
  - Interfaces para abstracción de servicios y persistencia.
  - DTOs para respuestas y configuración.

### 3. UrlShortener.Persistence (Infraestructura)

- **Tipo:** Biblioteca de clases
- **Responsabilidad:** Implementa la persistencia de datos y servicios de infraestructura.
- **Tecnologías:** Entity Framework Core 9, MySQL.
- **Paquetes principales:**
  - `Microsoft.EntityFrameworkCore`
  - `Pomelo.EntityFrameworkCore.MySql` (proveedor MySQL)
  - `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
  - `Microsoft.Extensions.Configuration`, `Microsoft.Extensions.DependencyInjection`
- **Características:**
  - `ApplicationDbContext` como DbContext principal.
  - Servicio `UrlShorteningService` para generación de códigos únicos, configurable mediante `ShortLinkSettings` (alfabeto y longitud).
  - Configuración de entidades con restricciones y claves únicas.
  - Migraciones incluidas en la carpeta `Migrations`.
  - Configuración de inyección de dependencias.

### 4. UrlShortener.Domain (Dominio)

- **Tipo:** Biblioteca de clases
- **Responsabilidad:** Define las entidades y lógica de negocio central.
- **Tecnologías:** .NET 8
- **Características:**
  - Entidad principal: `ShortenedUrl` (con propiedades `LongUrl`, `ShortUrl`, `Code` y auditoría).
  - Clases base para auditoría y reglas de dominio.

---

## Tecnolog�as Utilizadas

- **.NET 8**
- **ASP.NET Core**
- **Entity Framework Core 9** (con MySQL)
- **MediatR**
- **AutoMapper**
- **FluentValidation**
- **Swagger (Swashbuckle)**

---

## Paquetes Principales

- `MediatR`
- `AutoMapper`
- `FluentValidation`
- `FluentValidation.DependencyInjectionExtensions`
- `Microsoft.EntityFrameworkCore`
- `Pomelo.EntityFrameworkCore.MySql`
- `Swashbuckle.AspNetCore`
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
- `Microsoft.Extensions.Configuration`
- `Microsoft.Extensions.DependencyInjection`

---

## Resumen de la Arquitectura

- **Presentación:** API REST con ASP.NET Core y Swagger.
- **Aplicación:** Casos de uso y lógica de negocio desacoplada (CQRS, validaciones, mapeos).
- **Infraestructura:** Persistencia con Entity Framework Core y servicios externos (MySQL).
- **Dominio:** Entidades y lógica de negocio pura, con auditoría.

---

## Ejecuci�n

1. Configura la cadena de conexión a MySQL en `appsettings.json`.
2. Ejecuta las migraciones con Entity Framework Core para crear la base de datos:
   - Ejemplo: `dotnet ef database update --project src/Infrastructure/UrlShortener.Persistence/`
3. Levanta la API (`dotnet run --project src/Presentation/UrlShortener.Services.API/`) y prueba los endpoints usando Swagger (`/swagger`).
4. Los endpoints principales son:
   - `POST /api/url/shorten` (acortar URL)
   - `GET /api/url/{shortUrl}` (recuperar URL original)
5. La configuración de CORS permite pruebas desde cualquier origen en desarrollo.

---