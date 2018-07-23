using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class RestriccionUnicaEnCaja : ValidationAttribute
    {
        private ApplicationDbContext _context;

        public RestriccionUnicaEnCaja()
        {
            _context = new ApplicationDbContext();
        }



        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var caja = (Caja)validationContext.ObjectInstance;
            var className = validationContext.ObjectType.Name + 's';
            var propertyName = validationContext.MemberName;
            var parameterName = string.Format("@{0}", propertyName);

            if(caja.Id == 0 && value != null)
            {
                var result = _context.Database.SqlQuery<int>(
                string.Format("SELECT COUNT(*) FROM {0} WHERE {1}={2}", className, propertyName, parameterName),
                new System.Data.SqlClient.SqlParameter(parameterName, value));
                if (result.ToList()[0] > 0)
                {
                    return new ValidationResult(string.Format("Usuario ya tiene asignado una caja."),
                                new List<string>() { propertyName });
                }
            }            
            return null;
        }

    }
}