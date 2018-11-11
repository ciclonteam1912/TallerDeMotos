using AutoMapper;
using Microsoft.AspNet.Identity;
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
    public class FacturaVentasController : ApiController
    {
        private ApplicationDbContext _context;
        private ConexionBD conexionBD;
        private int SubTotal;
        private int TotalExentas;
        private int TotalIvaCincoXCiento;
        private int TotalIvaDiezXCiento;

        public FacturaVentasController()
        {
            _context = new ApplicationDbContext();
            conexionBD = new ConexionBD();
            SubTotal = 0;
            TotalExentas = 0;
            TotalIvaCincoXCiento = 0;
            TotalIvaDiezXCiento = 0;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        [HttpGet]
        public IHttpActionResult ObtenerFacturaVentas()
        {
            var facturaVentas = _context.FacturaVentas
                .Include(fc => fc.Presupuesto.Vehiculo.Cliente)
                .Include(fc => fc.Presupuesto.Vehiculo.Modelo.Marca)
                .Include(fc => fc.Usuario)
                .Include(fc => fc.Talonario.Caja)
                .ToList()
                .OrderByDescending(fc => fc.FechaFacturaVenta);

            return Ok(facturaVentas);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        [HttpPost]
        public IHttpActionResult CrearFacturaVenta(NuevaFacturaVentaDto nuevaFacturaVentaDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuarioId = User.Identity.GetUserId();
                    var caja = _context.CajaAperturaCierres.Where(c => c.UsuarioId == usuarioId && c.EstaAbierta).SingleOrDefault();
                    
                    if (caja != null)
                    {
                        var talonario = _context.Talonarios
                        .Where(t => t.EstaActivo && t.CajaId == caja.CajaId)
                        .Select(t => new { t.Id, t.NumeroFacturaActual })
                        .SingleOrDefault();

                        if (talonario != null)
                        {
                            foreach (var facturaDetalle in nuevaFacturaVentaDto.FacturaVentaDetalles)
                            {
                                TotalExentas += facturaDetalle.TotalLineaExenta;
                                TotalIvaCincoXCiento += facturaDetalle.TotalLineaCincoXCiento;
                                TotalIvaDiezXCiento += facturaDetalle.TotalLineaDiezXCiento;
                                SubTotal += (facturaDetalle.TotalLineaExenta + facturaDetalle.TotalLineaCincoXCiento + TotalIvaDiezXCiento);
                            }

                            var facturaVentaDto = new FacturaVentaDto
                            {
                                NumeroFactura = talonario.NumeroFacturaActual,
                                TalonarioId = talonario.Id,
                                FechaFacturaVenta = DateTime.Now,
                                SubTotal = SubTotal,//nuevaFacturaVentaDto.FacturaVentaDto.SubTotal,
                                TotalExenta = TotalExentas,//nuevaFacturaVentaDto.FacturaVentaDto.TotalExenta,
                                TotalCincoPorCiento = (TotalIvaCincoXCiento/21),//nuevaFacturaVentaDto.FacturaVentaDto.TotalCincoPorCiento,
                                TotalDiezPorCiento = (TotalIvaDiezXCiento/11),//nuevaFacturaVentaDto.FacturaVentaDto.TotalDiezPorCiento,
                                UsuarioId = User.Identity.GetUserId(),
                                EstadoId = 1
                            };

                            var facturaVenta = Mapper.Map<FacturaVentaDto, FacturaVenta>(facturaVentaDto);
                            _context.FacturaVentas.Add(facturaVenta);

                            if (nuevaFacturaVentaDto.ClienteId > 0)
                            {
                                var facturaVentaCliente = new FacturaVentaCliente
                                {
                                    VehiculoId = nuevaFacturaVentaDto.VehiculoId ?? default(int)
                                };
                                _context.FacturaVentaClientes.Add(facturaVentaCliente);
                            }

                            if (nuevaFacturaVentaDto.PresupuestoCodigo > 0)
                            {
                                var presupuesto = _context.Presupuestos.Find(nuevaFacturaVentaDto.PresupuestoCodigo);
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
                                    Total = detalle.Total,
                                    TotalLineaExenta = detalle.TotalLineaExenta,
                                    TotalLineaCincoXCiento = detalle.TotalLineaCincoXCiento,
                                    TotalLineaDiezXCiento = detalle.TotalLineaDiezXCiento
                                };

                                var facturaVentaDetalle = Mapper.Map<FacturaVentaDetalleDto, FacturaVentaDetalle>(facturaVentaDetalleDto);
                                _context.FacturaVentaDetalles.Add(facturaVentaDetalle);
                            }

                            _context.SaveChanges();
                        }
                        else
                            return Json(new JsonResponse { Success = false, Message = "El Talonario de la factura no se encuentra activo" });
                    }
                    else
                        return Json(new JsonResponse { Success = false, Message = "Usuario no está habilitado para generar una factura" });
                }
                catch (Exception ex)
                {
                    var exceptionMessage = "PK_dbo.FacturaVentas";
                    if (ex.InnerException.Message.Contains(exceptionMessage))
                        return Json(new JsonResponse { Success = false, Message = exceptionMessage });
                }

                return Ok(new JsonResponse { Success = true, Message = "Factura de Venta registrada con éxito" });
            }
            return BadRequest();
        }
    }
}
