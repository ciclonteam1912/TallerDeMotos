using System.Web.Mvc;
using TallerDeMotos.Models;

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

        public ActionResult FacturaCompraFormulario()
        {
            return View();
        }
    }
}