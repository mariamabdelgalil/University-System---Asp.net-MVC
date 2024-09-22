using System.ComponentModel.DataAnnotations.Schema;

namespace MVC1.Models
{
	public class crsResult
	{
		public int Id { get; set; }
		public double Degree { get; set; }

		// Foreign key to Course
		[ForeignKey("Course")]
		public int ? CrsId { get; set; }
		public Course Course { get; set; }  // Navigation property

		// Foreign key to Trainee
		[ForeignKey("Trainee")]
		public int ? TraineeId { get; set; }
		public Trainee Trainee { get; set; }  // Navigation property
	}
}
