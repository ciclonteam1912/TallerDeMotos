using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers
{
    public class AseguradoraController : Controller
    {
        private ApplicationDbContext _context;

        public AseguradoraController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Aseguradora
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Administrador) || User.IsInRole(RoleName.JefeDeTaller) || User.IsInRole(RoleName.Mecanico))
                return View("ListaDeAseguradoras");

            return View("ListaDeAseguradorasSoloLectura");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult NuevaAseguradora()
        {
            var aseguradora = new Aseguradora();

            return View("AseguradoraFormulario", aseguradora);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarAseguradora(Aseguradora aseguradora)
        {
            if (!ModelState.IsValid)
                return View("AseguradoraFormulario", aseguradora);

            if (aseguradora.Id == 0)
                _context.Aseguradoras.Add(aseguradora);
            else
            {
                var aseguradoraBD = _context.Aseguradoras.Single(a => a.Id == aseguradora.Id);
                Mapper.Map<Aseguradora, Aseguradora>(aseguradora, aseguradoraBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult EditarAseguradora(int id)
        {
            var aseguradoraBD = _context.Aseguradoras.SingleOrDefault(c => c.Id == id);

            if (aseguradoraBD == null)
                return HttpNotFound();

            var aseguradora = new Aseguradora(aseguradoraBD);

            return View("AseguradoraFormulario", aseguradora);
        }
    }
}