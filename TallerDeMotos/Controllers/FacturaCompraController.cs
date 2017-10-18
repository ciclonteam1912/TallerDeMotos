using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;

namespace TallerDeMotos.Controllers
{
    public class FacturaCompraController : Controller
    {
        private ApplicationDbContext _context;

        public FacturaCompraController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: FacturaCompra
        public ActionResult Index()
        {
            return View("ListaDeFacturaDeCompras");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult FacturaCompraFormulario()
        {
            return View();
        }
    }
}