using System.ComponentModel.DataAnnotations;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class ObligatorioSiEsEfectivo : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movimientoCaja = (MovimientoCajaViewModel)validationContext.ObjectInstance;

            if ((!movimientoCaja.FormaPagoEfectivo && movimientoCaja.MontoPagoEfectivo == null) ||
                movimientoCaja.FormaPagoEfectivo && movimientoCaja.MontoPagoEfectivo != null)
                return ValidationResult.Success;
            else
                return new ValidationResult("Este campo es requerido");
        }
    }
}