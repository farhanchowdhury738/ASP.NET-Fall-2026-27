using DbP.EF;
using DbP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DbP.Controllers
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
            return View();
        }

        // View All Students
        public IActionResult ViewAll()
        {
            var students = _context.student.ToList();
            return View(students);
        }

        // Edit - GET
        public IActionResult Update(int id)
        {
            var student = _context.student.Find(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // Edit - POST
        [HttpPost]
        public IActionResult Update(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.student.Update(student);
                _context.SaveChanges();

                return RedirectToAction("ViewAll");
            }

            return View(student);
        }

        // Delete
        public IActionResult Delete(int id)
        {
            var student = _context.student.Find(id);

            if (student == null)
                return NotFound();

            _context.student.Remove(student);
            _context.SaveChanges();

            return RedirectToAction("ViewAll");
        }

        // Search Student
        public IActionResult Search(string keyword)
        {
            var students = _context.student.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
                students = students.Where(s => s.name.Contains(keyword));

            return View(students.ToList());
        }

        // Department Filter
        public IActionResult Filter(string dept)
        {
            var departments = _context.student.Select(s => s.department).Distinct().ToList();
            ViewBag.Departments = new SelectList(departments);

            var students = _context.student.AsQueryable();

            if (!string.IsNullOrEmpty(dept))
                students = students.Where(s => s.department == dept);

            return View(students.ToList());
        }

        // CGPA Sort
        public IActionResult SortCgpa(string sort)
        {
            var students = sort == "desc"
                ? _context.student.OrderByDescending(s => s.cgpa).ToList()
                : _context.student.OrderBy(s => s.cgpa).ToList();

            return View(students);
        }

        // Top 5 Students
        public IActionResult TopStudents()
        {
            var students = _context.student
                .OrderByDescending(s => s.cgpa)
                .Take(5)
                .ToList();

            return View(students);
        }

    }
}