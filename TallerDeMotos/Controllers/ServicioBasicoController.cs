using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers
{
    public class ServicioBasicoController : Controller
    {
        private ApplicationDbContext _context;

        public ServicioBasicoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: ServicioBasico
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Administrador) || User.IsInRole(RoleName.JefeDeTaller))
                return View("ListaDeServiciosBasicos");

            return View("ListaDeServiciosBasicosSoloLectura");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult NuevoServicioBasico()
        {
            var servicioBasico = new ServicioBasico();

            return View("ServicioBasicoFormulario", servicioBasico);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarServicioBasico(ServicioBasico servicioBasico)
        {
            if (!ModelState.IsValid)
            {
                return View("ServicioBasicoFormulario", servicioBasico);
            }

            if (servicioBasico.Id == 0)
                _context.ServiciosBasicos.Add(servicioBasico);
            else
            {
                var servicioBasicoBD = _context.ServiciosBasicos.Single(sb => sb.Id == servicioBasico.Id);
                Mapper.Map<ServicioBasico, ServicioBasico>(servicioBasico, servicioBasicoBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult EditarServicioBasico(int id)
        {
            var servicioBasicoBD = _context.ServiciosBasicos.SingleOrDefault(c => c.Id == id);

            if (servicioBasicoBD == null)
                return HttpNotFound();

            var servicioBasico = new ServicioBasico(servicioBasicoBD);

            return View("ServicioBasicoFormulario", servicioBasico);
        }
    }
}