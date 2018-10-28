using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using System.Data.Entity;
using AutoMapper;
using System.Linq;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.Dtos;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Collections.Generic;

namespace TallerDeMotos.Controllers
{
    public class PresupuestoController : Controller
    {
        private ApplicationDbContext _context;

        public PresupuestoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Presupuesto
        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Administrador) || User.IsInRole(RoleName.JefeDeTaller))
                return View("ListaDePresupuestos");

            return View("ListaDePresupuestosSoloLectura");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult PresupuestoFormulario()
        {
            return View();
        }


        public ActionResult EditarPresupuesto(int id)
        {

            TempData["PresupuestoCodigo"] = id;
            TempData.Keep("PresupuestoCodigo");

            return View();
        }


        public ActionResult ObtenerPresupuestoDetalle([DataSourceRequest] DataSourceRequest request)
        {
            int presupuestoCodigo = int.Parse(TempData["PresupuestoCodigo"].ToString());

            var presupuestoDetalle = _context.PresupuestoDetalles
                .Include(pd => pd.Producto.ProductoTipo)
                .Where(pd => pd.PresupuestoId == presupuestoCodigo)
                .Select(Mapper.Map<PresupuestoDetalle, PresupuestoDetalleDto>)
                .ToList();

            return Json(presupuestoDetalle.ToDataSourceResult(request));
        }

        public ActionResult EditarPresupuestoDetalle([DataSourceRequest] DataSourceRequest request, PresupuestoDetalleDto presupuestoDetalleDto)
        {
            PresupuestoDetalle presupuestoDetalle = new PresupuestoDetalle();
            if (presupuestoDetalleDto != null && ModelState.IsValid)
            {
                presupuestoDetalle = _context.PresupuestoDetalles
                    .Include(pd => pd.Producto)
                    .Where(pd => pd.Id == presupuestoDetalleDto.Id)
                    .SingleOrDefault();

                if (presupuestoDetalle != null)
                {
                    presupuestoDetalle.Cantidad = presupuestoDetalleDto.Cantidad;
                    presupuestoDetalle.Total = presupuestoDetalleDto.Cantidad * presupuestoDetalleDto.Producto.PrecioVenta ?? default(int);
                    if (presupuestoDetalle.Producto?.TipoImpuesto == 10)
                        presupuestoDetalle.TotalLineaDiezXCiento = presupuestoDetalle.Total;
                    else if (presupuestoDetalle.Producto?.TipoImpuesto == 5)
                        presupuestoDetalle.TotalLineaCincoXCiento = presupuestoDetalle.Total;
                    else
                        presupuestoDetalle.TotalLineaExenta = presupuestoDetalle.Total;
                }
            }
            _context.SaveChanges();

            presupuestoDetalleDto.Cantidad = presupuestoDetalle.Cantidad;
            presupuestoDetalleDto.Total = presupuestoDetalle.Total;

            return Json(new[] { presupuestoDetalleDto }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EliminarPresupuestoDetalle([DataSourceRequest] DataSourceRequest request,
           PresupuestoDetalleDto presupuestoDetalleDto)
        {
            PresupuestoDetalle presupuestoDetalle = new PresupuestoDetalle();
            if (presupuestoDetalleDto != null)
            {
                presupuestoDetalle.Id = presupuestoDetalleDto.Id;
                _context.PresupuestoDetalles.Attach(presupuestoDetalle);
                _context.PresupuestoDetalles.Remove(presupuestoDetalle);
                _context.SaveChanges();
            }

            return Json(new[] { presupuestoDetalleDto }.ToDataSourceResult(request, ModelState));
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult PresupuestoReport(int id = 0)
        {
            if (id != 0)
                ViewBag.Id = id;
            return View();
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public JsonResult ObtenerPresupuestosPendientes()
        {
            var presupuesto = _context.Presupuestos.Include(p => p.Estado)
                .Where(p => p.Estado.Descripcion.Equals("Pendiente"))
                .ToList()
                .Select(Mapper.Map<Presupuesto, PresupuestoDto>)
                .OrderByDescending(p => p.Id);

            return Json(presupuesto, JsonRequestBehavior.AllowGet);
        }
    }
}