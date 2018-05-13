using System.ComponentModel.DataAnnotations;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class NroAutorizacionObligatorioSiEsTarjeta : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movimientoCaja = (MovimientoCajaViewModel)validationContext.ObjectInstance;

            if ((!movimientoCaja.FormaPagoTarjeta && movimientoCaja.NroAutorizacion == null) ||
                (movimientoCaja.FormaPagoTarjeta && movimientoCaja.NroAutorizacion != null))
                return ValidationResult.Success;
            else
                return new ValidationResult("El campo Nro. de Autorización es obligatorio.");
        }
    }
}