using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Dtos;
using TallerDeMotos.Filters;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    public class OrdenCompraController : Controller
    {
        private OrdenCompraServicio ordenCompraServicio;
        private ConexionBD _conexionBD;
        private ApplicationDbContext _context;

        public OrdenCompraController()
        {
            _context = new ApplicationDbContext();
            ordenCompraServicio = new OrdenCompraServicio();
            _conexionBD = new ConexionBD();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: OrdenCompra
        public ActionResult Index()
        {
            string usuario = User.Identity.Name;
            if (_conexionBD.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Crear Orden de Compra") || usuario.Equals("admin"))
                ViewBag.CrearOrdenCompra = true;
            else
                ViewBag.CrearOrdenCompra = false;

            if (_conexionBD.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Anular Orden de Compra") || usuario.Equals("admin"))
                ViewBag.AnularOrdenCompra = true;
            else
                ViewBag.AnularOrdenCompra = false;

            return View("ListaDeOrdenDeCompras");

        }

        [HasPermission("Editar Orden de Compra")]
        public ActionResult EditarOrdenCompraDetalle(int id = 0)
        {
            if (id != 0)
                ViewBag.Id = id;
            return View();
        }

        [HasPermission("Crear Orden de Compra")]
        public ActionResult OrdenCompraFormulario()
        {
            var formaPagos = _context.FormasPago.ToList();
            var proveedores = _context.Proveedores.ToList();
            var viewModel = new OrdenCompraViewModel()
            {
                FormaPagos = formaPagos,
                Proveedores = proveedores
            };
            return View(viewModel);
        }

        public ActionResult OrdenCompraReport(int ordenNro = 0)
        {
            if (ordenNro != 0)
                ViewBag.OrdenNro = ordenNro;
            return View("OrdenCompraReport");
        }

        [HasPermission("Editar Orden de Compra")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditarOrdenCompra(OrdenCompraDto ordenCompraDto)
        {
            if(ordenCompraDto != null)
            {
                ordenCompraServicio.Update(ordenCompraDto);
            }

            return Json(ordenCompraDto, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerOrdenCompraPendiente()
        {
            var ordenCompra = _context.OrdenCompras.Include(oc => oc.Estado)
                .Where(oc => oc.Estado.Descripcion.Equals("Pendiente"))
                .ToList()
                .Select(Mapper.Map<OrdenCompra, OrdenCompraDto>)
                .OrderByDescending(oc => oc.Id);

            return Json(ordenCompra, JsonRequestBehavior.AllowGet);
        }

        [HasPermission("Anular Orden de Compra")]
        public ActionResult AnularOrdenCompra(int id)
        {
            var ordenCompraAAnular = _context.OrdenCompras.SingleOrDefault(oc => oc.Id == id);

            if (ordenCompraAAnular == null)
                return HttpNotFound();
                        
            ViewBag.OrdenCompraId = id;

            return View("OrdenCompraAnularFormulario");
        }

        public ActionResult GuardarOrdenCompraAnulada()
        {
            int ordenCompraId = 0;
                int.TryParse(Request.Form["ordenId"], out ordenCompraId);

            string motivoAnulacion = Request.Form["motivoAnulacion"];

            if(ordenCompraId == 0 || motivoAnulacion == "")
            {
                ViewBag.Message = "Ocurrió algo inesperado";
                return View("OrdenCompraAnularFormulario");
            }                

            var ordenCompraAnular = _context.OrdenCompras.Single(oc => oc.Id == ordenCompraId);

            if (ordenCompraAnular.EstadoId == 2)
            {
                ViewBag.Message = "Esta Orden de Compra ya fue Aceptada Anteriormente";
                return View("OrdenCompraAnularFormulario");
            }
            else
            {
                if (ordenCompraAnular.EstadoId == 3)
                {
                    ViewBag.Message = "Esta Orden de Compra ya fue Anulada Anteriormente";
                    return View("OrdenCompraAnularFormulario");
                }
            }

            var ordenAnulada = new OrdenCompraAnulada
            {
                OrdenCompraId = ordenCompraId,
                MotivoAnulacion = motivoAnulacion
            };

            _context.OrdenCompraAnuladas.Add(ordenAnulada);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }        
    }
}