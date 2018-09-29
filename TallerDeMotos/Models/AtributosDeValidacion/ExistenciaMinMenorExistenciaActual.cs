using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class ExistenciaMinMenorExistenciaActual : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var producto = (Producto)validationContext.ObjectInstance;

            if(producto.ProductoTipoId != 2)
            {
                if ((producto.ExistenciaMinima <= producto.ExistenciaActual) || (producto.ExistenciaActual == null && producto.ExistenciaMinima == null))
                    return ValidationResult.Success;
                else
                {
                    return new ValidationResult("La existencia mínima debe ser menor o igual a la existencia actual.");
                }
            }
            return ValidationResult.Success;
        }
    }
}