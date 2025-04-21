
# 🎓 SchoolSystem - Clean Architecture ASP.NET Core Project

## 🔰 Overview

SchoolSystem is a modular and maintainable ASP.NET Core Web API project built using **Clean Architecture**, **CQRS**, and **MediatR**.  
It demonstrates how to structure an enterprise-grade system for managing schools, users, and roles.

---

## 🏗️ Project Structure

```
SchoolSystem
├── SchoolSystem.Core                     # Domain Layer
│   ├── Entities                          # Core business models
│   ├── Domain.Interfaces                 # Domain contracts (e.g. IRepository)
│   ├── Routing
│   └── Specifications 
│
├── SchoolSystem.Application              # Application Layer (CQRS)
│   ├── Features                          # Use Cases (Commands, Queries, Handlers)
│   │   ├── Students
│   │   └── Auth
│   ├── DTOs                              # Input/Output models
│   ├── Services                          # Internal application logic
│       ├── Interfaces                    # Services contracts (IAuthService, etc.)
│   ├── Bases                             # Response and Response Handler
│   │   ├── Response
│   │   └── ResponseHandler
│   └── Mapping                           # AutoMapper profiles
│
├── SchoolSystem.Infrastructure           # Infrastructure Layer
│   ├── Persistence
│   │   ├── DbContext.cs
│   │   ├── Configurations
│   │   ├── Unit Of Work
│   │   └── Migrations
│   ├── Repositories                      # EF Core implementations
│
├── SchoolSystem.APIs                     # Presentation Layer
│   ├── Controllers                       # REST endpoints
│   ├── Middleware                        # Exception handling, authentication
│   └── Program.cs / Startup.cs
```

---

## 🧠 Key Concepts

✅ Clean Architecture  
✅ CQRS with MediatR  
✅ AutoMapper for object mapping  
✅ Identity for authentication  
✅ JWT for secure access  
✅ Refresh tokens  
✅ Unit of Work & Repository pattern  
✅ Solid separation of concerns  

---

## 🧪 Technologies Used

- ASP.NET Core 8 Web API
- MediatR
- Entity Framework Core
- Identity
- AutoMapper
- FluentValidation
- SQL Server

## 🧩 TODO :

- ✅ Caching (Redis)
- ✅ Logging (Serilog)
- ✅ Swagger Documentation per endpoint
- ✅ Unit Tests for Handlers & Services
- ✅ Docker Support

---

## 🧑‍💻 Author

Mahmoud Ahmed  
[GitHub Profile](https://github.com/Mahmoud-Ahmed-23)
