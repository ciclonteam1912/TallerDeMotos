using System.ComponentModel.DataAnnotations;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class MontoPagoObligatorioSiEsTarjeta : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movimientoCaja = (MovimientoCajaViewModel)validationContext.ObjectInstance;

            if ((!movimientoCaja.FormaPagoTarjeta && movimientoCaja.MontoPagoTarjeta == null) ||
                (movimientoCaja.FormaPagoTarjeta && movimientoCaja.MontoPagoTarjeta != null))
                return ValidationResult.Success;
            else
                return new ValidationResult("El campo Monto de Pago es obligatorio.");
        }
    }
}