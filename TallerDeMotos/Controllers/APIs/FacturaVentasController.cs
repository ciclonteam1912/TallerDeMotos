﻿using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers.APIs
{
    public class FacturaVentasController : ApiController
    {
        private ApplicationDbContext _context;
        private ConexionBD conexionBD;

        public FacturaVentasController()
        {
            _context = new ApplicationDbContext();
            conexionBD = new ConexionBD();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        [HttpPost]
        public IHttpActionResult CrearFacturaVenta(NuevaFacturaVentaDto nuevaFacturaVentaDto)
        {
            try
            {
                var facturaVentaDto = new FacturaVentaDto
                {
                    NumeroFactura = nuevaFacturaVentaDto.FacturaVentaDto.NumeroFactura,
                    TalonarioId = nuevaFacturaVentaDto.FacturaVentaDto.TalonarioId,
                    FechaFacturaVenta = nuevaFacturaVentaDto.FacturaVentaDto.FechaFacturaVenta,
                    SubTotal = nuevaFacturaVentaDto.FacturaVentaDto.SubTotal,
                    UsuarioId = User.Identity.GetUserId(),
                    EstadoId = 1
                };

                var facturaVenta = Mapper.Map<FacturaVentaDto, FacturaVenta>(facturaVentaDto);
                _context.FacturaVentas.Add(facturaVenta);

                if(nuevaFacturaVentaDto.FacturaVentaDto.PresupuestoCodigo > 0)
                {
                    var presupuesto = _context.Presupuestos.Find(nuevaFacturaVentaDto.FacturaVentaDto.PresupuestoCodigo);
                    _context.Presupuestos.Attach(presupuesto);
                    facturaVenta.Presupuesto = presupuesto;
                }

                foreach (var detalle in nuevaFacturaVentaDto.FacturaVentaDetalles)
                {
                   
                    var facturaVentaDetalleDto = new FacturaVentaDetalleDto
                    {                        
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
                if (ex.InnerException.Message.Contains(exceptionMessage))
                    return Json(new JsonResponse { Success = false, Message = exceptionMessage });
            }

            return Ok(new JsonResponse { Success = true, Message = "Factura de Venta registrada con éxito" });
        }
    }
}
