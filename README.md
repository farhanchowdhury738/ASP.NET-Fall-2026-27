# Lab (Without DB)

A simple ASP.NET Core MVC project to manage courses using a List instead of a database.

Features
- Create, Read, Update, Delete (CRUD).
- Duplicate ID checking.

Validation
- Course hours (1–4)
- Course Code (CSE1101)
- Fee range (5000–50000)
#

# LabDB (With Database)

A simple ASP.NET Core MVC project to manage courses using Entity Framework Core and SQL Server.

## Setup Workflow

```text        
Install Packages
       ↓
Configure appsettings.json
       ↓
Create EF → AppDbContext.cs
       ↓
Create Model
       ↓
Register Model → AppDbContext.cs
       ↓
Configure Program.cs
```
After that create Databse.

## 1. Install NuGet Packages

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

## 2. Configure appsettings.json
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=UserManagement;Trusted_Connection=True;TrustServerCertificate=True",
    "AppDbContext": "Server=(localdb)\\mssqllocaldb;Database=AppDbContext;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

## 3. Create AppDbContext.cs
```csharp
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
```

## 4. Register Model in AppDbContext
```csharp
public DbSet<Student> student { get; set; }
```

## 5. Configure Program.cs
```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
```






















