using System.Web.Mvc;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers
{
    public class CiudadController : Controller
    {
        private CiudadServicio ciudadServicio;

        public CiudadController()
        {
            ciudadServicio = new CiudadServicio();
        }

        // GET: Ciudad
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ObtenerCiudades()
        {
            return Json(ciudadServicio.Read(), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CrearCiudad(CiudadDto ciudadDto)
        {
            if (ciudadDto != null)
            {
                ciudadServicio.Create(ciudadDto);
            }

            return Json(ciudadDto, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditarCiudad(CiudadDto ciudadDto)
        {
            if (ciudadDto != null && ModelState.IsValid)
            {
                ciudadServicio.Update(ciudadDto);
            }

            return Json(ciudadDto, JsonRequestBehavior.AllowGet);
        }
    }
}