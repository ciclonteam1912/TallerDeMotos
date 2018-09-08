using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
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
            if (User.IsInRole(RoleName.Administrador) || User.IsInRole(RoleName.JefeDeTaller) || User.IsInRole(RoleName.Mecanico))
                return View("ListaDeVehiculos");

            return View("ListaDeVehiculosSoloLectura");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult NuevoVehiculo()
        {
            var clientes = _context.Clientes.ToList();
            var aseguradoras = _context.Aseguradoras.ToList();
            var modelos = _context.Modelos.Include(m => m.Marca).ToList();
            var combustibles = _context.Combustibles.ToList();
            var tiposMotores = _context.TiposMotores.ToList();
            var cilindradas = _context.Cilindradas.ToList();

            var viewModel = new VehiculoViewModel()
            {
                Clientes = clientes,
                Aseguradoras = aseguradoras,
                Modelos = modelos,
                Combustibles = combustibles
            };

            return View("VehiculoFormulario", viewModel);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
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
                    Modelos = _context.Modelos.Include(m => m.Marca).ToList(),
                    Combustibles = _context.Combustibles.ToList()
                };

                return View("VehiculoFormulario", viewModel);
            }

            if (vehiculo.AseguradoraCodigo > 0)
            {
                var aseguradora = _context.Aseguradoras.Find(vehiculo.AseguradoraCodigo);
                _context.Aseguradoras.Attach(aseguradora);
                vehiculo.Aseguradora = aseguradora;
            }

            if (vehiculo.Id == 0)
            {                
                vehiculo.FechaDeIngreso = DateTime.Now;
                _context.Vehiculos.Add(vehiculo);
            }
            else
            {
                var vehiculosBD = _context.Vehiculos
                    .Include(v => v.Aseguradora)
                    .Single(c => c.Id == vehiculo.Id);

                Mapper.Map<Vehiculo, Vehiculo>(vehiculo, vehiculosBD);
                vehiculosBD.Aseguradora = vehiculo.Aseguradora;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult EditarVehiculo(int id)
        {
            var vehiculo = _context.Vehiculos
                .Include(v => v.Aseguradora)
                .SingleOrDefault(c => c.Id == id);

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