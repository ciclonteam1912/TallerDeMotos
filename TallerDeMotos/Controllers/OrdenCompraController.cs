using System.Web.Mvc;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers
{
    public class OrdenCompraController : Controller
    {
        // GET: OrdenCompra
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Administrador))
                return View("ListaDeOrdenDeCompras");
            return View("ListaDeOrdenDeComprasSoloLectura");
        }

        public ActionResult OrdenCompraReport(int ordenNro = 0)
        {
            if (ordenNro != 0)
                ViewBag.OrdenNro = ordenNro;
            return View();
        }
    }
}