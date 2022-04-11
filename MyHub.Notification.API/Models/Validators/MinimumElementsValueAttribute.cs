using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MyHub.Notification.API.Models.Validators
{
    public class MinimumElementsValueAttribute : ValidationAttribute
    {
        public MinimumElementsValueAttribute()
        {
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (!(value is IEnumerable enumerable))
            {
                return new ValidationResult($"The {validationContext.DisplayName} field is required.");
            }

            IEnumerator enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (enumerator.Current == null || (int)enumerator.Current == 0)
                {
                    return new ValidationResult($"Invalid value for {validationContext.DisplayName} field.");
                }
            }
            return ValidationResult.Success;
        }
    }
}