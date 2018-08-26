using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers
{
    public class RemoteValidationController : Controller
    {
        private ApplicationDbContext _context;

        public RemoteValidationController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: RemoteValidation
        [HttpPost]
        public JsonResult NumeroDocumentoExiste(string NumeroDocumento, string Id)
        {
            return Json(NumeroDocumentoDisponible(NumeroDocumento, Id));
        }

        public bool NumeroDocumentoDisponible(string NumeroDocumento, string Id)
        {
            // Assume these details coming from database  
            int id = int.Parse(Id);
            bool status;

           var empleados = _context.Empleados.ToList();

            if(id != 0)
            {
                var resultado = (from u in empleados
                                 where u.NumeroDocumento.ToUpper() == NumeroDocumento.ToUpper() && u.Id != id
                                 select new { NumeroDocumento })
                                 .FirstOrDefault();

                if (resultado != null)
                    status = false;
                else
                    status = true;                        
            }
            else
            {
                var valor = (from u in empleados
                             where u.NumeroDocumento.ToUpper() == NumeroDocumento.ToUpper()
                             select new
                             {
                                 NumeroDocumento
                             })
                                    .FirstOrDefault();

                if (valor != null)
                    status = false;
                else
                    status = true;
            }
            

            return status;
        }
    }
}