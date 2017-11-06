using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class PresupuestoDetallesController : ApiController
    {
        private ApplicationDbContext _context;

        public PresupuestoDetallesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public async Task<IHttpActionResult> ObtenerPresupuestoDetalles()
        {
            var presupuestoDetalle = await _context.PresupuestoDetalles
                .Include(pd => pd.Presupuesto)
                .Include(pd => pd.Producto)
                .ToListAsync();

            return Ok(presupuestoDetalle);
        }

        [HttpGet]
        public async Task<IHttpActionResult> ObtenerPresupuestoDetalle(int Id)
        {
            var presupuestoDetalle = await _context.PresupuestoDetalles
                .Where(pd => pd.PresupuestoId == Id)
                .Include(pd => pd.Presupuesto)
                //.Include(pd => pd.OrdenCompra.Proveedor)
                //.Include(pd => pd.OrdenCompra.FormaPago)
                .Include(pd => pd.Producto)
                .ToListAsync();

            return Ok(presupuestoDetalle);
        }
    }
}
