using LabDb.EF;
using Microsoft.AspNetCore.Mvc;

namespace LabDb.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // All employees ordered by JoinedAt descending
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewAll()
        {
            var employees = _context.employee
                .OrderByDescending(e => e.JoinedAt)
                .ToList();

            return View(employees);
        }

        // SeniorEmployees - ExperienceYears > 5
        public IActionResult SeniorEmployees()
        {
            var employees = _context.employee
                .Where(e => e.ExperienceYears > 5)
                .OrderByDescending(e => e.Salary)
                .ToList();

            return View(employees);
        }

        // DepartmentAverage - Group by Department
        public IActionResult DepartmentAverage()
        {
            var departments = _context.employee
                .GroupBy(e => e.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    AverageSalary = g.Average(e => e.Salary)
                })
                .OrderByDescending(g => g.AverageSalary)
                .ToList();

            return View(departments);
        }

    }
}
