using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Models;

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
            try
            {
                var cliente = _context.Clientes.Single(c => c.Id == id);
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("FK_dbo.Vehiculos_dbo.Clientes_ClienteCodigo"))
                    return Json(new JsonResponse { Success = false, Message = "FK_dbo.Vehiculos_dbo.Clientes_ClienteCodigo" });                
            }

            return Ok(new JsonResponse { Success = true, Message = "Cliente eliminado con éxito" });
           
        }
    }
}
