using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MVC1.Validation;
namespace MVC1.Models


{
	public class Department
	{
		[Key]
		public int DeptId { get; set; }

		[UniqueDep]
		public string DeptName { get; set; }

		public string ?Deptmanager { get; set; }


		public ICollection<Course> ? Courses { get; set; }

		// Navigation property for related Instructors
		public ICollection<Instructor> ? Instructors { get; set; }

		// Navigation property for related Trainees
		public ICollection<Trainee> ? Trainees { get; set; }
	}
}
