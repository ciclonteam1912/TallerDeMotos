using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class FacturaFinalMayorAFacturaInicial : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var talonario = (Talonario)validationContext.ObjectInstance;

            if (talonario.NumeroFacturaFinal > talonario.NumeroFacturaInicial)
                return ValidationResult.Success;
            else
            {
                return new ValidationResult("El número de Factura Final debe ser mayor al inicial.");
            }
        }
    }
}