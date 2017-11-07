using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using TallerDeMotos.Dtos;

namespace TallerDeMotos.Controllers.APIs
{
    public class FacturaVentasController : ApiController
    {
        private ApplicationDbContext _context;

        public FacturaVentasController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        [HttpPost]
        public IHttpActionResult CrearFacturaCompra(NuevaFacturaVentaDto nuevaFacturaVentaDto)
        {
            try
            {
                var facturaVentaDto = new FacturaVentaDto
                {
                    Id = nuevaFacturaVentaDto.FacturaVentaDto.Id,
                    PresupuestoId = nuevaFacturaVentaDto.FacturaVentaDto.PresupuestoId,
                    NumeroFactura = nuevaFacturaVentaDto.FacturaVentaDto.NumeroFactura,
                    TalonarioId = nuevaFacturaVentaDto.FacturaVentaDto.TalonarioId,
                    FechaFacturaVenta = nuevaFacturaVentaDto.FacturaVentaDto.FechaFacturaVenta,
                    SubTotal = nuevaFacturaVentaDto.FacturaVentaDto.SubTotal,
                    UsuarioId = User.Identity.GetUserId()
                };

                var facturaVenta = Mapper.Map<FacturaVentaDto, FacturaVenta>(facturaVentaDto);
                _context.FacturaVentas.Add(facturaVenta);

                foreach (var detalle in nuevaFacturaVentaDto.FacturaVentaDetalles)
                {
                    var facturaVentaDetalleDto = new FacturaVentaDetalleDto
                    {
                        FacturaVentaId = nuevaFacturaVentaDto.FacturaVentaDto.Id,
                        ProductoId = detalle.ProductoId,
                        Precio = detalle.Precio,
                        Cantidad = detalle.Cantidad,
                        Total = detalle.Total
                    };

                    var facturaVentaDetalle = Mapper.Map<FacturaVentaDetalleDto, FacturaVentaDetalle>(facturaVentaDetalleDto);
                    _context.FacturaVentaDetalles.Add(facturaVentaDetalle);
                }


                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                var exceptionMessage = "PK_dbo.FacturaVentas";
                if (ex.InnerException.InnerException.Message.Contains(exceptionMessage))
                    return Json(new JsonResponse { Success = false, Message = exceptionMessage });
            }

            return Ok(new JsonResponse { Success = true, Message = "Factura de Venta registrada con éxito" });
        }
    }
}
