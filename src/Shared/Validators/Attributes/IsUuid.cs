using System.ComponentModel.DataAnnotations;

namespace Shared.Validators.Attributes
{
    public class IsUuid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return ValidationResult.Success;

            if (Guid.TryParse(value.ToString(), out _))
                return ValidationResult.Success;

            return new ValidationResult($"The field {value} is not a valid uuid");
        }
    }
}