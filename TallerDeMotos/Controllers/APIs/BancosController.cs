using AutoMapper;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers.APIs
{
    public class BancosController : ApiController
    {
        private ApplicationDbContext _context;

        public BancosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerBancos()
        {
            var bancos = _context.Bancos.ToList().Select(Mapper.Map<Banco, BancoDto>);

            return Ok(bancos);
        }
    }
}
