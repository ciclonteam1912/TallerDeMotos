using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class VehiculosController : ApiController
    {
        private ApplicationDbContext _context;

        public VehiculosController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ObtenerVehiculosPorCliente(int id)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            var vehiculos = _context.Vehiculos
                .Where(v => v.ClienteId == id)
                .ToList();

            return Ok(vehiculos);
        }

        [HttpGet]
        public IHttpActionResult ObtenerVehiculos()
        {
            _context.Configuration.ProxyCreationEnabled = false;
            var vehiculos = _context.Vehiculos
                .Include(v => v.Cliente)
                .Include(v => v.Aseguradora)
                .Include(v => v.Modelo)
                .Include(v => v.Modelo.Marca)
                .Include(v => v.Combustible)
                .Include(v => v.Cilindrada)
                .Include(v => v.TipoMotor)
                .ToList();

            return Ok(vehiculos);
        }

        [HttpDelete]
        public IHttpActionResult EliminarVehiculo(int id)
        {
            try
            {
                var vehiculo = _context.Vehiculos.Single(c => c.Id == id);
                _context.Vehiculos.Remove(vehiculo);
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
