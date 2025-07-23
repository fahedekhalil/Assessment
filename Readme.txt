## ▪ Setup / Run Instructions

1. **Requirements**
   - Visual Studio 2022 (latest updates)
   - .NET 8 SDK

2. **NuGet Package**
| Package Name                                               | Purpose                                       |
| ---------------------------------------------------------- | --------------------------------------------- |
| `Microsoft.AspNetCode.Identity.EntityFrameworkCore  8.0.6` | ASP.NET COre Identity provider that uses Entity Framework |
| `Microsoft.EntityFrameworkCode 8.0.6`			     |
| `Microsoft.EntityFrameworkCore.Tools 8.0.6`                |
| `Microsoft.EntityFrameworkCore.InMemory`                   | In-memory database for development/testing    |
| `Microsoft.AspNetCore.OpenApi` or `Swashbuckle.AspNetCore` | Swagger/OpenAPI support                       |
| `AutoMapper.Extensions.Microsoft.DependencyInjection`      | Integrates AutoMapper with DI                 |


3. **Steps**
   - Extract the project.
   - Open the project in Visual Studio 2022.
   - Build the solution.
   - Press F5 to run the project.
   - The API will launch with Swagger UI by default at:
     ```
     https://localhost:{port}/swagger
     ```

4. **Test via Postman**
   - Import the included Postman collection (`Assessment.postman_collection.json`)
   - Use the sample requests to test:
     - Register
     - CreateOrders
     - GetOrders

---

## ▪ Architectural Decisions

1. **Clean Architecture**
   - Separated layers: API (Presentation), DTOs, Models, Controllers, Services
   - Services are tenant-aware and access data through injected dependencies
   - DTOs and AutoMapper for model separation
   - Dependency Injection used throughout

2. Multitenancy

    - Shared database with a TenantId column on all tables (Customer, CustomerOrder, CustomerOrderItem)
    - TenantId is passed as a route parameter (e.g., /api/{tenantId}/customers/register)
    - Middleware: A custom middleware extracts the TenantId from the request URL and sets it in a scoped ITenantProvider
    - EF Core query filters ensure that only records matching the current tenant are accessible

3. **Database**
   - In-memory provider for local development
   - Query filters based on TenantId are applied in OnModelCreating
  
4. **Mapping**
   - AutoMapper used to simplify DTO <-> Entity conversion
   - TenantId is set manually in service methods after mapping to ensure it's filled correctly

5. **Validation**
   - Validation on the existing of TenantId in the request validation via Tenant Middleware
   - Validation rules are applied on DTOs before processing

---

## ▪ Postman Collection

- File: `Assessment.postman_collection.json`
- Includes:
  - POST `/api/{tenantId}/customers/register` – Register
  - POST `/api/{tenantId}/orders` – Create Order
  - GET `/api/{tenantId}/orders` – Get Orders

