using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class TalonariosController : ApiController
    {
        private ApplicationDbContext _context;

        public TalonariosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerTalonarios()
        {
            var talonarios = _context.Talonarios
                .Include(t => t.Caja)
                .Include(t => t.Sucursal.Ciudad)
                .ToList();
            return Ok(talonarios);
        }

        [HttpDelete]
        public IHttpActionResult EliminarTalonario(int id)
        {
            var talonario = _context.Talonarios.Single(t => t.Id == id);

            _context.Talonarios.Remove(talonario);
            _context.SaveChanges();

            return Ok();
        }
    }
}
