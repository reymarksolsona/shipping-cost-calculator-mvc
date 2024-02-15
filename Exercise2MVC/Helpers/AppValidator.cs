using Exercise2MVC.DataAccess.Context;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Exercise2MVC.Helpers
{
    public class AppValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = new Exercise2DbContext();
            var title = value as string;

            if (dbContext.Parcels.Any(p => p.Title == title))
            {
                return new ValidationResult("Title must be unique.");
            }

            return ValidationResult.Success;
        }
    }
}