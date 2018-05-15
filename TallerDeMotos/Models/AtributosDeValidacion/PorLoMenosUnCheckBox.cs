using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class PorLoMenosUnCheckBox: ValidationAttribute, IClientValidatable
    {
        private string[] _checkboxNames;

        public PorLoMenosUnCheckBox(params string[] checkboxNames) : base("Seleccione al menos una forma de pago.")
        {
            _checkboxNames = checkboxNames;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                bool isAnyChecked = false;
                if (Convert.ToBoolean(value))
                {
                    isAnyChecked = true;
                }
                else
                {
                    foreach (string strProperty in _checkboxNames)
                    {
                        var curProperty = validationContext.ObjectInstance.GetType().GetProperty(strProperty);
                        var curPropertyValue = curProperty.GetValue(validationContext.ObjectInstance, null);
                        if (Convert.ToBoolean(curPropertyValue))
                        {
                            isAnyChecked = true;
                            break;
                        }
                    }
                }
                if (!isAnyChecked)
                    return new ValidationResult(FormatErrorMessage("Seleccione al menos una forma de pago."));
            }

            return ValidationResult.Success;
          
        }


        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationType = "porlomenosuncheckbox";
            for (int i = 0; i < _checkboxNames.Length; i++)
            {
                rule.ValidationParameters.Add("otherproperty" + i.ToString(), _checkboxNames[i]);
            }
            yield return rule;
        }
    }
}