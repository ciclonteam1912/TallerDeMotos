using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers.APIs
{
    public class CargosController : ApiController
    {
        private ApplicationDbContext _context;

        public CargosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerCargos()
        {
            var cargos = _context.Cargos.ToList().Select(Mapper.Map<Cargo, CargoDto>);

            return Ok(cargos);
        }
    }
}
