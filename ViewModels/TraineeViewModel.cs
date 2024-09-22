namespace MVC1.ViewModels
{
    public class TraineeViewModel
    {
        public int TraineeId { get; set; }
        public string TraineeName { get; set; }
        public string DepartmentName { get; set; }
        public string? Address { get; set; }

        public string Image { get; set; }
        public List<CourseResultViewModel> Courses { get; set; } = new List<CourseResultViewModel>();
    }

    public class CourseResultViewModel
    {
        public string CourseName { get; set; }
        public double Grade { get; set; }
        public double MinimumGrade { get; set; }  // Assuming this is stored in the Course model
    }
}
