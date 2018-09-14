using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Filters;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    public class AseguradoraController : Controller
    {
        private ApplicationDbContext _context;
        private ConexionBD _conexionBd;
        public AseguradoraController()
        {
            _context = new ApplicationDbContext();
            _conexionBd = new ConexionBD();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Aseguradora
        public ActionResult Index()
        {
            string usuario = User.Identity.Name;
            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Crear Aseguradora") || usuario.Equals("admin"))
                ViewBag.CrearAseguradora = true;
            else
                ViewBag.CrearAseguradora = false;

            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Editar Aseguradora") || usuario.Equals("admin"))
                ViewBag.EditarAseguradora = true;
            else
                ViewBag.EditarAseguradora = false;

            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Eliminar Aseguradora") || usuario.Equals("admin"))
                ViewBag.EliminarAseguradora = true;
            else
                ViewBag.EliminarAseguradora = false;

            return View("ListaDeAseguradoras");
        }
        
        [HasPermission("Crear Aseguradora")]
        public ActionResult NuevaAseguradora()
        {
            var ciudades = _context.Ciudades.ToList();

            var viewModel = new AseguradoraViewModel()
            {
                Ciudades = ciudades
            };

            return View("AseguradoraFormulario", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarAseguradora(Aseguradora aseguradora)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AseguradoraViewModel(aseguradora)
                {
                    Ciudades = _context.Ciudades.ToList()
                };

                return View("AseguradoraFormulario", viewModel);
            }
                

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
        
        [HasPermission("Editar Aseguradora")]
        public ActionResult EditarAseguradora(int id)
        {
            var aseguradoraBD = _context.Aseguradoras.SingleOrDefault(c => c.Id == id);

            if (aseguradoraBD == null)
                return HttpNotFound();

            var viewModel = new AseguradoraViewModel(aseguradoraBD)
            {
                Ciudades = _context.Ciudades.ToList()
            };

            return View("AseguradoraFormulario", viewModel);
        }
    }
}