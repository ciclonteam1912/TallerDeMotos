using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class PrecioVentaMayorPrecioCosto : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var producto = (Producto)validationContext.ObjectInstance;

            if (producto.PrecioVenta >= producto.PrecioCosto)
                return ValidationResult.Success;
            else
                return new ValidationResult("El precio de venta debe ser mayor o igual al precio de costo.");
        }
    }
}