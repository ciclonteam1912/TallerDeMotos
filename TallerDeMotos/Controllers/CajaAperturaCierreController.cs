using AutoMapper;
using System;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Filters;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    public class CajaAperturaCierreController : Controller
    {
        private ApplicationDbContext _context;
        private ConexionBD _conexionBD;

        public CajaAperturaCierreController()
        {
            _context = new ApplicationDbContext();
            _conexionBD = new ConexionBD();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: CajaAperturaCierre
        public ActionResult Index()
        {
            string usuario = User.Identity.Name;
            if (_conexionBD.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Realizar Apertura y Cierre") || usuario.Equals("admin"))
                ViewBag.RealizarAperturaCierre = true;
            else
                ViewBag.RealizarAperturaCierre = false;

            if (_conexionBD.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Eliminar Apertura y Cierre") || usuario.Equals("admin"))
                ViewBag.EliminarAperturaCierre = true;
            else
                ViewBag.EliminarAperturaCierre = false;

            return View("ListaDeAperturaCierresDeCaja");
        }

        [HasPermission("Realizar Apertura y Cierre")]
        public ActionResult NuevaAperturaCierre()
        {
            var viewModel = new CajaAperturaCierreViewModel()
            {
                Cajas = _context.Cajas.ToList(),
                Usuarios = _context.Users.ToList()
            };
            viewModel.Resultado = true;
            return View("CajaAperturaCierreFormulario", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarAperturaCierre(AperturaCierreCaja aperturaCierrecaja)
        {
            CajaAperturaCierreViewModel model = new CajaAperturaCierreViewModel();
            model.MensajeError = "";
            model.Resultado = true;

            if (!ModelState.IsValid)
            {
                var viewModel = new CajaAperturaCierreViewModel(aperturaCierrecaja)
                {
                    Cajas = _context.Cajas.ToList(),
                    Usuarios = _context.Users.ToList()
                };

                return View("CajaAperturaCierreFormulario", viewModel);
            }

            string usuarioCajaOK = _conexionBD.ValidarUsuarioCaja(aperturaCierrecaja.UsuarioId);
            string cajaDisponible = _conexionBD.CajaDisponible(aperturaCierrecaja.CajaId);
            if(usuarioCajaOK == "1" || cajaDisponible == "1")
            {
                var viewModel = new CajaAperturaCierreViewModel(aperturaCierrecaja)
                {
                    Cajas = _context.Cajas.ToList(),
                    Usuarios = _context.Users.ToList()
                };

                if(usuarioCajaOK == "1")
                    viewModel.MensajeError = "El usuario seleccionado posee una caja abierta. Debe cerrar primero dicha caja.";
                else if(cajaDisponible == "1")
                    viewModel.MensajeError = "Caja no disponible. Ya se encuentra utilizada por otro usuario.";

                viewModel.Resultado = false;
                return View("CajaAperturaCierreFormulario", viewModel);
            }

            if (aperturaCierrecaja.Id == 0)
            {
                aperturaCierrecaja.EstaAbierta = true;
                _context.CajaAperturaCierres.Add(aperturaCierrecaja);
            }
            else
            {
                var aperturaCierrecajaBD = _context.CajaAperturaCierres.Single(c => c.Id == aperturaCierrecaja.Id);
                Mapper.Map<AperturaCierreCaja, AperturaCierreCaja>(aperturaCierrecaja, aperturaCierrecajaBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EditarAperturaCierre(int id)
        {
            var aperturaCierrecajaBD = _context.CajaAperturaCierres.SingleOrDefault(c => c.Id == id);

            if (aperturaCierrecajaBD == null)
                return HttpNotFound();

            var aperturaCierrecaja = new CajaAperturaCierreViewModel(aperturaCierrecajaBD)
            {
                Cajas = _context.Cajas.ToList(),
                Usuarios = _context.Users.ToList()
            };
            aperturaCierrecaja.Resultado = true;
            return View("CajaAperturaCierreFormulario", aperturaCierrecaja);
        }


        public ActionResult CambiarEstadoCaja(int id)
        {
            var caja = _context.CajaAperturaCierres.Where(c => c.Id == id).SingleOrDefault();

            if(caja != null)
            {
                if (caja.EstaAbierta)
                    caja.EstaAbierta = false;
                else
                {
                    if(DateTime.Parse(caja.Fecha.ToShortDateString()) < DateTime.Parse(DateTime.Now.ToShortDateString()))
                    {
                        return Json(new JsonResponse { Success = false, Message = "No es posible abrir una caja de días anteriores." });
                    }
                    else
                    {
                        caja.EstaAbierta = true;
                    }
                }

                _context.SaveChanges();
            }
            else
                return Json(new JsonResponse { Success = false });

            return Json(new JsonResponse { Success = true });
        }
    }
}