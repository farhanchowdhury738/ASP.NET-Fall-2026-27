using LabDb.EF;
using LabDb.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                _context.student.Add(s);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Update(int id)
        {
            var student = _context.student.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student s)
        {
            if (ModelState.IsValid)
            {
                _context.student.Update(s);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(s);
        }

        public IActionResult Delete(int id)
        {
            var student = _context.student.Find(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        public IActionResult Delete(Student s)
        {
            var student = _context.student.Find(s.id);

            if (student == null)
                return NotFound();

            _context.student.Remove(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }

}
