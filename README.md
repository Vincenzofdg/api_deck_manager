## Packages

### Swagger:
```sh
dotnet add package Swashbuckle.AspNetCore --version 8.1.1

Microsoft.AspNetCore.OpenApi
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspNetCore
xunit
```

<hr />

## Project Structure

```txt
/Deck_Manager
│
│
├── /Api                            # Main project (presentation layer - Controllers)
│   │
│   ├── Controllers/                # API controllers
│   ├── Middlewares/                # Custom middlewares
│   ├── Program.cs                  # Application entry point (since .NET 6+)
│   ├── appsettings.json            # Application settings
│   │
│   └── Properties/
│       └── launchSettings.json
│
├── /Application                    # Application layer (business logic and services)
│   │
│   ├── Interfaces/                 # Service interfaces
│   └── Services/                   # Service implementations
│
├── /Domain                         # Domain layer (pure domain entities and rules)
│   │
│   ├── Entities/                   # Domain entities
│   └── ValueObjects/               # Value Objects (if any)
│
├── /Infrastructure                 # Infrastructure layer (data access, external integrations)
│   │
│   ├── Data/                       # DbContext and repositories
│   ├── Migrations/                 # EF Core migrations
│   └── Configurations/             # Entity configurations (Fluent API)
│
├── /Tests                          # Test project
│   │
│   ├── Unit/                       # Unit tests
│   └── Integration/                # Integration tests
│
└── /Shared                         # (Optional) Shared classes across projects
    │
    ├── DTOs/                       # Data Transfer Objects
    ├── Constants/                  # Globally used constants
    └── Exceptions/                 # Custom exception classes
```
