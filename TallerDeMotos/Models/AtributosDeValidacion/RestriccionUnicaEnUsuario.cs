using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class RestriccionUnicaEnUsuario : ValidationAttribute
    {
        private ApplicationDbContext _context;

        public RestriccionUnicaEnUsuario()
        {
            _context = new ApplicationDbContext();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var vehiculo = (ApplicationUser)validationContext.ObjectInstance;
            var className = "AspNetUsers";
            var propertyName = "EmpleadoCodigo";
            var parameterName = string.Format("@{0}", propertyName);

            if(value != null)
            {
                var result = _context.Database.SqlQuery<int>(
                string.Format("SELECT COUNT(*) FROM {0} WHERE {1}={2}", className, propertyName, parameterName),
                new System.Data.SqlClient.SqlParameter(parameterName, value));
                if (result.ToList()[0] > 0)
                {
                    return new ValidationResult(string.Format("Empleado ya tiene asignado un usuario"),
                                new List<string>() { propertyName });
                }
            }            
            return null;
        }

    }
}