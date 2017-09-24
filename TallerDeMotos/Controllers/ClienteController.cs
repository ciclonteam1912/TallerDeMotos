using AutoMapper;
using System;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    public class ClienteController : Controller
    {
        private ApplicationDbContext _context;

        public ClienteController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Cliente
        public ActionResult Index()
        {
            return View("ListaDeClientes");
        }

        public ActionResult NuevoCliente()
        {
            var tiposDocumentos = _context.TipoDocumentos.ToList();
            var personerias = _context.Personerias.ToList();

            var viewModel = new ClienteViewModel()
            {
                TiposDocumentos = tiposDocumentos,
                Personerias = personerias
            };

            return View("ClienteFormulario", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ClienteViewModel(cliente)
                {
                    Personerias = _context.Personerias.ToList(),
                    TiposDocumentos = _context.TipoDocumentos.ToList()
                };

                return View("ClienteFormulario", viewModel);
            }

            if (cliente.Id == 0)
            {
                cliente.FechaDeIngreso = DateTime.Now;
                _context.Clientes.Add(cliente);
            }
            else
            {
                var clientesBD = _context.Clientes.Single(c => c.Id == cliente.Id);
                Mapper.Map<Cliente, Cliente>(cliente, clientesBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EditarCliente(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();

            var viewModel = new ClienteViewModel(cliente)
            {
                Personerias = _context.Personerias.ToList(),
                TiposDocumentos = _context.TipoDocumentos.ToList()
            };

            return View("ClienteFormulario", viewModel);
        }

        [HttpPost]
        public ActionResult GuardarEnPDF(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);
            Response.Headers.Add("Content-Disposition", "inline; filename=" + fileName);
            return File(fileContents, contentType);
        }
    }
}