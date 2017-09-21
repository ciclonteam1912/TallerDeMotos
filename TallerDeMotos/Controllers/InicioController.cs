using System.Web.Mvc;

namespace TallerDeMotos.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Taller()
        {
            return View();
        }

        public ActionResult Ventas()
        {
            return View();
        }

        public ActionResult Compras()
        {
            return View();
        }

        public ActionResult Stock()
        {
            return View();
        }

        public ActionResult Seguridad()
        {
            return View();
        }
    }
}