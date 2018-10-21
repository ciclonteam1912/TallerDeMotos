using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class FacturaVentaDetallesController : ApiController
    {
        private ApplicationDbContext _context;

        public FacturaVentaDetallesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public async Task<IHttpActionResult> ObtenerFacturaDeVentaDetalles()
        {
            var facturaVentaDetalle = await _context.FacturaVentaDetalles
                .Include(ocd => ocd.Producto)
                .ToListAsync();

            return Ok(facturaVentaDetalle);
        }

    }
}
