using Microsoft.EntityFrameworkCore;
using MVC1.Models;

namespace MVC1.Context
{
	public class Unitxt :DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server = .\\sqlexpress ; Database = UnitxtDb ; Trusted_Connection=true;encrypt=false ");
		}
        


        public DbSet<Department> Departments { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<Trainee> Trainees { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<crsResult> crsResults { get; set; }
	}
}
