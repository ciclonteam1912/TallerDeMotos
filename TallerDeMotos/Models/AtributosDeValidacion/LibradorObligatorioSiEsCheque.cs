using System.ComponentModel.DataAnnotations;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class LibradorObligatorioSiEsCheque : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movimientoCaja = (MovimientoCajaViewModel)validationContext.ObjectInstance;

            if ((!movimientoCaja.FormaPagoCheque && movimientoCaja.Librador == null) ||
                (movimientoCaja.FormaPagoCheque && movimientoCaja.Librador != null))
                return ValidationResult.Success;
            else
                return new ValidationResult("El campo Librador es obligatorio.");
        }
    }
}