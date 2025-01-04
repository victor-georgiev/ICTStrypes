using ICTStrypes.Consts;
using System.ComponentModel.DataAnnotations;

namespace ICTStrypes.Attributes
{
    public class ChargePointStatusValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !ValidationConstants.AllowedChargePointStatuses.Contains(value.ToString()))
            {
                return new ValidationResult($"Invalid Status. Allowed values are: {string.Join(", ", ValidationConstants.AllowedChargePointStatuses)}.");
            }

            return ValidationResult.Success;
        }
    }

}
