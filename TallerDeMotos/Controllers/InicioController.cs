using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;

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

        public ActionResult Caja()
        {
            return View();
        }

        [AutorizacionPersonalizada(RoleName.Administrador)]
        public ActionResult Seguridad()
        {
            return View();
        }

        public ActionResult Reportes()
        {
            return View();
        }
    }
}