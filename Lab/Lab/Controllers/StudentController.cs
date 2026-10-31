using Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            Student[] students = new Student[3];

            for(int i=0; i < students.Length; i++)
            {
                var student = new Student()
                {
                    Id = i + 1,
                    Name = $"Name {i + 1}",
                    Email = $"student{i + 1}@example.com"
                };
                students[i] = student;
            }
            return View(students);
        }

        // match id then show specific student details
        public IActionResult Details(int id)
        {
            Student[] students = new Student[3];

            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Student()
                {
                    Id = i + 1,
                    Name = $"Name {i + 1}",
                    Email = $"student{i + 1}@example.com"
                };
            }

            foreach (var student in students)
            {
                if (student.Id == id)
                {
                    return View(student);
                }
            }

            return NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
