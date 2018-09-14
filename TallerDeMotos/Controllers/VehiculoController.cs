using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Filters;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;


namespace TallerDeMotos.Controllers
{
    public class VehiculoController : Controller
    {
        private ApplicationDbContext _context;
        private ConexionBD _conexionBd;

        public VehiculoController()
        {
            _context = new ApplicationDbContext();
            _conexionBd = new ConexionBD();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Vehiculo
        public ActionResult Index()
        {
            string usuario = User.Identity.Name;
            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Crear Vehículo") || usuario.Equals("admin"))
                ViewBag.CrearVehiculo = true;
            else
                ViewBag.CrearVehiculo = false;

            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Editar Vehículo") || usuario.Equals("admin"))
                ViewBag.EditarVehiculo = true;
            else
                ViewBag.EditarVehiculo = false;

            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Eliminar Vehículo") || usuario.Equals("admin"))
                ViewBag.EliminarVehiculo = true;
            else
                ViewBag.EliminarVehiculo = false;

            return View("ListaDeVehiculos");
        }

        [HasPermission("Crear Vehículo")]
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

        [HasPermission("Editar Vehículo")]
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