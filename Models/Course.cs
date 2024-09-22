using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using MVC1.Validation;
using System.ComponentModel.DataAnnotations;

namespace MVC1.Models
{
	public class Course
	{
		public int Id { get; set; }

		[UniqueName]
		
		public string Name { get; set; }
		public double Degree { get; set; }
		public double MinDegree { get; set; }

		// Foreign key to Department
		[ForeignKey("Department")]
		public int ? DeptId { get; set; }
		public Department Department { get; set; }  // Navigation property

		// Navigation property
		public ICollection<Instructor> Instructors { get; set; }
		public ICollection<crsResult> crsResults { get; set; }
	}
}
