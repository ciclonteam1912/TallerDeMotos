using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class ContactosController : ApiController
    {
        private ApplicationDbContext _context;

        public ContactosController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ObtenerContactos()
        {
            var contactos = _context.Contactos.ToList();

            return Ok(contactos);
        }
    }
}
