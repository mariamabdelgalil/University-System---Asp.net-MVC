using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MVC1.Validation;

namespace MVC1.Models
{
	public class Instructor
	{
		public int Id { get; set; }
        [MinLength(3, ErrorMessage = "Name must be more than 2 letter")]
        [MaxLength(20, ErrorMessage = "Name must be less than 10 letters")]
		
        public string Name { get; set; }
		public string ? Image { get; set; }
		public double ? Salary { get; set; }
		public string ? Address { get; set; }

		// Foreign key
		[ForeignKey("Department")]
		public int ? DeptId { get; set; }
		public Department Department { get; set; }  // Navigation property

		// Foreign key to Course
		[ForeignKey("Course")]
		public int ? CrsId { get; set; }
		public Course Course { get; set; }  // Navigation property
	}
}
