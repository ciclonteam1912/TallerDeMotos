using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class MontoTotalIgualAMontoFactura : ValidationAttribute, IClientValidatable
    {
        public string OtraPropiedad { get; set; }

        public MontoTotalIgualAMontoFactura(string otraPropiedad) : base("El monto total no coincide con el monto de la factura.")
        {
            OtraPropiedad = otraPropiedad;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movimientoCaja = (MovimientoCajaViewModel)validationContext.ObjectInstance;

            if (movimientoCaja.Monto == movimientoCaja.MontoFactura)
                return ValidationResult.Success;
            else
            {
                return new ValidationResult("El monto total no coincide con el monto de la factura.");
            }
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationType = "montototaligualamontofactura";
            rule.ValidationParameters.Add("otra", OtraPropiedad);
            yield return rule;
        }
    }
}