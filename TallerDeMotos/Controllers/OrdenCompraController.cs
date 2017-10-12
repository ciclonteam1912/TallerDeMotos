using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers
{
    public class OrdenCompraController : Controller
    {
        private OrdenCompraServicio ordenCompraServicio;

        private ApplicationDbContext _context;

        public OrdenCompraController()
        {
            _context = new ApplicationDbContext();
            ordenCompraServicio = new OrdenCompraServicio();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: OrdenCompra
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Administrador))
                return View("ListaDeOrdenDeCompras");
            return View("ListaDeOrdenDeComprasSoloLectura");
        }

        public ActionResult OrdenCompraReport(int ordenNro = 0)
        {
            if (ordenNro != 0)
                ViewBag.OrdenNro = ordenNro;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditarOrdenCompra(OrdenCompraDto ordenCompraDto)
        {
            if(ordenCompraDto != null)
            {
                ordenCompraServicio.Update(ordenCompraDto);
            }

            return Json(ordenCompraDto, JsonRequestBehavior.AllowGet);
        }
    }
}