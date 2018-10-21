using AutoMapper;
using System;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    public class TalonarioController : Controller
    {
        private ApplicationDbContext _context;

        public TalonarioController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Talonario
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Administrador) || User.IsInRole(RoleName.JefeDeTaller) || User.IsInRole(RoleName.Mecanico))
                return View("ListaDeTalonarios");

            return View("ListaDeTalonariosSoloLectura");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult NuevoTalonario()
        {
            var talonario = new TalonarioViewModel
            {
                Cajas = _context.Cajas.ToList(),
                Sucursales = _context.Sucursales.ToList()
            };

            return View("TalonarioFormulario", talonario);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
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

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult EditarTalonario(int id)
        {
            var talonario = _context.Talonarios.SingleOrDefault(t => t.Id == id);

            if (talonario == null)
                return HttpNotFound();

            var viewModel = new TalonarioViewModel(talonario)
            {
                Cajas = _context.Cajas.ToList(),
                Sucursales = _context.Sucursales.ToList()
            };

            viewModel.FechaIni = viewModel.FechaInicioVigencia.ToString();
            viewModel.FechaFin = viewModel.FechaFinVigencia.ToString();
            return View("TalonarioFormulario", viewModel);
        }
    }
}