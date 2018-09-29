using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models
{
    public class ProductoServicio : IDisposable
    {
        private ApplicationDbContext entities;

        public ProductoServicio()
        {
            entities = new ApplicationDbContext();
        }

        public IList<ProductoDto> GetAll()
        {
            IList<ProductoDto> result = new List<ProductoDto>();

            result = entities.Productos.Select(producto => new ProductoDto
            {
                Id = producto.Id,
                Descripcion = producto.Descripcion,
                PrecioCosto = producto.PrecioCosto,
                MarcaId = producto.MarcaId,
                TipoImpuesto = producto.TipoImpuesto
            }).ToList();

            return result;
        }


        public IEnumerable<ProductoDto> Read()
        {
            return GetAll();
        }

        public void Create(ProductoDto producto)
        {
            try
            {
                if (producto.Id == 0)
                {
                    var entity = new Producto();

                    entity.Descripcion = producto.Descripcion;
                    entity.PrecioCosto = producto.PrecioCosto;
                    entity.PrecioVenta = producto.PrecioCosto;
                    entity.MarcaId = producto.MarcaId;
                    entity.TipoImpuesto = producto.TipoImpuesto;
                    entity.ProductoTipoId = 1; //1 producto, 2 servicio

                    entities.Productos.Add(entity);
                    entities.SaveChanges();

                    producto.Id = entity.Id;
                }
            }
            catch (Exception ex){ }
            
        }

        public void Update(ProductoDto productoDto)
        {
            try
            {
                var target = One(e => e.Id == productoDto.Id);

                if (target != null)
                {
                    var entity = new Producto();

                    entity.Id = productoDto.Id;
                    entity.Descripcion = productoDto.Descripcion;
                    entity.MarcaId = productoDto.MarcaId;
                    entity.PrecioCosto = productoDto.PrecioCosto;
                    entity.PrecioVenta = entity.PrecioCosto;
                    entity.TipoImpuesto = productoDto.TipoImpuesto;
                    entity.ProductoTipoId = 1;

                    entities.Productos.Attach(entity);
                    entities.Entry(entity).State = EntityState.Modified;
                    entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public ProductoDto One(Func<ProductoDto, bool> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}