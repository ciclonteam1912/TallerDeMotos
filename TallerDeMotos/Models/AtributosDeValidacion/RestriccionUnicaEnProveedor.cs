using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class RestriccionUnicaEnProveedor : ValidationAttribute
    {
        private ApplicationDbContext _context;

        public RestriccionUnicaEnProveedor()
        {
            _context = new ApplicationDbContext();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var proveedor = (Proveedor)validationContext.ObjectInstance;
            var className = validationContext.ObjectType.Name + "es";
            var propertyName = validationContext.MemberName;
            var parameterName = string.Format("@{0}", propertyName);

            if(value != null)
            {
                if (proveedor.Id != 0)
                {
                    var valorPropiedad = _context.Database.SqlQuery<int>(
                    string.Format("SELECT COUNT(*) FROM {0} WHERE CODIGO<>{1} AND {2}={3}", className, proveedor.Id, propertyName, parameterName),
                    new System.Data.SqlClient.SqlParameter(parameterName.Clone().ToString(), value));

                    if (valorPropiedad.ToList()[0] > 0)
                        return new ValidationResult(string.Format("{0} '{1}' ya existe", validationContext.DisplayName, value),
                                new List<string>() { propertyName });
                }
                else
                {
                    var result = _context.Database.SqlQuery<int>(
                    string.Format("SELECT COUNT(*) FROM {0} WHERE {1}={2}", className, propertyName, parameterName),
                    new System.Data.SqlClient.SqlParameter(parameterName, value));
                    if (result.ToList()[0] > 0)
                    {
                        return new ValidationResult(string.Format("{0} '{1}' ya existe", propertyName, value),
                                    new List<string>() { propertyName });
                    }
                }
            }                   
            return null;
        }

    }
}