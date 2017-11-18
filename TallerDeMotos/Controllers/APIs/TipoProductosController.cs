using System.Linq;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class TipoProductosController : ApiController
    {
        private ApplicationDbContext _context;

        public TipoProductosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerTiposDeProductos()
        {
            var tipoProductos = _context.ProductoTipos.ToList();

            return Ok(tipoProductos);
        }
    }
}
