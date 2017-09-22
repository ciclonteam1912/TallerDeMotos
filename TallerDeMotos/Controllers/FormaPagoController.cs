using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers
{
    public class FormaPagoController : Controller
    {
        private ApplicationDbContext _context;

        public FormaPagoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: FormaPago
        public ActionResult Index()
        {
            return View("ListaDeFormasDePago");
        }

        public ActionResult NuevoFormaPago()
        {
            var formaPago = new FormaPago();

            return View("FormaPagoFormulario", formaPago);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarFormaPago(FormaPago formaPago)
        {
            if (!ModelState.IsValid)
            {
                return View("FormaPagoFormulario", formaPago);
            }

            if (formaPago.Id == 0)
            {
                _context.FormasPago.Add(formaPago);
            }
            else
            {
                var formaPagoBD = _context.FormasPago.Single(c => c.Id == formaPago.Id);
                Mapper.Map<FormaPago, FormaPago>(formaPago, formaPagoBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EditarFormaPago(int id)
        {
            var formaPagoBD = _context.FormasPago.SingleOrDefault(c => c.Id == id);

            if (formaPagoBD == null)
                return HttpNotFound();

            var formaPago = new FormaPago(formaPagoBD);

            return View("FormaPagoFormulario", formaPago);
        }
    }
}