using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class ExistenciaMinMenorExistenciaInicial : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var producto = (Producto)validationContext.ObjectInstance;

            if (producto.ExistenciaMinima <= producto.ExistenciaInicial)
                return ValidationResult.Success;
            else
            {
                return new ValidationResult("La existencia mínima debe ser menor o igual a la existencia inicial.");
            }
        }
    }
}