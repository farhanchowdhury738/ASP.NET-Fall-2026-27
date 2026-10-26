using LabDb.EF;
using Microsoft.AspNetCore.Mvc;

namespace LabDb.Controllers
{
    public class StudentController : Controller
    {
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
    }
}
