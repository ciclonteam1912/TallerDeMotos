using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class ProveedoresController : ApiController
    {
        private ApplicationDbContext _context;

        public ProveedoresController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerProveedores()
        {
            var proveedores = _context.Proveedores.ToList();
                //.Select(Mapper.Map<Proveedor, ProveedorDto>);

            return Ok(proveedores);
        }

        //[Authorize(Roles = RoleName.Administrador)]
        //[HttpPost]
        //public IHttpActionResult CrearProveedor(ProveedorDto proveedorDto)
        //{
        //    var proveedor = Mapper.Map<ProveedorDto, Proveedor>(proveedorDto);

        //    _context.Proveedores.Add(proveedor);
        //    _context.SaveChanges();

        //    var resultado = Mapper.Map<Proveedor, ProveedorDto>(proveedor);

        //    return Ok(resultado);
        //}

        [HttpDelete]
        public IHttpActionResult EliminarProveedor(int id)
        {
            try
            {
                var proveedor = _context.Proveedores.Single(a => a.Id == id);
                _context.Proveedores.Remove(proveedor);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

            return Ok(new JsonResponse { Success = true, Message = "Proveedor eliminado con éxito" });
        }
    }
}
