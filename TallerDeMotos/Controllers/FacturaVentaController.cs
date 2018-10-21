using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;

namespace TallerDeMotos.Controllers
{
    public class FacturaVentaController : Controller
    {
        private ApplicationDbContext _context;

        public FacturaVentaController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: FacturaCompra
        public ActionResult Index()
        {
            return View("ListaDeFacturaDeVentas");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult FacturaVentaFormulario()
        {
            return View();
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult FacturaVentaReport(int nroFactura = 0)
        {
            if (nroFactura != 0)
                ViewBag.NumeroFactura = nroFactura;
            return View("FacturaVentaReport");
        }
    }
}