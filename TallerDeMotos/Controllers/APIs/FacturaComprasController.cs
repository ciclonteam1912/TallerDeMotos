using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
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

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        [HttpGet]
        public IHttpActionResult ObtenerFacturaCompra()
        {
            var facturaCompra = _context.FacturaCompras
                .Include(fc => fc.OrdenCompra)
                .Include(fc => fc.OrdenCompra.Proveedor)
                .Include(fc => fc.OrdenCompra.FormaPago)
                .ToList()
                .Select(Mapper.Map<FacturaCompra, FacturaCompraDto>);

            return Ok(facturaCompra);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        [HttpPost]
        public IHttpActionResult CrearFacturaCompra(NuevaFacturaCompraDto nuevaFacturaCompraDto)
        {
            try
            {
                var facturaCompraDto = new FacturaCompraDto
                {
                    Id = nuevaFacturaCompraDto.FacturaCompraDto.Id,
                    FacturaNumero = nuevaFacturaCompraDto.FacturaCompraDto.FacturaNumero,
                    Timbrado = nuevaFacturaCompraDto.FacturaCompraDto.Timbrado,
                    FechaFacturaCompra = nuevaFacturaCompraDto.FacturaCompraDto.FechaFacturaCompra,
                    OrdenCompraId = nuevaFacturaCompraDto.FacturaCompraDto.OrdenCompraId,
                    Subtotal = nuevaFacturaCompraDto.FacturaCompraDto.Subtotal                    
                };

                var facturaCompra = Mapper.Map<FacturaCompraDto, FacturaCompra>(facturaCompraDto);
                _context.FacturaCompras.Add(facturaCompra);

                foreach (var detalle in nuevaFacturaCompraDto.FacturaCompraDetalles)
                {
                    var facturaCompraDetalleDto = new FacturaCompraDetalleDto
                    {
                        FacturaCompraId = nuevaFacturaCompraDto.FacturaCompraDto.Id,
                        ProductoId = detalle.ProductoId,
                        PrecioProducto = detalle.PrecioProducto,
                        Cantidad = detalle.Cantidad,
                        Total = detalle.Total
                    };                    

                    var facturaCompraDetalle = Mapper.Map<FacturaCompraDetalleDto, FacturaCompraDetalle>(facturaCompraDetalleDto);
                    _context.FacturaCompraDetalles.Add(facturaCompraDetalle);
                }


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
