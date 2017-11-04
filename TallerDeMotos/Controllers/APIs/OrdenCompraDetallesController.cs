using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class OrdenCompraDetallesController : ApiController
    {
        private ApplicationDbContext _context;

        public OrdenCompraDetallesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public async Task<IHttpActionResult> ObtenerOrdenDeCompraDetalles()
        {
            var ordenCompraDetalle = await _context.OrdenCompraDetalles
                .Include(ocd => ocd.OrdenCompra)
                .Include(ocd => ocd.Producto)                
                .ToListAsync();

            return Ok(ordenCompraDetalle);
        }

        [HttpGet]
        public async Task<IHttpActionResult> ObtenerOrdenCompraDetalle(int Id)
        {
            var ordenCompraDetalle = await _context.OrdenCompraDetalles
                .Where(ocd => ocd.OrdenCompraId == Id)
                .Include(ocd => ocd.OrdenCompra)
                .Include(ocd => ocd.OrdenCompra.Proveedor)
                .Include(ocd => ocd.OrdenCompra.FormaPago)
                .Include(ocd => ocd.Producto)
                .ToListAsync();            

            return Ok(ordenCompraDetalle);
        }
    }
}
