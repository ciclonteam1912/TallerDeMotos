using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class MayorACero: ValidationAttribute, IClientValidatable
    {
        private ApplicationDbContext _context;
        private string _propiedad;

        public MayorACero()
        {
            _context = new ApplicationDbContext();
        }

        public MayorACero(string propiedad) : base("El campo {0} debe ser mayor a cero.")
        {
            _propiedad = propiedad;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var className = validationContext.ObjectType.Name;
            var propertyDisplayName = validationContext.DisplayName;

            if(value != null && int.Parse(value.ToString()) > 0)
            {
                return ValidationResult.Success; ;
            }
            else
            {
                return new ValidationResult("El campo "+ propertyDisplayName.ToString() + " debe ser mayor a cero.");
            }
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationType = "mayoracero";
            rule.ValidationParameters.Add("valor", _propiedad) ;
            yield return rule;
        }
    }
}