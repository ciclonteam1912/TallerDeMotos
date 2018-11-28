using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Filters;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    public class ProveedorController : Controller
    {
        private ApplicationDbContext _context;
        private ConexionBD _conexionBd;

        public ProveedorController()
        {
            _context = new ApplicationDbContext();
            _conexionBd = new ConexionBD();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Proveedor
        public ActionResult Index()
        {
            string usuario = User.Identity.Name;
            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Crear Proveedor") || usuario.Equals("admin"))
                ViewBag.CrearProveedor = true;
            else
                ViewBag.CrearProveedor = false;

            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Editar Proveedor") || usuario.Equals("admin"))
                ViewBag.EditarProveedor = true;
            else
                ViewBag.EditarProveedor = false;

            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Eliminar Proveedor") || usuario.Equals("admin"))
                ViewBag.EliminarProveedor = true;
            else
                ViewBag.EliminarProveedor = false;

            return View("ListaDeProveedores");
        }

        [HasPermission("Crear Proveedor")]
        public ActionResult NuevoProveedor()
        {
            var ciudades = _context.Ciudades.ToList();

            var viewModel = new ProveedorViewModel()
            {
                Ciudades = ciudades
            };

            return View("ProveedorFormulario", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarProveedor(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProveedorViewModel(proveedor)
                {
                    Ciudades = _context.Ciudades.ToList()
                };
                return View("ProveedorFormulario", viewModel);
            }                

            if (proveedor.Id == 0)
                _context.Proveedores.Add(proveedor);
            else
            {
                var proveedorBD = _context.Proveedores.Single(p => p.Id == proveedor.Id);
                Mapper.Map<Proveedor, Proveedor>(proveedor, proveedorBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HasPermission("Editar Proveedor")]
        public ActionResult EditarProveedor(int id)
        {
            var proveedorBD = _context.Proveedores.SingleOrDefault(p => p.Id == id);
            var proveedorContactosBD = _context.ProveedorContactos
                .Include(pc => pc.Contacto)
                .Where(pc => pc.ProveedorId == id)
                .ToList();

            if (proveedorBD == null)
                return HttpNotFound();          

            var viewModel = new ProveedorViewModel(proveedorBD)
            {
                Ciudades = _context.Ciudades.ToList(),
                ProveedorContactos = proveedorContactosBD
            };

            return View("ProveedorFormulario", viewModel);
        }

        [HasPermission("Editar Proveedor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProveedor(ProveedorViewModel proveedor)
        {
            var proveedorBD = _context.Proveedores.SingleOrDefault(p => p.Id == proveedor.Id);

            if (!ModelState.IsValid)
            {
                var proveedorContactosBD = _context.ProveedorContactos
                .Include(pc => pc.Contacto)
                .Where(pc => pc.ProveedorId == proveedor.Id)
                .ToList();

                var viewModel = new ProveedorViewModel(proveedorBD)
                {
                    Ciudades = _context.Ciudades.ToList(),
                    ProveedorContactos = proveedorContactosBD
                };

                return View(viewModel);
            }
                

            //editar proveedor existente
            //var proveedorBD = _context.Proveedores.Single(p => p.Id == proveedor.Id);
            Mapper.Map<ProveedorViewModel, Proveedor>(proveedor, proveedorBD);

            var proveedorContactosExistentes = _context.ProveedorContactos
                .Where(pc => pc.ProveedorId == proveedor.Id)
                .ToList();

            var contactosAgregados = proveedor.ProveedorContactos
                .Where(pc => !proveedorContactosExistentes.Any(pc2 => pc2.Id == pc.Id))
                .ToList();

            var contactosEliminados = proveedorContactosExistentes
                .Where(pc => !proveedor.ProveedorContactos.Any(pc2 => pc2.Id == pc.Id))
                .ToList();

            foreach (var item in contactosAgregados)
            {
                var proveedorContacto = Mapper.Map<ProveedorContacto, ProveedorContacto>(item);
                _context.ProveedorContactos.Add(proveedorContacto);
            }

            if (contactosEliminados.Count > 0)
            {
                foreach (var item in contactosEliminados)
                {
                    var proveedorContacto = Mapper.Map<ProveedorContacto, ProveedorContacto>(item);
                    contactosEliminados.ForEach(c => _context.ProveedorContactos.Remove(item));
                }

            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeudasProveedoresReport()
        {
            return View("DeudasProveedoresReport");
        }
    }
}