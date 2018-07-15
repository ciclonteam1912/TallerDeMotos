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
using System.Data.Entity;

namespace TallerDeMotos.Controllers.APIs
{
    public class SucursalesController : ApiController
    {
        private ApplicationDbContext _context;

        public SucursalesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerSucursales()
        {
            var sucursales = _context.Sucursales
                .Include(s => s.Empresa)
                .Include(s => s.Ciudad)
                .ToList().Select(Mapper.Map<Sucursal, SucursalDto>);

            return Ok(sucursales);
        }
    }
}
