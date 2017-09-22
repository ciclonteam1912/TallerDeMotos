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
    public class ServicioBasicoController : Controller
    {
        private ApplicationDbContext _context;

        public ServicioBasicoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: ServicioBasico
        public ActionResult Index()
        {
            return View("ListaDeServiciosBasicos");
        }

        public ActionResult NuevoServicioBasico()
        {
            var servicioBasico = new ServicioBasico();

            return View("ServicioBasicoFormulario", servicioBasico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarServicioBasico(ServicioBasico servicioBasico)
        {
            if (!ModelState.IsValid)
            {
                return View("ServicioBasicoFormulario", servicioBasico);
            }

            if (servicioBasico.Id == 0)
                _context.ServiciosBasicos.Add(servicioBasico);
            else
            {
                var servicioBasicoBD = _context.ServiciosBasicos.Single(sb => sb.Id == servicioBasico.Id);
                Mapper.Map<ServicioBasico, ServicioBasico>(servicioBasico, servicioBasicoBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EditarServicioBasico(int id)
        {
            var servicioBasicoBD = _context.ServiciosBasicos.SingleOrDefault(c => c.Id == id);

            if (servicioBasicoBD == null)
                return HttpNotFound();

            var servicioBasico = new ServicioBasico(servicioBasicoBD);

            return View("ServicioBasicoFormulario", servicioBasico);
        }
    }
}