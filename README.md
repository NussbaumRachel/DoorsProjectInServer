# 🚪 Metzada Doors — Backend API (ASP.NET Core)

The server side of the **Metzada Doors** factory management system.
It exposes a REST API for orders, customers, employees and door products, and **generates CNC machine programs (`.mpf`) automatically from a door's specification**.

> Frontend: [MetzadaReact](https://github.com/NussbaumRachel/MetzadaReact)

## ✨ Highlights

- **Automatic CNC program generation** — a door's dimensions and options are turned into a ready-to-run `.mpf` program for the factory's punching machine
- **Rule Engine** — each manufacturing feature (frame, hinges, perforation, skylight) is a separate rule that produces machining operations; adding a feature means adding one class
- **JWT authentication** with role-based users (manager, measurer, etc.)
- **Excel export** of orders (ClosedXML)
- **File upload & download** for door attachments
- **Swagger / OpenAPI** documentation in development

## 🏗️ Architecture

A layered (N-tier) solution with dependency injection between layers:

```
DoorsProjectInServer/   → API layer: controllers, JWT, CORS, Swagger
Bl/                     → Business logic: services, Rule Engine, MPF generator
Dal/                    → Data access: EF Core DbContext, entities, repositories
Helpers/                → Shared utilities
```

### CNC program generation flow

```
BlDoor ──► DoorProcessingService ──► RuleEngine
                                      ├── FrameRule
                                      ├── HingesRule
                                      ├── PerforationRule
                                      └── SkylightRule
                                           │
                                           ▼
                               List<Operation> ──► MpfGenerator ──► .mpf file
                                 (header · setup · tool definitions · operations · footer)
```

## 🛠️ Tech Stack

- **C# / .NET 8**, ASP.NET Core Web API
- **Entity Framework Core 8** + **SQL Server** (code-first migrations)
- **JWT Bearer** authentication
- **ClosedXML** for Excel
- **Swashbuckle** (Swagger UI)

## 🔌 Main Endpoints

| Area | Route |
|------|-------|
| Auth | `POST /api/Auth/login` |
| Doors | `GET / POST / PUT / DELETE /api/Door`, `POST /api/Door/UploadDoorFile/{doorId}`, `GET /api/Door/file` |
| Orders | `/api/Order`, `/api/OrderItem` |
| Customers | `/api/Customer` |
| Employees | `/api/Employees` |
| Frames | `/api/DoorFrame` |

## 🚀 Getting Started

1. Install the .NET 8 SDK and SQL Server (LocalDB is enough).
2. Set the connection string in `Dal/Models/DbManager.cs` and the JWT settings in `appsettings.json`.
3. Create the database and run the API:

```bash
dotnet ef database update --project Dal --startup-project DoorsProjectInServer
dotnet run --project DoorsProjectInServer
```

Swagger UI is then available at `https://localhost:7253/swagger`.
