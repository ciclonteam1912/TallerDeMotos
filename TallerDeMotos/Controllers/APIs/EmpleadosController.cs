using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class EmpleadosController : ApiController
    {
        private ApplicationDbContext _context;

        public EmpleadosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerEmpleados()
        {
            var empleados = _context.Empleados
                .ToList();
                //.Select(Mapper.Map<Empleado, EmpleadoDto>);

            return Ok(empleados);
        }

        //[Authorize(Roles = RoleName.Administrador)]
        //[HttpPost]
        //public IHttpActionResult CrearEmpleado(EmpleadoDto empleadoDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var empleado = Mapper.Map<EmpleadoDto, Empleado>(empleadoDto);
        //    empleado.FechaDeIngreso = DateTime.Now;

        //    _context.Empleados.Add(empleado);
        //    _context.SaveChanges();

        //    var resultado = Mapper.Map<Empleado, EmpleadoDto>(empleado);

        //    return Ok(resultado);
        //}

        [HttpDelete]
        public IHttpActionResult EliminarEmpleado(int id)
        {
            try
            {
                var empleado = _context.Empleados.Single(e => e.Id == id);

                _context.Empleados.Remove(empleado);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
            
            return Ok();
        }
    }
}
