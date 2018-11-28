using AutoMapper;
using System;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Filters;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    public class TalonarioController : Controller
    {
        private ApplicationDbContext _context;
        private ConexionBD _conexionBd;

        public TalonarioController()
        {
            _context = new ApplicationDbContext();
            _conexionBd = new ConexionBD();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Talonario
        public ActionResult Index()
        {
            string usuario = User.Identity.Name;
            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Crear Talonario") || usuario.Equals("admin"))
                ViewBag.CrearTalonario = true;
            else
                ViewBag.CrearTalonario = false;

            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Editar Talonario") || usuario.Equals("admin"))
                ViewBag.EditarTalonario = true;
            else
                ViewBag.EditarTalonario = false;

            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Eliminar Talonario") || usuario.Equals("admin"))
                ViewBag.EliminarTalonario = true;
            else
                ViewBag.EliminarTalonario = false;

            return View("ListaDeTalonarios");
        }

        [HasPermission("Crear Talonario")]
        public ActionResult NuevoTalonario()
        {
            var talonario = new TalonarioViewModel
            {
                Cajas = _context.Cajas.ToList()
            };

            return View("TalonarioFormulario", talonario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarTalonario(Talonario talonario)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TalonarioViewModel(talonario)
                {
                    Cajas = _context.Cajas.ToList()
                };

                return View("TalonarioFormulario", viewModel);
            }

            if (talonario.Id == 0)
            {
                talonario.FechaInicioVigencia = Convert.ToDateTime(talonario.FechaIni);
                talonario.FechaFinVigencia = Convert.ToDateTime(talonario.FechaFin);
                talonario.NumeroFacturaActual = talonario.NumeroFacturaInicial;
                _context.Talonarios.Add(talonario);
            }
            else
            {
                var talonarioBD = _context.Talonarios.Single(t => t.Id == talonario.Id);
                Mapper.Map<Talonario, Talonario>(talonario, talonarioBD);
                talonarioBD.NumeroFacturaActual = talonario.NumeroFacturaInicial;
                talonarioBD.FechaInicioVigencia = Convert.ToDateTime(talonario.FechaIni);
                talonarioBD.FechaFinVigencia = Convert.ToDateTime(talonario.FechaFin);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HasPermission("Editar Talonario")]
        public ActionResult EditarTalonario(int id)
        {
            var talonario = _context.Talonarios.SingleOrDefault(t => t.Id == id);

            if (talonario == null)
                return HttpNotFound();

            var viewModel = new TalonarioViewModel(talonario)
            {
                Cajas = _context.Cajas.ToList()
            };

            viewModel.FechaIni = viewModel.FechaInicioVigencia.ToString();
            viewModel.FechaFin = viewModel.FechaFinVigencia.ToString();
            return View("TalonarioFormulario", viewModel);
        }
    }
}