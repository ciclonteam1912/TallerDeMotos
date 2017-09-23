using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;
using System.Data.Entity;

namespace TallerDeMotos.Controllers.APIs
{
    public class ClientesController : ApiController
    {
        private ApplicationDbContext _context;

        public ClientesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerClientes()
        {
            //_context.Configuration.ProxyCreationEnabled = false;
            var clientes = _context.Clientes
                .Include(c => c.Personeria)
                .Include(c => c.TipoDocumento)
                .ToList()
               /* .Select(Mapper.Map<Cliente, ClienteDto>)*/;

            return Ok(clientes);
        }

        [HttpDelete]
        public IHttpActionResult EliminarCliente(int id)
        {
            var cliente = _context.Clientes.Single(c => c.Id == id);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return Ok();
        }
    }
}
