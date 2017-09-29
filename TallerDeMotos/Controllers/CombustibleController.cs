using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers
{
    public class CombustibleController : Controller
    {
        private ApplicationDbContext _context;

        public CombustibleController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Combustible
        public ActionResult Index()
        {
            return View("ListaDeCombustibles");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult NuevoCombustible()
        {
            var combustible = new Combustible();
            return View("CombustibleFormulario", combustible);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarCombustible(Combustible combustible)
        {
            if (!ModelState.IsValid)
                return View("CombustibleFormulario", combustible);

            if (combustible.Id == 0)
                _context.Combustibles.Add(combustible);
            else
            {
                var combustibleBD = _context.Combustibles.Single(c => c.Id == combustible.Id);
                Mapper.Map<Combustible, Combustible>(combustible, combustibleBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult EditarCombustible(int id)
        {
            var combustibleBD = _context.Combustibles.SingleOrDefault(c => c.Id == id);

            if (combustibleBD == null)
                return HttpNotFound();

            var combustible = new Combustible(combustibleBD);

            return View("CombustibleFormulario", combustible);
        }
    }
}