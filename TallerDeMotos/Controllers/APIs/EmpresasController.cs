using AutoMapper;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers.APIs
{
    public class EmpresasController : ApiController
    {
        private ApplicationDbContext _context;

        public EmpresasController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerEmpresas()
        {
            var empresas = _context.Empresas.ToList().Select(Mapper.Map<Empresa, EmpresaDto>);

            return Ok(empresas);
        }
    }
}
