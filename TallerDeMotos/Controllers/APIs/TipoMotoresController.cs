using System.Linq;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class TipoMotoresController : ApiController
    {
        private ApplicationDbContext _context;

        public TipoMotoresController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerTipoMotores()
        {
            var tipoMotores = _context.TiposMotores.ToList();

            return Ok(tipoMotores);
        }
    }
}
