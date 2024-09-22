using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC1.Context;
using MVC1.Models;
namespace MVC1.Controllers
{
    public class CourseController : Controller
    {
        Unitxt db = new Unitxt();

        public IActionResult Delete(int id)
        {
            // Find the course and include related instructors and course results (crsResult)
            var course = db.Courses
                           .Include(c => c.Instructors)   // Include related instructors
                           .Include(c => c.crsResults)    // Include related course results
                           .FirstOrDefault(c => c.Id == id);  // Find course by id

            if (course == null)
            {
                return NotFound();
            }

            
           

            // handle related course results
            if (course.crsResults != null)
            {
                foreach (var crsResult in course.crsResults)
                {
                    crsResult.CrsId = null;  // Set foreign key to null 
                }
            }

            
            db.Courses.Remove(course);
            db.SaveChanges();

            return RedirectToAction("GetAll");  // Redirect to the Index page
        }



        public IActionResult Update(int id)
        {
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            var crsres = db.crsResults.ToList();
            ViewBag.crsResults = crsres;
            var cr = db.Courses.Find(id);
            return View(cr);
        }

        [HttpPost]
        public IActionResult SaveUpdate(Course c)
        {
            if (c.Name!=null)

            {
                db.Courses.Update(c);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            var crsres = db.crsResults.ToList();
            ViewBag.crsResults = crsres;
            return View("Update", c);
        }

        [HttpPost]
        public IActionResult SaveNew(Course c)
        {
            if (ModelState.IsValid)

            {
                db.Courses.Add(c);
                db.SaveChanges();
                return RedirectToAction("GetAll");

            }

            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            var crsres = db.crsResults.ToList();
            ViewBag.crsResults = crsres;

            return View("New", c);
        }


        public IActionResult New()
        {
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            var crsres = db.crsResults.ToList();
            ViewBag.crsResults = crsres;
            return View();
        }

        public IActionResult GetAll()
        {
            var crses = db.Courses.ToList();
            return View(crses);
            
        }
        public IActionResult Details(int id)
        {
            var crss = db.Courses.Include(c => c.Department).FirstOrDefault(c => c.Id == id);
            return View(crss);
        }
    }
}
