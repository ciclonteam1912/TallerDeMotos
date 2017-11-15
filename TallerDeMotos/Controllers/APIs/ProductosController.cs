using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class ProductosController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductosController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public async Task<IHttpActionResult> ObtenerProductos()
        {
            return await Task.Run(() =>
            {
                var productos = _context.Productos
                .Include(p => p.ProductoTipo)
                .ToList();

                return Ok(productos);
            });
        }

        [HttpGet]
        public IHttpActionResult GetProducto(int id)
        {
            var producto = _context.Productos.SingleOrDefault(p => p.Id == id);

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        [HttpDelete]
        public IHttpActionResult EliminarProducto(int id)
        {
            try
            {
                var producto = _context.Productos.Single(p => p.Id == id);
                _context.Productos.Remove(producto);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

            return Ok(new JsonResponse { Success = true, Message = "Producto eliminado con éxito" });
        }
    }
}
