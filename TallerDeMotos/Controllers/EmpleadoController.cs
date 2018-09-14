using AutoMapper;
using System;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;
using System.Web.Routing;
using System.Globalization;
using System.Threading;
using TallerDeMotos.Filters;

namespace TallerDeMotos.Controllers
{
    public class EmpleadoController : Controller
    {
        private ApplicationDbContext _context;
        private ConexionBD _conexionBd;

        public EmpleadoController()
        {
            _context = new ApplicationDbContext();
            _conexionBd = new ConexionBD();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Empleado
        public ActionResult Index()
        {
            string usuario = User.Identity.Name;
            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Crear Empleado") || usuario.Equals("admin"))
                ViewBag.CrearEmpleado = true;
            else
                ViewBag.CrearEmpleado = false;

            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Editar Empleado") || usuario.Equals("admin"))
                ViewBag.EditarEmpleado = true;
            else
                ViewBag.EditarEmpleado = false;

            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Eliminar Empleado") || usuario.Equals("admin"))
                ViewBag.EliminarEmpleado = true;
            else
                ViewBag.EliminarEmpleado = false;

            return View("ListaDeEmpleados");
        }

        [HasPermission("Crear Empleado")]
        public ActionResult NuevoEmpleado()
        {
            var cargos = _context.Cargos.ToList();
            var ciudades = _context.Ciudades.ToList();

            var viewModel = new EmpleadoViewModel()
            {
                Cargos = cargos,
                Ciudades = ciudades
            };

            return View("EmpleadoFormulario", viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarEmpleado(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EmpleadoViewModel(empleado)
                {
                    Cargos = _context.Cargos.ToList(),
                    Ciudades = _context.Ciudades.ToList()
                };

                return View("EmpleadoFormulario", viewModel);
            }

            empleado.FechaDeNacimiento = DateTime.Parse(empleado.Fecha);
            if (empleado.Id == 0)
            {
                empleado.FechaDeIngreso = DateTime.Now;
                _context.Empleados.Add(empleado);
            }
            else
            {
                var empleadoBD = _context.Empleados.Single(c => c.Id == empleado.Id);
                Mapper.Map<Empleado, Empleado>(empleado, empleadoBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HasPermission("Editar Empleado")]
        public ActionResult EditarEmpleado(int id)
        {
            var empleado = _context.Empleados.SingleOrDefault(c => c.Id == id);

            if (empleado == null)
                return HttpNotFound();

            var viewModel = new EmpleadoViewModel(empleado)
            {
                Cargos = _context.Cargos.ToList(),
                Ciudades = _context.Ciudades.ToList()
            };

            viewModel.Fecha = viewModel.FechaDeNacimiento.ToString();
            return View("EmpleadoFormulario", viewModel);
        }
    }
}