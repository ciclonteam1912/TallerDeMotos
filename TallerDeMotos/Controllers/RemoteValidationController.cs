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

        #region Remote Validation en Clientes
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

        #region Remote Validation en Vehículos
        // GET: RemoteValidation
        [HttpPost]
        public JsonResult MatriculaExisteEnVehiculos(string Matricula, string Id)
        {
            return Json(MatriculaDisponibleEnVehiculos(Matricula, Id));
        }

        public bool MatriculaDisponibleEnVehiculos(string Matricula, string Id)
        {
            // Assume these details coming from database  
            int id = int.Parse(Id);
            bool status;

            var vehiculos = _context.Vehiculos.ToList();

            if (id != 0)
            {
                var resultado = (from u in vehiculos
                                 where u.Matricula?.ToUpper() == Matricula?.ToUpper() && u.Id != id
                                 select new { Matricula })
                                 .FirstOrDefault();

                if (resultado != null)
                    status = false;
                else
                    status = true;
            }
            else
            {
                var valor = (from u in vehiculos
                             where u.Matricula?.ToUpper() == Matricula?.ToUpper()
                             select new
                             {
                                 Matricula
                             })
                             .FirstOrDefault();

                if (valor != null)
                    status = false;
                else
                    status = true;
            }
            return status;
        }

        [HttpPost]
        public JsonResult ChasisExisteEnVehiculos(string Chasis, string Id)
        {
            return Json(ChasisDisponibleEnVehiculos(Chasis, Id));
        }

        public bool ChasisDisponibleEnVehiculos(string Chasis, string Id)
        {
            // Assume these details coming from database  
            int id = int.Parse(Id);
            bool status;

            var vehiculos = _context.Vehiculos.ToList();

            if (id != 0)
            {
                var resultado = (from u in vehiculos
                                 where u.Chasis.ToUpper() == Chasis.ToUpper() && u.Id != id
                                 select new { Chasis })
                                 .FirstOrDefault();

                if (resultado != null)
                    status = false;
                else
                    status = true;
            }
            else
            {
                var valor = (from u in vehiculos
                             where u.Chasis.ToUpper() == Chasis.ToUpper()
                             select new
                             {
                                 Chasis
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

        #region Remote Validation en Aseguradoras
        // GET: RemoteValidation
        [HttpPost]
        public JsonResult RucExisteEnAseguradoras(string Ruc, string Id)
        {
            return Json(RucDisponibleEnAseguradoras(Ruc, Id));
        }

        public bool RucDisponibleEnAseguradoras(string Ruc, string Id)
        {
            // Assume these details coming from database  
            int id = int.Parse(Id);
            bool status;

            var aseguradoras = _context.Aseguradoras.ToList();

            if (id != 0)
            {
                var resultado = (from u in aseguradoras
                                 where u.Ruc?.ToUpper() == Ruc.ToUpper() && u.Id != id
                                 select new { Ruc })
                                 .FirstOrDefault();

                if (resultado != null)
                    status = false;
                else
                    status = true;
            }
            else
            {
                var valor = (from u in aseguradoras
                             where u.Ruc?.ToUpper() == Ruc.ToUpper()
                             select new
                             {
                                 Ruc
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

        #region Remote Validation en Marcas
        // GET: RemoteValidation
        [HttpPost]
        public JsonResult NombreExisteEnMarcas(string Nombre, string Id)
        {
            return Json(NombreDisponibleEnMarcas(Nombre, Id));
        }

        public bool NombreDisponibleEnMarcas(string Nombre, string Id)
        {
            // Assume these details coming from database  
            int id = int.Parse(Id);
            bool status;

            var marcas = _context.Marcas.ToList();

            if (id != 0)
            {
                var resultado = (from u in marcas
                                 where u.Nombre.ToUpper() == Nombre.Trim().ToUpper() && u.Id != id
                                 select new { Nombre })
                                 .FirstOrDefault();

                if (resultado != null)
                    status = false;
                else
                    status = true;
            }
            else
            {
                var valor = (from u in marcas
                             where u.Nombre.ToUpper() == Nombre.Trim().ToUpper()
                             select new
                             {
                                 Nombre
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

        #region Remote Validation en Modelos
        // GET: RemoteValidation
        [HttpPost]
        public JsonResult NombreExisteEnModelos(string Nombre, string Id)
        {
            return Json(NombreDisponibleEnModelos(Nombre, Id));
        }

        public bool NombreDisponibleEnModelos(string Nombre, string Id)
        {
            // Assume these details coming from database  
            int id = int.Parse(Id);
            bool status;

            var modelos = _context.Modelos.ToList();

            if (id != 0)
            {
                var resultado = (from u in modelos
                                 where u.Nombre.ToUpper() == Nombre.Trim().ToUpper() && u.Id != id
                                 select new { Nombre })
                                 .FirstOrDefault();

                if (resultado != null)
                    status = false;
                else
                    status = true;
            }
            else
            {
                var valor = (from u in modelos
                             where u.Nombre.ToUpper() == Nombre.Trim().ToUpper()
                             select new
                             {
                                 Nombre
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

        #region Remote Validation en Proveedores
        // GET: RemoteValidation
        [HttpPost]
        public JsonResult RucExisteEnProveedores(string Ruc, string Id)
        {
            return Json(RucDisponibleEnProveedores(Ruc, Id));
        }

        public bool RucDisponibleEnProveedores(string Ruc, string Id)
        {
            int id = int.Parse(Id);
            bool status;

            var proveedores = _context.Proveedores.ToList();

            if (id != 0)
            {
                var resultado = (from u in proveedores
                                 where u.Ruc?.ToUpper() == Ruc?.ToUpper() && u.Id != id
                                 select new { Ruc })
                                 .FirstOrDefault();

                if (resultado != null)
                    status = false;
                else
                    status = true;
            }
            else
            {
                var valor = (from u in proveedores
                             where u.Ruc?.ToUpper() == Ruc?.ToUpper()
                             select new
                             {
                                 Ruc
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