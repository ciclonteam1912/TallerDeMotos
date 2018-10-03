using System.Linq;
using System.Web;
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

        //[HttpGet]
        //public IHttpActionResult ObtenerTiposDeProductosSinServicio()
        //{
        //    var tipoProductos = _context.ProductoTipos.Where(tp => tp.Id != 2).ToList();

        //    return Ok(tipoProductos);
        //}
    }
}
