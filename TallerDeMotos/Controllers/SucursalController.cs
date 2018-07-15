using System.Web.Mvc;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers
{
    public class SucursalController : Controller
    {
        private SucursalServicio sucursalServicio;

        public SucursalController()
        {
            sucursalServicio = new SucursalServicio();
        }

        // GET: Sucursal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ObtenerSucursales()
        {
            return Json(sucursalServicio.Read(), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CrearSucursal(SucursalDto sucursalDto)
        {
            if (sucursalDto != null)
            {
                sucursalServicio.Create(sucursalDto);
            }

            return Json(sucursalDto, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditarSucursal(SucursalDto sucursalDto)
        {
            if (sucursalDto != null && ModelState.IsValid)
            {
                sucursalServicio.Update(sucursalDto);
            }

            return Json(sucursalDto, JsonRequestBehavior.AllowGet);
        }
    }
}