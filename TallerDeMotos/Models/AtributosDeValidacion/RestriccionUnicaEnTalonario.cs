﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models.AtributosDeValidacion
{
    public class RestriccionUnicaEnTalonario : ValidationAttribute
    {
        private ApplicationDbContext _context;

        public RestriccionUnicaEnTalonario()
        {
            _context = new ApplicationDbContext();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var talonario = (Talonario)validationContext.ObjectInstance;
            var className = validationContext.ObjectType.Name + 's';
            var propertyName = validationContext.MemberName;
            var parameterName = string.Format("@{0}", propertyName);

            if (talonario.Id == 0 && value != null)
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
            return null;
        }
    }
}