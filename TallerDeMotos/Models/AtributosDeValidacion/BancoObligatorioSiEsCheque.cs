using System.ComponentModel.DataAnnotations;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class BancoObligatorioSiEsCheque : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movimientoCaja = (MovimientoCajaViewModel)validationContext.ObjectInstance;

            if ((!movimientoCaja.FormaPagoCheque && movimientoCaja.BancoIdCheque == null) ||
                (movimientoCaja.FormaPagoCheque && movimientoCaja.BancoIdCheque != null))
                return ValidationResult.Success;
            else
                return new ValidationResult("El campo Bancos es obligatorio.");
        }
    }
}