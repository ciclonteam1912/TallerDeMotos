using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class RestriccionUnicaEnEmpleado : ValidationAttribute
    {
        private ApplicationDbContext _context;

        public RestriccionUnicaEnEmpleado()
        {
            _context = new ApplicationDbContext();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var empleado = (Empleado)validationContext.ObjectInstance;
            var className = validationContext.ObjectType.Name + 's';
            var propertyName = validationContext.MemberName;
            var parameterName = string.Format("@{0}", propertyName);

            if(value != null)
            {
                var result = _context.Database.SqlQuery<int>(
                string.Format("SELECT COUNT(*) FROM {0} WHERE {1}={2}", className, propertyName, parameterName),
                new System.Data.SqlClient.SqlParameter(parameterName, value));
                if (result.ToList()[0] > 0)
                {
                    return new ValidationResult(string.Format("{0} '{1}' ya existe", validationContext.DisplayName, value),
                                new List<string>() { propertyName });
                }
            }            
            return null;
        }

    }
}