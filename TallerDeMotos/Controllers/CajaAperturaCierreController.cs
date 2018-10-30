using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    public class CajaAperturaCierreController : Controller
    {
        private ApplicationDbContext _context;

        public CajaAperturaCierreController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: CajaAperturaCierre
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Administrador) || User.IsInRole(RoleName.JefeDeTaller))
                return View("ListaDeAperturaCierresDeCaja");

            return View("ListaDeAperturaCierresDeCajaSoloLectura");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult NuevaAperturaCierre()
        {
            var viewModel = new CajaAperturaCierreViewModel()
            {
                Cajas = _context.Cajas.ToList()
            };

            return View("CajaAperturaCierreFormulario", viewModel);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarAperturaCierre(AperturaCierreCaja aperturaCierrecaja)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CajaAperturaCierreViewModel(aperturaCierrecaja)
                {
                    Cajas = _context.Cajas.ToList()
                };

                return View("CajaAperturaCierreFormulario", viewModel);
            }

            if (aperturaCierrecaja.Id == 0)
            {
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

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult EditarAperturaCierre(int id)
        {
            var aperturaCierrecajaBD = _context.CajaAperturaCierres.SingleOrDefault(c => c.Id == id);

            if (aperturaCierrecajaBD == null)
                return HttpNotFound();

            var aperturaCierrecaja = new CajaAperturaCierreViewModel(aperturaCierrecajaBD)
            {
                Cajas = _context.Cajas.ToList()
            };

            return View("CajaAperturaCierreFormulario", aperturaCierrecaja);
        }
    }
}