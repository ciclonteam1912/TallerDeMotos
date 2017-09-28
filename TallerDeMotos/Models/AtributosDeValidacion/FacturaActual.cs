using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class FacturaActual : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var talonario = (Talonario)validationContext.ObjectInstance;

            if (talonario.NumeroFacturaActual >= talonario.NumeroFacturaInicial && talonario.NumeroFacturaActual <= talonario.NumeroFacturaFinal)
                return ValidationResult.Success;
            else
            {
                return new ValidationResult("La Factura Actual debe estar comprendida entre la Factura Inicial y Factura Final");
            }
        }
    }
}