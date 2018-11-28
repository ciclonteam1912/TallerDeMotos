using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Dtos;
using TallerDeMotos.Filters;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers
{
    public class PresupuestoController : Controller
    {
        private ApplicationDbContext _context;
        private ConexionBD _conexionBd;

        public PresupuestoController()
        {
            _context = new ApplicationDbContext();
            _conexionBd = new ConexionBD();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Presupuesto
        public ActionResult Index()
        {
            string usuario = User.Identity.Name;
            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Crear Presupuesto") || usuario.Equals("admin"))
                ViewBag.CrearPresupuesto = true;
            else
                ViewBag.CrearPresupuesto = false;

            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Editar Presupuesto") || usuario.Equals("admin"))
                ViewBag.EditarPresupuesto = true;
            else
                ViewBag.EditarPresupuesto = false;

            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Anular Presupuesto") || usuario.Equals("admin"))
                ViewBag.AnularPresupuesto = true;
            else
                ViewBag.AnularPresupuesto = false;

            return View("ListaDePresupuestos");
        }

        [HasPermission("Crear Presupuesto")]
        public ActionResult PresupuestoFormulario()
        {
            return View();
        }

        [HasPermission("Editar Presupuesto")]
        public ActionResult EditarPresupuesto(int id)
        {
            ViewBag.PresupuestoId = id;
            TempData["PresupuestoCodigo"] = id;
            TempData.Keep("PresupuestoCodigo");

            return View();
        }

        public ActionResult ObtenerPresupuestoDetalle()
        {
            int presupuestoCodigo = int.Parse(TempData["PresupuestoCodigo"].ToString());

            var presupuestoDetalle = _context.PresupuestoDetalles
                .Include(pd => pd.Producto)
                .Include(pd => pd.Producto.ProductoTipo)
                .Where(pd => pd.PresupuestoId == presupuestoCodigo)
                .ToList();

            return Json(presupuestoDetalle, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CrearPresupuestoDetalle(PresupuestoDetalleDto presupuestoDetalleDto)
        {
            if (presupuestoDetalleDto != null && presupuestoDetalleDto.Id == 0)
            {
                var presupuestoDetalle = new PresupuestoDetalle();
                presupuestoDetalle.PresupuestoId = presupuestoDetalleDto.PresupuestoId;
                presupuestoDetalle.ProductoId = presupuestoDetalleDto.Producto.Id;
                presupuestoDetalle.Cantidad = presupuestoDetalle.Cantidad = (presupuestoDetalleDto.Producto.ProductoTipo.Id == 2) ? (byte)1 : presupuestoDetalleDto.Cantidad;
                presupuestoDetalle.Total = (presupuestoDetalleDto.Producto.PrecioVenta ?? default(int)) * presupuestoDetalle.Cantidad;

                presupuestoDetalle.TotalLineaExenta = (presupuestoDetalleDto.Producto.TipoImpuesto == 0 || presupuestoDetalleDto.Producto.TipoImpuesto == null)
                    ? presupuestoDetalle.Total : 0;
                presupuestoDetalle.TotalLineaCincoXCiento = (presupuestoDetalleDto.Producto.TipoImpuesto == 5)
                    ? presupuestoDetalle.Total : 0;
                presupuestoDetalle.TotalLineaDiezXCiento = (presupuestoDetalleDto.Producto.TipoImpuesto == 10)
                    ? presupuestoDetalle.Total : 0;

                _context.PresupuestoDetalles.Add(presupuestoDetalle);
                _context.SaveChanges();

                presupuestoDetalleDto.Total = presupuestoDetalle.Total; 
                presupuestoDetalleDto.Cantidad = presupuestoDetalle.Cantidad;
            }

            return Json(presupuestoDetalleDto, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditarPresupuestoDetalle(PresupuestoDetalleDto presupuestoDetalleDto)
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
                    presupuestoDetalle.ProductoId = presupuestoDetalleDto.Producto.Id;
                    presupuestoDetalle.Cantidad = (presupuestoDetalleDto.Producto.ProductoTipo.Id == 2) ? (byte)1 : presupuestoDetalleDto.Cantidad;
                    presupuestoDetalle.Total = presupuestoDetalle.Cantidad * presupuestoDetalleDto.Producto.PrecioVenta ?? default(int);
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

            return Json(presupuestoDetalleDto, JsonRequestBehavior.AllowGet);
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

        public ActionResult PresupuestoReport(int id = 0)
        {
            if (id != 0)
                ViewBag.Id = id;
            return View();
        }

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