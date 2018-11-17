using AutoMapper;
using System;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Filters;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    public class ClienteController : Controller
    {
        private ApplicationDbContext _context;
        private ConexionBD _conexionBd;

        public ClienteController()
        {
            _context = new ApplicationDbContext();
            _conexionBd = new ConexionBD();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Cliente
        public ActionResult Index()
        {
            string usuario = User.Identity.Name;
            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Crear Cliente") || usuario.Equals("admin"))
                ViewBag.CrearCliente = true;
            else
                ViewBag.CrearCliente = false;

            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Editar Cliente") || usuario.Equals("admin"))
                ViewBag.EditarCliente = true;
            else
                ViewBag.EditarCliente = false;

            if (_conexionBd.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Eliminar Cliente") || usuario.Equals("admin"))
                ViewBag.EliminarCliente = true;
            else
                ViewBag.EliminarCliente = false;

            return View("ListaDeClientes");
        }

        [HasPermission("Crear Cliente")]
        public ActionResult NuevoCliente()
        {
            var tiposDocumentos = _context.TipoDocumentos.ToList();
            var personerias = _context.Personerias.ToList();
            var ciudades = _context.Ciudades.ToList();

            var viewModel = new ClienteViewModel()
            {
                TiposDocumentos = tiposDocumentos,
                Personerias = personerias,
                Ciudades = ciudades
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
                    TiposDocumentos = _context.TipoDocumentos.ToList(),
                    Ciudades = _context.Ciudades.ToList()
                };

                return View("ClienteFormulario", viewModel);
            }

            if (cliente.Id == 0)
            {
                cliente.FechaDeNacimiento = Convert.ToDateTime(cliente.Fecha);
                cliente.FechaDeIngreso = DateTime.Now;
                _context.Clientes.Add(cliente);
            }
            else
            {
                var clientesBD = _context.Clientes.Single(c => c.Id == cliente.Id);
                Mapper.Map<Cliente, Cliente>(cliente, clientesBD);
                clientesBD.FechaDeNacimiento = Convert.ToDateTime(cliente.Fecha);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HasPermission("Editar Cliente")]
        public ActionResult EditarCliente(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();

            var viewModel = new ClienteViewModel(cliente)
            {
                Personerias = _context.Personerias.ToList(),
                TiposDocumentos = _context.TipoDocumentos.ToList(),
                Ciudades = _context.Ciudades.ToList()
            };


            viewModel.Fecha = viewModel.FechaDeNacimiento.ToString();
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