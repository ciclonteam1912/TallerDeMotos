using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class RestriccionUnicaEnMarca : ValidationAttribute
    {
        private ApplicationDbContext _context;

        public RestriccionUnicaEnMarca()
        {
            _context = new ApplicationDbContext();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var marca = (Marca)validationContext.ObjectInstance;
            var className = validationContext.ObjectType.Name + 's';
            var propertyName = validationContext.MemberName;
            var parameterName = string.Format("@{0}", propertyName);

            if(value != null)
            {
                if(marca.Id != 0)
                {
                    SqlParameter parameter = new SqlParameter(parameterName, value);
                    var valorPropiedad = _context.Database.SqlQuery<int>(
                    string.Format("SELECT COUNT(*) FROM {0} WHERE CODIGO<>{1} AND {2}={3}", className, marca.Id, propertyName, parameterName),
                    parameter);

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
                        return new ValidationResult(string.Format("{0} '{1}' ya existe", validationContext.DisplayName, value),
                                    new List<string>() { propertyName });
                    }
                }                
            }            
            return null;
        }

    }
}