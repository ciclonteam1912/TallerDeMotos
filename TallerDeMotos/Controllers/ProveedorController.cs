using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers
{
    public class ProveedorController : Controller
    {
        private ApplicationDbContext _context;

        public ProveedorController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Proveedor
        public ActionResult Index()
        {
            return View("ListaDeProveedores");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult NuevoProveedor()
        {
            var proveedor = new Proveedor();

            return View("ProveedorFormulario", proveedor);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarProveedor(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View("ProveedorFormulario", proveedor);

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

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult EditarProveedor(int id)
        {
            var proveedorBD = _context.Proveedores.SingleOrDefault(p => p.Id == id);

            if (proveedorBD == null)
                return HttpNotFound();

            var proveedor = new Proveedor(proveedorBD);

            return View("ProveedorFormulario", proveedor);
        }
    }
}