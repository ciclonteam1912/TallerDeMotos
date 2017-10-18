using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers.APIs
{
    public class FacturaComprasController : ApiController
    {
        private ApplicationDbContext _context;

        public FacturaComprasController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerFacturaCompra()
        {
            var facturaCompra = _context.FacturaCompras
                .Include(fc => fc.OrdenCompra)
                .ToList()
                .Select(Mapper.Map<FacturaCompra, FacturaCompraDto>);

            return Ok(facturaCompra);
        }

        [HttpPost]
        public IHttpActionResult CrearFacturaCompra(FacturaCompraDto nuevaFacturaCompraDto)
        {
            try
            {
                var facturaCompraDto = new FacturaCompraDto
                {
                    Id = nuevaFacturaCompraDto.Id,
                    FacturaNumero = nuevaFacturaCompraDto.FacturaNumero,
                    Timbrado = nuevaFacturaCompraDto.Timbrado,
                    FechaFacturaCompra = nuevaFacturaCompraDto.FechaFacturaCompra,
                    OrdenCompraId = nuevaFacturaCompraDto.OrdenCompraId
                };

                var facturaCompra = Mapper.Map<FacturaCompraDto, FacturaCompra>(facturaCompraDto);
                _context.FacturaCompras.Add(facturaCompra);

                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                var exceptionMessage = "PK_dbo.FacturaCompras";
                if (ex.InnerException.InnerException.Message.Contains(exceptionMessage))
                    return Json(new JsonResponse { Success = false, Message = exceptionMessage });
            }

            return Ok(new JsonResponse { Success = true, Message = "Factura de Compra registrada con éxito" });
        }
    }
}
