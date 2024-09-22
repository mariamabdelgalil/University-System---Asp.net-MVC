using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC1.Context;
using MVC1.Models;

namespace MVC1.Controllers
{
	public class InstructorController : Controller
	{
		Unitxt db = new Unitxt();
        
        public IActionResult Delete(int id)
        {
            var ins = db.Instructors.Find(id);
            db.Instructors.Remove(ins);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            var crses = db.Courses.ToList();
            ViewBag.Courses = crses;
            var ins = db.Instructors.Find(id);
            return View(ins);
        }

        [HttpPost]
        public IActionResult SaveUpdate(Instructor i)
        {
            if(ModelState.IsValid)
            
            {
                db.Instructors.Update(i);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
			var crses = db.Courses.ToList();
			ViewBag.Courses = crses;
			return View("Update", i);
        }

       
        

        [HttpPost]
        public IActionResult SaveNew(Instructor i)
        {
            if (ModelState.IsValid)
        
            {
                db.Instructors.Add(i);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
			var crses = db.Courses.ToList();
			ViewBag.Courses = crses;

			return View("New",i);
        }

       
        public IActionResult New()
		{
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
			var crses = db.Courses.ToList();
			ViewBag.Courses = crses;
			return View();
		}
		public IActionResult Index()
		{
			var ins = db.Instructors.ToList(); 
			return View(ins);
		}

        public IActionResult Details(int id)
		{

            //var inss = db.Instructors.Find(id);
            var inss = db.Instructors.Include(i => i.Department).FirstOrDefault(i => i.Id == id);
            return View(inss);
		}
	}
}
