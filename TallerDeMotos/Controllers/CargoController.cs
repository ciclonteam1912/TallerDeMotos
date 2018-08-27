using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers
{
    public class CargoController : Controller
    {
        private CargoServicio cargoServicio;

        public CargoController()
        {
            cargoServicio = new CargoServicio();
        }

        // GET: Cargo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ObtenerCargos([DataSourceRequest] DataSourceRequest request)
        {
            return Json(cargoServicio.Read().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CrearCargo([DataSourceRequest] DataSourceRequest request, CargoDto cargoDto)
        { 
            if (cargoDto != null && ModelState.IsValid)
            {
                 cargoServicio.Create(cargoDto);
            }

            return Json(new[] { cargoDto }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditarCargo([DataSourceRequest] DataSourceRequest request, CargoDto cargoDto)
        {
            if (cargoDto != null && ModelState.IsValid)
            {
                    cargoServicio.Update(cargoDto);
            }

            return Json(new[] { cargoDto }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EliminarCargo([DataSourceRequest] DataSourceRequest request, CargoDto cargoDto)
        {
            try
            {
                if (cargoDto != null)
                {
                    cargoServicio.Destroy(cargoDto);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.InnerException.InnerException.Message);
                var result = ModelState.ToDataSourceResult();
                return Json(new[] { result }.ToDataSourceResult(request, ModelState));
            }
            
            return Json(new[] { cargoDto }.ToDataSourceResult(request, ModelState));
        }
    }
}