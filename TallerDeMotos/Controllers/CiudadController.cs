using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;

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
           // var results = new List<CiudadDto>();

            if (ciudadDto != null)
            {
                //foreach (var c in ciudades)
                //{
                    ciudadServicio.Create(ciudadDto);
                  //  results.Add(c);
                //}
            }

            return Json(ciudadDto, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditarCiudad(CiudadDto ciudadDto)
        {
            if (ciudadDto != null && ModelState.IsValid)
            {
                //foreach (var ciudad in ciudades)
                //{
                    ciudadServicio.Update(ciudadDto);
                //}
            }

            return Json(ciudadDto, JsonRequestBehavior.AllowGet);
        }
    }
}