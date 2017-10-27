﻿using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using System.Data.Entity;
using TallerDeMotos.Models.ModelosDeDominio;
using AutoMapper;
using TallerDeMotos.Models.AtributosDeAutorizacion;

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
            if (User.IsInRole(RoleName.Administrador) || User.IsInRole(RoleName.JefeDeTaller))
                return View("ListaDeOrdenDeCompras");

            return View("ListaDeOrdenDeComprasSoloLectura");
        }

        public ActionResult EditarOrdenCompraDetalle(int id = 0)
        {
            if (id != 0)
                ViewBag.Id = id;
            return View();
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult OrdenCompraFormulario()
        {
            return View();
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult OrdenCompraReport(int ordenNro = 0)
        {
            if (ordenNro != 0)
                ViewBag.OrdenNro = ordenNro;
            return View();
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditarOrdenCompra(OrdenCompraDto ordenCompraDto)
        {
            if(ordenCompraDto != null)
            {
                ordenCompraServicio.Update(ordenCompraDto);
            }

            return Json(ordenCompraDto, JsonRequestBehavior.AllowGet);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public JsonResult ObtenerOrdenCompraAceptado()
        {
            var ordenCompra = _context.OrdenCompras.Include(oc => oc.Estado)
                .Where(oc => oc.Estado.Descripcion.Equals("Pendiente"))
                .ToList()
                .Select(Mapper.Map<OrdenCompra, OrdenCompraDto>);

            return Json(ordenCompra, JsonRequestBehavior.AllowGet);
        }
    }
}