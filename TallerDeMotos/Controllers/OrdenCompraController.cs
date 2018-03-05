using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using System.Data.Entity;
using TallerDeMotos.Models.ModelosDeDominio;
using AutoMapper;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using System;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    public class OrdenCompraController : Controller
    {
        private OrdenCompraServicio ordenCompraServicio;

        private ApplicationDbContext _context;

        public OrdenCompraController()
        {
            _context = new ApplicationDbContext();
            ordenCompraServicio = new OrdenCompraServicio();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: OrdenCompra
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Administrador) || User.IsInRole(RoleName.JefeDeTaller))
                return View("ListaDeOrdenDeCompras");

            return View("ListaDeOrdenDeComprasSoloLectura");
        }

        public ActionResult EditarOrdenCompraDetalle(int id = 0)
        {
            if (id != 0)
                ViewBag.Id = id;
            return View();
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
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

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult OrdenCompraReport(int ordenNro = 0)
        {
            if (ordenNro != 0)
                ViewBag.OrdenNro = ordenNro;
            return View();
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditarOrdenCompra(OrdenCompraDto ordenCompraDto)
        {
            if(ordenCompraDto != null)
            {
                ordenCompraServicio.Update(ordenCompraDto);
            }

            return Json(ordenCompraDto, JsonRequestBehavior.AllowGet);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public JsonResult ObtenerOrdenCompraPendiente()
        {
            var ordenCompra = _context.OrdenCompras.Include(oc => oc.Estado)
                .Where(oc => oc.Estado.Descripcion.Equals("Pendiente"))
                .ToList()
                .Select(Mapper.Map<OrdenCompra, OrdenCompraDto>)
                .OrderByDescending(oc => oc.Id);

            return Json(ordenCompra, JsonRequestBehavior.AllowGet);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult AnularOrdenCompra(int id)
        {
            var ordenCompraAAnular = _context.OrdenCompras.SingleOrDefault(oc => oc.Id == id);

            if (ordenCompraAAnular == null)
                return HttpNotFound();
            
            ViewBag.NroOrdenCompra = ordenCompraAAnular.OrdenCompraNumero;
            ViewBag.OrdenCompraId = id;

            return View("OrdenCompraAnularFormulario");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
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

        public JsonResult BuscarMaxCodOrdenNro()
        {
            int maxOrdenNro = 0;
            try
            {
                maxOrdenNro = _context.OrdenCompras.Max(oc => oc.OrdenCompraNumero + 1);
            }
            catch (InvalidOperationException)
            {
                maxOrdenNro = 1;
            }

            return Json(maxOrdenNro);
        }
    }
}