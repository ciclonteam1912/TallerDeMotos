using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class FacturaCompraDetallesController : ApiController
    {
        private ApplicationDbContext _context;

        public FacturaCompraDetallesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public async Task<IHttpActionResult> ObtenerFacturaDeCompraDetalles()
        {
            var facturaCompraDetalle = await _context.FacturaCompraDetalles
                .Include(ocd => ocd.Producto)
                .ToListAsync();

            return Ok(facturaCompraDetalle);
        }

    }
}
