using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class ServiciosBasicosController : ApiController
    {
        private ApplicationDbContext _context;

        public ServiciosBasicosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerServiciosBasicos()
        {
            var serviciosBasicos = _context.ServiciosBasicos
                .ToList();
                //.Select(Mapper.Map<ServicioBasico, ServicioBasicoDto>);

            return Ok(serviciosBasicos);
        }

        //[Authorize(Roles = RoleName.Administrador)]
        //[HttpPost]
        //public IHttpActionResult CrearServicioBasico(ServicioBasicoDto servicioBasicoDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var servicioBasico = Mapper.Map<ServicioBasicoDto, ServicioBasico>(servicioBasicoDto);

        //    _context.ServiciosBasicos.Add(servicioBasico);
        //    _context.SaveChanges();

        //    var resultado = Mapper.Map<ServicioBasico, ServicioBasicoDto>(servicioBasico);

        //    return Ok(resultado);
        //}

        [HttpDelete]
        public IHttpActionResult EliminarServicioBasico(int id)
        {
            try
            {
                var servicioBasico = _context.ServiciosBasicos.Single(sb => sb.Id == id);

                _context.ServiciosBasicos.Remove(servicioBasico);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

            return Ok(new JsonResponse { Success = true, Message = "Servicio Básico eliminado con éxito" });
        }
    }
}
