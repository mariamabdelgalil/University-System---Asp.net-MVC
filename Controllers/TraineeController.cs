using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC1.Context;
using MVC1.Models;
using MVC1.ViewModels;

namespace MVC1.Controllers
{
    public class TraineeController : Controller
    {
        Unitxt db = new Unitxt();

        public IActionResult Delete(int id)
        {
            // Find the trainee and include related course results (crsResult)
            var trainee = db.Trainees
                            .Include(t => t.crsResults)  // Include related course results
                            .FirstOrDefault(t => t.Id == id);  // Find trainee by id

            if (trainee == null)
            {
                return NotFound();
            }

            // Disassociate related course results (set TraineeId to null)
            if (trainee.crsResults != null)
            {
                foreach (var crsResult in trainee.crsResults)
                {
                    crsResult.TraineeId = null;  // Set foreign key to null
                }
            }

            // Remove the trainee
            db.Trainees.Remove(trainee);
            db.SaveChanges();

            return RedirectToAction("GetAll");
        }

        //public IActionResult Delete(int id)
        //{
        //	var tr = db.Trainees.Find(id);
        //	db.Trainees.Remove(tr);
        //	db.SaveChanges();
        //	return RedirectToAction("GetAll");
        //}

        public IActionResult Update(int id)
		{
			var depts = db.Departments.ToList();
			ViewBag.Departments = depts;
			var crsres = db.crsResults.ToList();
			ViewBag.crsResults = crsres;
			var tr = db.Trainees.Find(id);
			return View(tr);
		}

		[HttpPost]
		public IActionResult SaveUpdate(Trainee t)
		{
			if (t.Name != null)

			{
				db.Trainees.Update(t);
				db.SaveChanges();
				return RedirectToAction("GetAll");
			}
			var depts = db.Departments.ToList();
			ViewBag.Departments = depts;
			var crsres = db.crsResults.ToList();
			ViewBag.crsResults = crsres;
			return View("Update", t);
		}

		[HttpPost]
		public IActionResult SaveNew(Trainee t)
		{
			if (t.Name != null)

			{
				db.Trainees.Add(t);
				db.SaveChanges();
				return RedirectToAction("GetAll");

			}

			var depts = db.Departments.ToList();
			ViewBag.Departments = depts;
			var crsres = db.crsResults.ToList();
			ViewBag.crsResults = crsres;

			return View("New", t);
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
            var trs = db.Trainees.Include(t => t.Department).ToList();  
            return View(trs);
        }

        // Action to get the detailed view of a trainee by id
        public IActionResult DetailsVM(int id)
        {
            var trainee = db.Trainees
                            .Include(t => t.Department)              
                            .Include(t => t.crsResults)              
                                .ThenInclude(cr => cr.Course)        
                            .FirstOrDefault(t => t.Id == id);         


            // Create a ViewModel to pass the detailed information to the view
            var traineeViewModel = new TraineeViewModel
            {
                TraineeId = trainee.Id,
                TraineeName = trainee.Name,
                Address = trainee.Address,
                Image = trainee.Image,
                DepartmentName = trainee.Department.DeptName,  
                Courses = trainee.crsResults.Select(cr => new CourseResultViewModel
                {
                    CourseName = cr.Course.Name,    
                    Grade = cr.Degree,
                    MinimumGrade = cr.Course.MinDegree     
                }).ToList()
            };

           
            return View(traineeViewModel);
        }
    }
}
