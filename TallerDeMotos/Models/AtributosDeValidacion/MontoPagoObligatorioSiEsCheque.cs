using System.ComponentModel.DataAnnotations;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class MontoPagoObligatorioSiEsCheque : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movimientoCaja = (MovimientoCajaViewModel)validationContext.ObjectInstance;

            if ((!movimientoCaja.FormaPagoCheque && movimientoCaja.MontoPagoCheque == null) ||
                (movimientoCaja.FormaPagoCheque && movimientoCaja.MontoPagoCheque != null))
                return ValidationResult.Success;
            else
                return new ValidationResult("El campo Monto de Pago es obligatorio.");
        }
    }
}