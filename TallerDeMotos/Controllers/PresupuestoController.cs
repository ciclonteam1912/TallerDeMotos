using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;

namespace TallerDeMotos.Controllers
{
    public class PresupuestoController : Controller
    {
        // GET: Presupuesto
        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult Index()
        {
            return View("PresupuestoFormulario");
        }
    }
}