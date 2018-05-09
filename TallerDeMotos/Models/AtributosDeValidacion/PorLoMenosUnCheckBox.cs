using System;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class PorLoMenosUnCheckBox: ValidationAttribute
    {
        private string[] _checkboxNames;

        public PorLoMenosUnCheckBox(params string[] checkboxNames)
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
                    return new ValidationResult("Seleccione al menos una forma de pago.");
            }

            return ValidationResult.Success;
          
        }
    }
}