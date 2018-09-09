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
            var usuario = (ApplicationUser)validationContext.ObjectInstance;
            var className = "AspNetUsers";
            var propertyName = "EmpleadoCodigo";
            var parameterName = string.Format("@{0}", propertyName);

            if(value != null)
            {
                if (usuario.Password == null)
                {
                    var e = _context.Users
                        .Where(u => u.Id != usuario.Id.Trim() && u.EmpleadoId == usuario.EmpleadoId)
                        .ToList();

                    if (e.Count > 0)
                    {
                        return new ValidationResult(string.Format("{0} '{1}' ya existe", validationContext.DisplayName, value),
                                new List<string>() { propertyName });
                    }
                }
                else
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
            }         
            return null;
        }

    }
}