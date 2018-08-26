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

namespace TallerDeMotos.Controllers
{
    public class EmpleadoController : Controller
    {
        private ApplicationDbContext _context;

        public EmpleadoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Empleado
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Administrador) || User.IsInRole(RoleName.JefeDeTaller))
                return View("ListaDeEmpleados");

            return View("ListaDeEmpleadosSoloLectura");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
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

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
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

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
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