# UrlShortener

Soluci�n para acortar URLs, basada en .NET 8, arquitectura limpia y buenas pr�cticas de desarrollo. Permite crear URLs cortas a partir de URLs largas, gestionando la persistencia y exposici�n mediante una API REST.

---

## Arquitectura y Dise�o

La soluci�n sigue los principios de **Clean Architecture**, separando responsabilidades en capas: Presentaci�n (API), Aplicaci�n (casos de uso), Infraestructura (persistencia y servicios), y Dominio (entidades y l�gica de negocio).

**Patrones de dise�o implementados:**
- **CQRS** (Command Query Responsibility Segregation) usando MediatR.
- **Dependency Injection** para la gesti�n de dependencias.
- **Repository/Unit of Work** a trav�s de DbContext de Entity Framework.
- **DTOs y AutoMapper** para la transformaci�n de datos entre capas.

---

## Proyectos

### 1. UrlShortener.Services.API (Presentaci�n)
- **Tipo:** ASP.NET Core Web API
- **Responsabilidad:** Expone endpoints REST para acortar URLs.
- **Tecnolog�as:** ASP.NET Core, Swagger (Swashbuckle), MediatR.
- **Paquetes principales:**
  - `Swashbuckle.AspNetCore` (documentaci�n Swagger)
  - `Microsoft.EntityFrameworkCore.Design`
- **Caracter�sticas:** 
  - Controlador principal: `UrlController`
  - Integraci�n con Swagger para pruebas y documentaci�n.
  - Inyecci�n de servicios de aplicaci�n e infraestructura.

### 2. UrlShortener.Application.UseCases (Aplicaci�n)
- **Tipo:** Biblioteca de clases
- **Responsabilidad:** Contiene la l�gica de negocio y casos de uso (handlers, comandos, validaciones).
- **Tecnolog�as:** MediatR, AutoMapper, FluentValidation.
- **Paquetes principales:**
  - `MediatR` (implementaci�n de CQRS)
  - `AutoMapper` (mapeo de objetos)
  - `FluentValidation` (validaciones)
- **Caracter�sticas:**
  - Handlers para comandos y queries.
  - Interfaces para abstracci�n de servicios y persistencia.

### 3. UrlShortener.Persistence (Infraestructura)
- **Tipo:** Biblioteca de clases
- **Responsabilidad:** Implementa la persistencia de datos y servicios de infraestructura.
- **Tecnolog�as:** Entity Framework Core, MySQL.
- **Paquetes principales:**
  - `Microsoft.EntityFrameworkCore`
  - `Pomelo.EntityFrameworkCore.MySql` (proveedor MySQL)
- **Caracter�sticas:**
  - `ApplicationDbContext` como DbContext principal.
  - Servicios como `UrlShorteningService` para generaci�n de c�digos �nicos.
  - Configuraci�n de inyecci�n de dependencias.

### 4. UrlShortener.Domain (Dominio)
- **Tipo:** Biblioteca de clases
- **Responsabilidad:** Define las entidades y l�gica de negocio central.
- **Tecnolog�as:** .NET Standard
- **Caracter�sticas:**
  - Entidades como `ShortenedUrl`.
  - Base para la l�gica de negocio y reglas de dominio.

---

## Tecnolog�as Utilizadas

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

- **Presentaci�n:** API REST con ASP.NET Core.
- **Aplicaci�n:** Casos de uso y l�gica de negocio desacoplada.
- **Infraestructura:** Persistencia y servicios externos.
- **Dominio:** Entidades y l�gica de negocio pura.

---

## Ejecuci�n

1. Configura la cadena de conexi�n a MySQL en `appsettings.json`.
2. Ejecuta migraciones si es necesario.
3. Levanta la API y prueba los endpoints usando Swagger.

---