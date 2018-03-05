using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.AtributosDeValidacion;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers.APIs
{
    public class OrdenComprasController : ApiController
    {
        private ApplicationDbContext _context;

        public OrdenComprasController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        [HttpGet]
        public IHttpActionResult ObtenerOrdenDeCompras()
        {
            var ordenCompras =  _context.OrdenCompras
                .Include(oc => oc.FormaPago)
                .Include(oc => oc.Proveedor)
                .Include(oc => oc.Estado)
                .ToList()
                .Select(Mapper.Map<OrdenCompra, OrdenCompraDto>)
                .OrderByDescending(oc => oc.Id);

            return Ok(ordenCompras);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        [HttpPost]
        //[ValidateModel]
        public IHttpActionResult CrearOrdenDeCompra(NuevaOrdenCompraDto nuevaOrdenCompraDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var ordenCompraDto = new OrdenCompraDto
                {
                    OrdenCompraNumero = nuevaOrdenCompraDto.OrdenCompra.OrdenCompraNumero,
                    FechaDeEmision = DateTime.Now,
                    FormaPagoId = nuevaOrdenCompraDto.OrdenCompra.FormaPagoId,
                    SubTotal = nuevaOrdenCompraDto.OrdenCompra.SubTotal,
                    EstadoId = 1,
                    ProveedorId = nuevaOrdenCompraDto.OrdenCompra.ProveedorId
                };

                var ordenCompra = Mapper.Map<OrdenCompraDto, OrdenCompra>(ordenCompraDto);
                _context.OrdenCompras.Add(ordenCompra);

                foreach (var detalle in nuevaOrdenCompraDto.OrdenCompraDetalles)
                {
                    var ordenCompraDetalleDto = new OrdenCompraDetalleDto
                    {

                        ProductoId = detalle.ProductoId,
                        Cantidad = detalle.Cantidad,
                        Total = detalle.Total
                    };

                    var ordenCompraDetalle = Mapper.Map<OrdenCompraDetalleDto, OrdenCompraDetalle>(ordenCompraDetalleDto);
                    _context.OrdenCompraDetalles.Add(ordenCompraDetalle);
                }

                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                var exceptionMessage = "IX_OrdenCompraNumero";
                if (ex.InnerException.InnerException.Message.Contains(exceptionMessage))
                    return Json(new JsonResponse { Success = false, Message = exceptionMessage });
                return BadRequest();
            }

            return Ok(new JsonResponse { Success = true, Message = "Orden de Compra creada con éxito" });
        }
    }
}
