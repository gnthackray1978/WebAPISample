using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCClient.Helper
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ValidateAgeAttribute : ValidationAttribute, IClientValidatable
    {
        private const string DefaultErrorMessage = "Your age is invalid, your age should be 18 or over";

        
        public DateTime AgeRequirementProperty { get; private set; }

        public ValidateAgeAttribute(
            int ageRequirementProperty)
            : base(DefaultErrorMessage)
        {
            AgeRequirementProperty = DateTime.Now.AddYears(ageRequirementProperty * -1);
      
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime parsedValue = (DateTime)value;

                if (parsedValue >= AgeRequirementProperty)
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
                ValidationType = "validateage",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
            };

            rule.ValidationParameters.Add("agerequirementproperty", AgeRequirementProperty.ToShortDateString());

            yield return rule;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, AgeRequirementProperty.ToShortDateString());
        }
    }
}