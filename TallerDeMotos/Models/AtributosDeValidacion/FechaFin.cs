using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class FechaFinMayorFechaInicio : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var talonario = (Talonario)validationContext.ObjectInstance;

            if (talonario.FechaFinVigencia > talonario.FechaInicioVigencia)
                return ValidationResult.Success;
            else
            {
                return new ValidationResult("La Fecha Fin de vigencia debe ser mayor a la Fecha de Inicio de vigencia");
            }
        }
    }
}