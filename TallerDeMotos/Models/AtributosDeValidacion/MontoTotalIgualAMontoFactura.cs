using System.ComponentModel.DataAnnotations;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class MontoTotalIgualAMontoFactura : ValidationAttribute
    {
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
    }
}