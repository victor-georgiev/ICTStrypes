using ICTStrypes.Consts;
using System.ComponentModel.DataAnnotations;

namespace ICTStrypes.Attributes
{
    public class LocationTypeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && !ValidationConstants.AllowedLocationTypes.Contains(value.ToString()))
            {
                return new ValidationResult($"Invalid Type. Allowed values are: {string.Join(", ", ValidationConstants.AllowedLocationTypes)}.");
            }

            return ValidationResult.Success;
        }
    }

}
