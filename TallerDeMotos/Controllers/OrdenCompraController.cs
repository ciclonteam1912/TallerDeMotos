using System.Web.Mvc;

namespace TallerDeMotos.Controllers
{
    public class OrdenCompraController : Controller
    {
        // GET: OrdenCompra
        public ActionResult Index()
        {
            return View("OrdenCompraFormulario");
        }

        public ActionResult OrdenCompraReport(int ordenNro = 0)
        {
            if (ordenNro != 0)
                ViewBag.OrdenNro = ordenNro;
            return View();
        }
    }
}