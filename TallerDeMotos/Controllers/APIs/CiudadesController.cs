using AutoMapper;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers.APIs
{
    public class CiudadesController : ApiController
    {
        private ApplicationDbContext _context;

        public CiudadesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerCiudades()
        {
            var ciudades = _context.Ciudades.ToList().Select(Mapper.Map<Ciudad, CiudadDto>);

            return Ok(ciudades);
        }
    }
}
