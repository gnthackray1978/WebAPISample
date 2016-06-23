using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCClient.Helper
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ValidateForIllegalCharsAttribute : ValidationAttribute, IClientValidatable
    {
        private const string DefaultErrorMessage = "The {0} field should not contain any of the following characters {1}";


        public string InvalidCharsProperty { get; private set; }

        public ValidateForIllegalCharsAttribute(
            string invalidChars)
            : base(DefaultErrorMessage)
        {
            
            InvalidCharsProperty = invalidChars;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {

                var charList = InvalidCharsProperty.ToCharArray();

                var invalidChars = new List<char>();

                foreach (var s in charList)
                {
                    if (value.ToString().Contains(s))
                    {
                        invalidChars.Add(s);
                    }
                }

                if (invalidChars.Count > 0)
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }

            }
            return ValidationResult.Success;

        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule()
            {
                ValidationType = "validateillegalchars",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
            };

            rule.ValidationParameters.Add("illegalcharsproperty", InvalidCharsProperty);

            yield return rule;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, InvalidCharsProperty);
        }
    }
}