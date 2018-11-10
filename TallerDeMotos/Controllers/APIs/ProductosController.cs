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
                .Include(p => p.Marca)
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
                if (ex.InnerException.InnerException.Message.Contains("FK_dbo.FacturaCompraDetalles_dbo.Productos_ProductoCodigo"))
                    return Json(new JsonResponse { Success = false, Message = "FK_dbo.FacturaCompraDetalles_dbo.Productos_ProductoCodigo" });
            }

            return Ok(new JsonResponse { Success = true, Message = "Producto eliminado con éxito" });
        }
    }
}
