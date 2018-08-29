using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
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

        public ActionResult ObtenerCiudades([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ciudadServicio.Read().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CrearCiudad([DataSourceRequest] DataSourceRequest request, CiudadDto ciudadDto)
        {
            try
            {
                if (ciudadDto != null && ModelState.IsValid)
                {
                    ciudadServicio.Create(ciudadDto);
                }
                else
                {
                    ModelState.AddModelError("error", "");
                    var result = ModelState.ToDataSourceResult();
                    return Json(new[] { result }.ToDataSourceResult(request, ModelState));
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("error", ex.InnerException.InnerException.Message);
                var result = ModelState.ToDataSourceResult();
                return Json(new[] { result }.ToDataSourceResult(request, ModelState));
            }            
            return Json(new[] { ciudadDto }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditarCiudad([DataSourceRequest] DataSourceRequest request, CiudadDto ciudadDto)
        {
            try
            {
                if (ciudadDto != null && ModelState.IsValid)
                {
                    ciudadServicio.Update(ciudadDto);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.InnerException.InnerException.Message);
                var result = ModelState.ToDataSourceResult();
                return Json(new[] { result }.ToDataSourceResult(request, ModelState));
            }
            return Json(new[] { ciudadDto }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EliminarCiudad([DataSourceRequest] DataSourceRequest request, CiudadDto ciudadDto)
        {
            try
            {
                if (ciudadDto != null)
                {
                    ciudadServicio.Destroy(ciudadDto);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.InnerException.InnerException.Message);
                var result = ModelState.ToDataSourceResult();
                return Json(new[] { result }.ToDataSourceResult(request, ModelState));
            }

            return Json(new[] { ciudadDto }.ToDataSourceResult(request, ModelState));
        }
    }
}