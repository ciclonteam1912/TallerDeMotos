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
            //var usuarioId = User.Identity.GetUserId();
            var talonarios = _context.Talonarios
                .Include(t => t.Caja)
                .Include(t => t.Sucursal)
                .ToList();
            return Ok(talonarios);
        }

        //[HttpGet]
        //public IHttpActionResult ObtenerTalonarios(int id)
        //{
        //    var usuarioId = User.Identity.GetUserId();
        //    var talonarios = _context.Talonarios.Where(t => t.Id == id && t.UsuarioId == usuarioId).ToList();

        //    if (talonarios == null)
        //        return NotFound();

        //    return Ok(talonarios);
        //}

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
