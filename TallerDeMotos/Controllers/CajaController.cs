using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    public class CajaController : Controller
    {
        private ApplicationDbContext _context;

        public CajaController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Caja
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Administrador) || User.IsInRole(RoleName.JefeDeTaller))
                return View("ListaDeCajas");

            return View("ListaDeCajasSoloLectura");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult NuevaCaja()
        {
            var caja = new CajaViewModel();
            return View("CajaFormulario", caja);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarCaja(Caja caja)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CajaViewModel(caja);
                return View("CajaFormulario", viewModel);
            }

            if (caja.Id == 0)
            {     
                _context.Cajas.Add(caja);
            }                
            else
            {
                var cajaBD = _context.Cajas.Single(c => c.Id == caja.Id);
                Mapper.Map<Caja, Caja>(caja, cajaBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult EditarCaja(int id)
        {
            var cajaBD = _context.Cajas.SingleOrDefault(c => c.Id == id);

            if (cajaBD == null)
                return HttpNotFound();

            var caja = new CajaViewModel(cajaBD);

            return View("CajaFormulario", caja);
        }
    }
}