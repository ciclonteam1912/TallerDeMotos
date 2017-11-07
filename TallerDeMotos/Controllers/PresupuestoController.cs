using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using System.Data.Entity;
using AutoMapper;
using System.Linq;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.Dtos;

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