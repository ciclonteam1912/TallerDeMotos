using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    public class VehiculoController : Controller
    {
        private ApplicationDbContext _context;

        public VehiculoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Vehiculo
        public ActionResult Index()
        {
            return View("ListaDeVehiculos");
        }

        public ActionResult NuevoVehiculo()
        {
            var clientes = _context.Clientes.ToList();
            var aseguradoras = _context.Aseguradoras.ToList();
            var modelos = _context.Modelos.ToList();
            var combustibles = _context.Combustibles.ToList();

            var viewModel = new VehiculoViewModel()
            {
                Clientes = clientes,
                Aseguradoras = aseguradoras,
                Modelos = modelos,
                Combustibles = combustibles
            };

            return View("VehiculoFormulario", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarVehiculo(Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new VehiculoViewModel(vehiculo)
                {
                    Clientes = _context.Clientes.ToList(),
                    Aseguradoras = _context.Aseguradoras.ToList(),
                    Modelos = _context.Modelos.ToList(),
                    Combustibles = _context.Combustibles.ToList()
                };

                return View("VehiculoFormulario", viewModel);
            }

            if (vehiculo.Id == 0)
            {
                vehiculo.FechaDeIngreso = DateTime.Now;
                _context.Vehiculos.Add(vehiculo);
            }
            else
            {
                var vehiculosBD = _context.Vehiculos.Single(c => c.Id == vehiculo.Id);
                Mapper.Map<Vehiculo, Vehiculo>(vehiculo, vehiculosBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EditarVehiculo(int id)
        {
            var vehiculo = _context.Vehiculos.SingleOrDefault(c => c.Id == id);

            if (vehiculo == null)
                return HttpNotFound();

            var viewModel = new VehiculoViewModel(vehiculo)
            {
                Clientes = _context.Clientes.ToList(),
                Aseguradoras = _context.Aseguradoras.ToList(),
                Modelos = _context.Modelos.ToList(),
                Combustibles = _context.Combustibles.ToList()
            };

            return View("VehiculoFormulario", viewModel);
        }
    }
}