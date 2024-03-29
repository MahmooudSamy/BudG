using System.ComponentModel.DataAnnotations;

namespace BudG.Domain.CustomAttribute
{
    public class ExcludeChar : ValidationAttribute
    {
      private  string _characters;
        public ExcludeChar(string Characters)
        {
            _characters = Characters;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                for (int i = 0; i < _characters.Length; i++)
                {
                    var valueAsString = value.ToString();
                    if (valueAsString.Contains(_characters[i]))
                    {
                        var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                        return new ValidationResult(errorMessage);
                    }
                }
            }
            return ValidationResult.Success;
        }

    }
}
