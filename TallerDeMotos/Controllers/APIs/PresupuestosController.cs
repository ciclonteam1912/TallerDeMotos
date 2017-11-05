using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers.APIs
{
    public class PresupuestosController : ApiController
    {
        private ApplicationDbContext _context;

        public PresupuestosController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize(Roles = RoleName.Administrador)]
        [HttpPost]
        public IHttpActionResult CrearPresupuesto(NuevoPresupuestoDto nuevoPresupuestoDto)
        {
            var presupuestoDto = new PresupuestoDto
            {
                FechaDeEmision = nuevoPresupuestoDto.Presupuesto.FechaDeEmision,
                VehiculoId = nuevoPresupuestoDto.Presupuesto.VehiculoId,
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
                    Total = detalle.Total
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
