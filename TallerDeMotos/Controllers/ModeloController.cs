using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    public class ModeloController : Controller
    {
        private ApplicationDbContext _context;

        public ModeloController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Modelo
        public ActionResult Index()
        {
            return View("ListaDeModelos");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult NuevoModelo()
        {
            var marcas = _context.Marcas.ToList();

            var viewModel = new ModeloViewModel
            {
                Marcas = marcas
            };

            return View("ModeloFormulario", viewModel);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarModelo(Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ModeloViewModel(modelo)
                {
                    Marcas = _context.Marcas.ToList()
                };

                return View("ModeloFormulario", viewModel);
            }

            if (modelo.Id == 0)
                _context.Modelos.Add(modelo);
            else
            {
                var modeloBD = _context.Modelos.Single(m => m.Id == modelo.Id);
                Mapper.Map<Modelo, Modelo>(modelo, modeloBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult EditarModelo(int id)
        {
            var modeloBD = _context.Modelos.SingleOrDefault(c => c.Id == id);

            if (modeloBD == null)
                return HttpNotFound();

            var modelo = new ModeloViewModel(modeloBD)
            {
                Marcas = _context.Marcas.ToList()
            };

            return View("ModeloFormulario", modelo);
        }
    }
}