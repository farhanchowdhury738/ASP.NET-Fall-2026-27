# Lab (Without DB)

A simple ASP.NET Core MVC project to manage courses using a List instead of a database.
<table>
    <tr>
        <th>Features</th>
        <th>Validation</th>
    </tr>
    <tr>
        <td>
            <p>Create, Read, Update, Delete</p>
            <p>Duplicate ID checking.</p>
        </td>
        <td>
            <p>Course hours (1–4)</p>
            <p>Course Code (CSE1101)</p>
        </td>
    </tr>
</table>

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
Configure Program.cs
       ↓
Create Model, Controller, View
       ↓
Register Model → AppDbContext.cs
```
### After that create Databse.

## 1. Install NuGet Packages

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

## 2. Configure appsettings.json
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=FARHAN\\SQLEXPRESS;Database=section_a;Trusted_Connection=True;TrustServerCertificate=True",
    "AppDbContext": "Server=FARHAN\\SQLEXPRESS;Database=AppDbContext;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
```
### Now create Database, and create table (users). insert some values manually. 

## 3. Create AppDbContext.cs
```csharp
using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {}
}
```
## 4. Configure Program.cs
```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
```

## 5.1 Create Model (Student)
```csharp
[Table("users")]
    public class Student
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? department { get; set; }
        public double cgpa { get; set; }
    }
```
## 5.2 Create Controller (StudentController)
```csharp
private readonly AppDbContext _context;
public StudentController(AppDbContext context)
{
    _context = context;
}
public IActionResult Index()
{
    var students = _context.student.ToList();
    return View(students);
}
```

## 5.3 Create View 
```csharp
<table class="table">
    <tr>
        <th>Name</th>
        <th>Department</th>
        <th>CGPA</th>
    </tr>
    @foreach (var student in Model)
    {
        <tr>
            <td>@student.name</td>
            <td>@student.department</td>
            <td>@student.cgpa</td>
        </tr>
    }
</table>
```

## 6. Register Model in AppDbContext
```csharp
public DbSet<Student> student { get; set; }
```






<h3 align="center">Need Help?</h3>

<p align="center">
  Have questions or facing an issue? Feel free to reach out. I'd be happy to help!
</p>

<p align="center">
  <a href="https://farhanchowdhury.xyz/contact">
    <img src="https://img.shields.io/badge/Click_Here_to_Contact_Me-0D6EFD?style=for-the-badge" alt="Contact Me">
  </a>
</p>



# 
# MID TERM EXAM PRACTICE LINQ

## 1. Filters employees based on salary.
```csharp
var data = _context.employee
    .Where(e => e.Salary > 50000)
    .ToList();
return View(data);
```

## 2. Sorts employees from highest salary to lowest salary.
```csharp
var data = _context.employee
    .OrderBy(e => e.Salary)
    .ToList();
return View(data);
```

## 3. Groups employees based on their department.
```csharp
var data = _context.employee
    .GroupBy(e => e.Department)
    .ToList();
return View(data);
```

## 4. Retrieves the first employee or returns null if no record exists.
```csharp
var data = _context.employee
    .FirstOrDefault();
return View(data);
```

## 5. Retrieves the employee with a specific ID or returns null if no record exists.
```csharp
var data = _context.employee
    .SingleOrDefault(e => e.EmpId == 5);
return View(data);
```

## 6. Selects only the employee name and salary.
```csharp
var data = _context.employee
    .Select(e => new
    {
        e.EmpName,
        e.Salary
    })
    .ToList();
return View(data);
```

## 7. Calculates the total, average, highest, and lowest salary of all employees.
```csharp
var data = _context.employee
    .Sum(e => e.Salary)
    .Average(e => e.Salary)
    .Max(e => e.Salary)
    .Min(e => e.Salary)
return Content("Total Salary: " + data);
```

## Quick Revision Table

| Method | Purpose |
|---|---|
| Where() | Filtering |
| OrderBy() | Ascending sorting |
| OrderByDescending() | Descending sorting |
| Select() | Selecting properties |
| GroupBy() | Grouping data |
| ToList() | Creating a list |
| FirstOrDefault() | Getting the first record |
| SingleOrDefault() | Getting a single record |
| Count() | Counting records |













