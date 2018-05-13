using System.ComponentModel.DataAnnotations;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class NroChequeObligatorioSiEsCheque : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movimientoCaja = (MovimientoCajaViewModel)validationContext.ObjectInstance;

            if ((!movimientoCaja.FormaPagoCheque && movimientoCaja.NroCheque == null) ||
                (movimientoCaja.FormaPagoCheque && movimientoCaja.NroCheque != null))
                return ValidationResult.Success;
            else
                return new ValidationResult("El campo Nro. de Cheque es obligatorio.");
        }
    }
}