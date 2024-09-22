using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC1.Models
{
	public class Trainee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ? Image { get; set; }
		public string ? Address { get; set; }
		public double ? Grade { get; set; }

		// Foreign key to Department

		[ForeignKey("Department")]
		public int ? DeptId { get; set; }
		public Department Department { get; set; }  // Navigation property

		// Navigation property for the result relationship
		public ICollection<crsResult> crsResults { get; set; }
	}
}
