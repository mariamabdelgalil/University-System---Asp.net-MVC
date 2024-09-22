using System.ComponentModel.DataAnnotations;
using MVC1.Context;


namespace MVC1.Validation
{
    public class UniqueName : ValidationAttribute
    {

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			Unitxt db = new Unitxt();
			if (db.Courses.Any(e => e.Name == value as string))
			{
				return new ValidationResult("Name Already Exist !!!");
			}
			return ValidationResult.Success;

		}
	}
}