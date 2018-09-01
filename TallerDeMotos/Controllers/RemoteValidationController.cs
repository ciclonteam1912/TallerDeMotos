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

        #region Remote Validation en Empleados
        // GET: RemoteValidation
        [HttpPost]
        public JsonResult NumeroDocumentoExisteEnEmpleados(string NumeroDocumento, string Id)
        {
            return Json(NumeroDocumentoDisponibleEnEmpleados(NumeroDocumento, Id));
        }

        public bool NumeroDocumentoDisponibleEnEmpleados(string NumeroDocumento, string Id)
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
        #endregion

        #region Remote Validation en Empleados
        // GET: RemoteValidation
        [HttpPost]
        public JsonResult NumeroDocumentoExisteEnClientes(string ValorDocumento, string Id)
        {
            return Json(NumeroDocumentoDisponibleEnClientes(ValorDocumento, Id));
        }

        public bool NumeroDocumentoDisponibleEnClientes(string ValorDocumento, string Id)
        {
            // Assume these details coming from database  
            int id = int.Parse(Id);
            bool status;

            var clientes = _context.Clientes.ToList();

            if (id != 0)
            {
                var resultado = (from u in clientes
                                 where u.ValorDocumento.ToUpper() == ValorDocumento.ToUpper() && u.Id != id
                                 select new { ValorDocumento })
                                 .FirstOrDefault();

                if (resultado != null)
                    status = false;
                else
                    status = true;
            }
            else
            {
                var valor = (from u in clientes
                             where u.ValorDocumento.ToUpper() == ValorDocumento.ToUpper()
                             select new
                             {
                                 ValorDocumento
                             })
                                    .FirstOrDefault();

                if (valor != null)
                    status = false;
                else
                    status = true;
            }
            return status;
        }
        #endregion
    }
}