
using Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers
{
    public class CourseController : Controller
    {
        private static List<Course> courses = new List<Course>();

        // INDEX
        public IActionResult Index()
        {
            return View(courses);
        }

        // CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (courses.Any(c => c.Name == course.Name))
            {
                ModelState.AddModelError("Name", "This name already exists");
            }

            if (ModelState.IsValid)
            {
                course.Id = courses.Count == 0
                    ? 1
                    : courses.Max(c => c.Id) + 1;

                courses.Add(course);

                return RedirectToAction("Index");
            }

            return View(course);
        }

        // EDIT GET
        public IActionResult Edit(int id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // EDIT POST
        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (courses.Any(c => c.Name == course.Name && c.Id != course.Id))
            {
                ModelState.AddModelError("Name", "This name already exists");
            }

            if (ModelState.IsValid)
            {
                var existingCourse = courses.FirstOrDefault(c => c.Id == course.Id);

                if (existingCourse == null)
                {
                    return NotFound();
                }

                existingCourse.Name = course.Name;
                existingCourse.email = course.email;
                existingCourse.courseCode = course.courseCode;
                existingCourse.CourseHours = course.CourseHours;
                existingCourse.SemesterFee = course.SemesterFee;

                return RedirectToAction("Index");
            }

            return View(course);
        }

        // DELETE POST
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            courses.Remove(course);

            return RedirectToAction("Index");
        }
    }
}
