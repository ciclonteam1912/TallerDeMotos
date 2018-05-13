using System.ComponentModel.DataAnnotations;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class BancoObligatorioSiEsTarjeta : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movimientoCaja = (MovimientoCajaViewModel)validationContext.ObjectInstance;

            if ((!movimientoCaja.FormaPagoTarjeta && movimientoCaja.BancoIdTarjeta == null) ||
                (movimientoCaja.FormaPagoTarjeta && movimientoCaja.BancoIdTarjeta != null))
                return ValidationResult.Success;
            else
                return new ValidationResult("El campo Bancos es obligatorio.");
        }
    }
}