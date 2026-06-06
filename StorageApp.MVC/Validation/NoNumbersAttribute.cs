using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StorageApp.MVC.Validation
{
    public class NoNumbersAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            string text = value.ToString();

            if (Regex.IsMatch(text, @"\d"))
            {
                return new ValidationResult("Назва не повинна містити цифри");
            }

            return ValidationResult.Success;
        }
    }
}
