using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public enum Comparison
    {
        IsEqualTo,
        IsNotEqualTo
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class RequiredIf : ValidationAttribute, IClientValidatable
    {
        private const string DefaultErrorMessageFormatString = "El campo {0} es obligatorio.";

        public string OtraPropiedad { get; set; }
        public Comparison Comparison { get; private set; }
        public object Value { get; private set; }

        public RequiredIf(string otraPropiedad, Comparison comparison, object value)
        {
            OtraPropiedad = otraPropiedad;
            Comparison = comparison;
            Value = value;
            ErrorMessage = DefaultErrorMessageFormatString;
        }

        private bool Validate(object actualPropertyValue)
        {
            switch (Comparison)
            {
                case Comparison.IsEqualTo:
                    return actualPropertyValue == null || !actualPropertyValue.Equals(Value);
                default:
                    return actualPropertyValue != null && actualPropertyValue.Equals(Value);
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                var property = validationContext.ObjectInstance.GetType()
                                .GetProperty(OtraPropiedad);

                var propertyValue = property.GetValue(validationContext.ObjectInstance, null);

                if (!Validate(propertyValue))
                {
                    return new ValidationResult(
                      string.Format(ErrorMessageString, validationContext.DisplayName));
                }
            }
            return ValidationResult.Success;           
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = string.Format(ErrorMessageString, metadata.GetDisplayName());
            rule.ValidationType = "requiredif";
            rule.ValidationParameters.Add("otro", OtraPropiedad);
            rule.ValidationParameters.Add("comp", Comparison.ToString().ToLower());
            rule.ValidationParameters.Add("value", Value.ToString().ToLower());
            yield return rule;
        }
    }
}