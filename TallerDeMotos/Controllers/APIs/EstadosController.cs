using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers.APIs
{
    public class EstadosController : ApiController
    {
        private ApplicationDbContext _context;

        public EstadosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerEstados()
        {
            var estados = _context.Estados
                .ToList()
                .Select(Mapper.Map<Estado, EstadoDto>);

            return Ok(estados);
        }
    }
}
