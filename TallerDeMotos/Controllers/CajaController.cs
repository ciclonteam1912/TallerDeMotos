using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallerDeMotos.Filters;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    public class CajaController : Controller
    {
        private ApplicationDbContext _context;
        private ConexionBD _conexionBd;

        public CajaController()
        {
            _context = new ApplicationDbContext();
            _conexionBd = new ConexionBD();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Caja
        public ActionResult Index()
        {
            string usuario = User.Identity.Name;
            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Crear Caja") || usuario.Equals("admin"))
                ViewBag.CrearCaja = true;
            else
                ViewBag.CrearCaja = false;

            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Editar Caja") || usuario.Equals("admin"))
                ViewBag.EditarCaja = true;
            else
                ViewBag.EditarCaja = false;

            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Eliminar Caja") || usuario.Equals("admin"))
                ViewBag.EliminarCaja = true;
            else
                ViewBag.EliminarCaja = false;

            return View("ListaDeCajas");
        }

        [HasPermission("Crear Caja")]
        public ActionResult NuevaCaja()
        {
            var caja = new CajaViewModel();
            return View("CajaFormulario", caja);
        }

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

        [HasPermission("Editar Caja")]
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