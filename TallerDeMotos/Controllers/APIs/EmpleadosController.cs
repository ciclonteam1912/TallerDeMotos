using System;
using System.Data.Entity;
using System.Linq;
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
                .Include(e => e.Ciudad)
                .Include(e => e.Cargo)
                .Where(e => !e.Nombre.Equals("Administrador"))
                .ToList();
                //.Select(Mapper.Map<Empleado, EmpleadoDto>);

            return Ok(empleados);
        }

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
