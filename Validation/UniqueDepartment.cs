using System.ComponentModel.DataAnnotations;
using MVC1.Context;
using MVC1.Validation;

namespace MVC1.Validation
{
	public class UniqueDep : ValidationAttribute
	{

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			Unitxt db = new Unitxt();
			if (db.Departments.Any(c => c.DeptName == value as string))
			{
				return new ValidationResult("Name Already Exist !!!");
			}
			return ValidationResult.Success;

		}
	}
}