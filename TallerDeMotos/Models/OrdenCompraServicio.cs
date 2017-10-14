using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models
{
    public class OrdenCompraServicio : IDisposable
    {
        private static bool UpdateDatabase = false;
        private ApplicationDbContext entities;

        public OrdenCompraServicio()
        {
            entities = new ApplicationDbContext();
        }

        public void Dispose()
        {
            entities.Dispose();
        }

        public IList<OrdenCompraDto> GetAll()
        {
            IList<OrdenCompraDto> result = new List<OrdenCompraDto>();

            result = entities.OrdenCompras.Select(oc => new OrdenCompraDto
            {
                Id = oc.Id,
                OrdenCompraNumero = oc.OrdenCompraNumero,
                FechaDeEmision = oc.FechaDeEmision,
                FormaPagoId = oc.FormaPagoId,
                ProveedorId = oc.ProveedorId,
                SubTotal = oc.SubTotal,
                EstadoId = oc.EstadoId,
                Estado = new EstadoDto()
                {
                    Id = oc.Estado.Id,
                    Descripcion = oc.Estado.Descripcion
                }
            }).ToList();


            return result;
        }

        public void Update(OrdenCompraDto ordenCompraDto)
        {
            try
            {
                var target = One(e => e.Id == ordenCompraDto.Id);

                if (target != null)
                {
                    target.OrdenCompraNumero = ordenCompraDto.OrdenCompraNumero;
                    target.FechaDeEmision = DateTime.Now;
                    target.ProveedorId = ordenCompraDto.ProveedorId;
                    target.FormaPagoId = ordenCompraDto.FormaPagoId;
                    target.SubTotal = ordenCompraDto.SubTotal;
                    target.EstadoId = ordenCompraDto.EstadoId;
                    target.Estado = ordenCompraDto.Estado;

                    var entity = new OrdenCompra();

                    entity.Id = target.Id;
                    entity.OrdenCompraNumero = target.OrdenCompraNumero;
                    entity.FechaDeEmision = target.FechaDeEmision;
                    entity.ProveedorId = target.ProveedorId;
                    entity.FormaPagoId = target.FormaPagoId;
                    entity.SubTotal = target.SubTotal;
                    entity.EstadoId = target.EstadoId;

                    if (target.Estado != null)
                    {
                        entity.EstadoId = target.Estado.Id;
                    }

                    entities.OrdenCompras.Attach(entity);
                    entities.Entry(entity).State = EntityState.Modified;
                    entities.SaveChanges();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public OrdenCompraDto One(Func<OrdenCompraDto, bool> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }
    }
}