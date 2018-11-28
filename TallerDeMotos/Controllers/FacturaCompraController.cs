using System.Web.Mvc;
using TallerDeMotos.Filters;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers
{
    public class FacturaCompraController : Controller
    {
        private ApplicationDbContext _context;
        private ConexionBD _conexionBD;

        public FacturaCompraController()
        {
            _context = new ApplicationDbContext();
            _conexionBD = new ConexionBD();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: FacturaCompra
        public ActionResult Index()
        {
            string usuario = User.Identity.Name;
            if (_conexionBD.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Crear Factura de Compra") || usuario.Equals("admin"))
                ViewBag.CrearFacturaCompra = true;
            else
                ViewBag.CrearFacturaCompra = false;

            return View("ListaDeFacturaDeCompras");
        }

        [HasPermission("Crear Factura de Compra")]
        public ActionResult FacturaCompraFormulario()
        {
            return View();
        }
    }
}