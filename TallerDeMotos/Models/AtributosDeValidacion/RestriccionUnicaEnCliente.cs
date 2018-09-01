using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class RestriccionUnicaEnCliente : ValidationAttribute
    {
        private ApplicationDbContext _context;

        public RestriccionUnicaEnCliente()
        {
            _context = new ApplicationDbContext();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cliente = (Cliente)validationContext.ObjectInstance;
            var className = validationContext.ObjectType.Name + 's';
            var propertyName = validationContext.MemberName;
            var parameterName = string.Format("@{0}", propertyName);

            if(value != null)
            {
                if(cliente.Id != 0)
                {
                    var numeroDocumento = _context.Database.SqlQuery<string>(
                    string.Format("SELECT VALORDOCUMENTO FROM {0} WHERE CODIGO<>{1}", className, cliente.Id));

                    if(numeroDocumento.ToList().Count > 0)
                    {
                        if (cliente.ValorDocumento == numeroDocumento.ToList()[0])
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
                        return new ValidationResult(string.Format("{0} '{1}' ya existe", validationContext.DisplayName, value),
                                    new List<string>() { propertyName });
                    }
                }                
            }            
            return null;
        }

    }
}