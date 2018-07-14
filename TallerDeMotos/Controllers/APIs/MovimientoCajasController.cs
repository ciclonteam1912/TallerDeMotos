using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers.APIs
{
    public class MovimientoCajasController : ApiController
    {
        private ApplicationDbContext _context;

        public MovimientoCajasController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        [HttpGet]
        public IHttpActionResult ObtenerMovimientoCajas()
        {   
            var movimientos = _context.MovimientoCajas
                .Include(mov => mov.AperturaCierreCaja)
                .Include(mov => mov.AperturaCierreCaja.Caja)
                //.Include(mov => mov.FacturaVenta)
                .Include(mov => mov.TipoMovimiento)
                .ToList()
                .Select(Mapper.Map<MovimientoCaja, MovimientoCajaDto>)
                .OrderByDescending(mov => mov.Id);

            return Ok(movimientos);
        }
    }
}
