using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC1.Context;
using MVC1.Models;

namespace MVC1.Controllers
{
	public class DepartmentController : Controller
	{
        Unitxt db = new Unitxt();


        public IActionResult Delete(int id)
        {
            
            var depart = db.Departments
                           .Include(c => c.Instructors)   
                           .Include(c => c.Courses)    
                           .FirstOrDefault(c => c.DeptId == id);  

            if (depart == null)
            {
                return NotFound();
            }



            if (depart.Instructors != null)
            {
                foreach (var instructor in depart.Instructors)
                {
                    instructor.DeptId = null;  // Set foreign key to null
                }
            }

            db.Departments.Remove(depart);
            db.SaveChanges();

            return RedirectToAction("GetAll");  // Redirect to the appropriate action
        }


        public IActionResult Update(int id)
		{
			var depts = db.Departments.ToList();
			ViewBag.Departments = depts;
			
			var dp = db.Departments.Find(id);
			return View(dp);
		}

		[HttpPost]
		public IActionResult SaveUpdate(Department d)
		{
			if (ModelState.IsValid)

			{
				db.Departments.Update(d);
				db.SaveChanges();
				return RedirectToAction("GetAll");
			}
			var depts = db.Departments.ToList();
			ViewBag.Departments = depts;
			
			return View("Update", d);
		}

		[HttpPost]
        public IActionResult SaveNew(Department d)
        {
            if (ModelState.IsValid)

            {
                db.Departments.Add(d);
                db.SaveChanges();
                return RedirectToAction("GetAll");

            }

            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            

            return View("New", d);
        }

        public IActionResult New()
        {
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            
            return View();
        }
        public IActionResult GetAll()
		{
            var depts = db.Departments.ToList();
            return View(depts);
        }
        public IActionResult Details(int id)
        {
            var depts = db.Departments.Include(d => d.Courses).FirstOrDefault(d => d.DeptId == id);
            return View(depts);
        }
    }
}
