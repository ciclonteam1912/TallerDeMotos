using AutoMapper;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers.APIs
{
    public class CilindradasController : ApiController
    {
        private ApplicationDbContext _context;

        public CilindradasController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerCilindradas()
        {
            var cilindradas = _context.Cilindradas.ToList();

            return Ok(cilindradas);
        }
    }
}
