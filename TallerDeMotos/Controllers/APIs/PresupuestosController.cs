using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;
using System.Data.Entity;
using System.Linq;

namespace TallerDeMotos.Controllers.APIs
{
    public class PresupuestosController : ApiController
    {
        private ApplicationDbContext _context;

        public PresupuestosController()
        {
            _context = new ApplicationDbContext();
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        [HttpGet]
        public IHttpActionResult ObtenerPresupuestos()
        {
            var presupuestos = _context.Presupuestos
                .Include(p => p.Vehiculo)
                .Include(p => p.Vehiculo.Cliente)
                .Include(p => p.Vehiculo.Modelo.Marca)
                .Include(p => p.Estado)                
                .ToList()
                .OrderByDescending(p => p.Id);

            return Ok(presupuestos);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        [HttpPost]
        public IHttpActionResult CrearPresupuesto(NuevoPresupuestoDto nuevoPresupuestoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var presupuestoDto = new PresupuestoDto
            {
                FechaDeEmision = nuevoPresupuestoDto.Presupuesto.FechaDeEmision,
                VehiculoId = nuevoPresupuestoDto.Presupuesto.VehiculoId,
                TotalExenta = nuevoPresupuestoDto.Presupuesto.TotalExenta,
                TotalIvaCincoPorCiento = nuevoPresupuestoDto.Presupuesto.TotalIvaCincoPorCiento,
                TotalIvaDiezPorCiento = nuevoPresupuestoDto.Presupuesto.TotalIvaDiezPorCiento,
                SubTotal = nuevoPresupuestoDto.Presupuesto.SubTotal,
                EstadoId = 1,
                UsuarioId = User.Identity.GetUserId()
            };

            var presupuesto = Mapper.Map<PresupuestoDto, Presupuesto>(presupuestoDto);
            _context.Presupuestos.Add(presupuesto);

            foreach (var detalle in nuevoPresupuestoDto.PresupuestoDetalles)
            {
                var presupuestoDetalleDto = new PresupuestoDetalleDto
                {
                    ProductoId = detalle.ProductoId,
                    Cantidad = detalle.Cantidad,
                    Total = detalle.Total,
                    TotalLineaExenta = detalle.TotalLineaExenta,
                    TotalLineaCincoXCiento = detalle.TotalLineaCincoXCiento,
                    TotalLineaDiezXCiento = detalle.TotalLineaDiezXCiento
                };

                var presupuestoDetalle = Mapper.Map<PresupuestoDetalleDto, PresupuestoDetalle>(presupuestoDetalleDto);
                _context.PresupuestoDetalles.Add(presupuestoDetalle);
            }

            _context.SaveChanges();

            var resultado = Mapper.Map<Presupuesto, PresupuestoDto>(presupuesto);

            return Ok(new JsonResponse { Success = true, Message = "Presupuesto creado con éxito", Id = resultado.Id });
        }
    }
}
