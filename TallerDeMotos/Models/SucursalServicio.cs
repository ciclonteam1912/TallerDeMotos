using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models
{
    public class SucursalServicio: IDisposable
    {
        private ApplicationDbContext entities;

        public SucursalServicio()
        {
            entities = new ApplicationDbContext();
        }

        public IList<SucursalDto> GetAll()
        {
            IList<SucursalDto> result = new List<SucursalDto>();

            result = entities.Sucursales.Select(sucursal => new SucursalDto
            {
                Id = sucursal.Id,
                Direccion = sucursal.Direccion,
                Telefono = sucursal.Telefono,
                CiudadId = sucursal.CiudadId,
                EmpresaId = sucursal.EmpresaId               
            }).ToList();

            return result;
        }

        public IEnumerable<SucursalDto> Read()
        {
            return GetAll();
        }

        public void Create(SucursalDto sucursalDto)
        {
            if (sucursalDto.Id == 0)
            {
                var entity = new Sucursal();
                Mapper.Map<SucursalDto, Sucursal>(sucursalDto, entity);

                try
                {
                    entities.Sucursales.Add(entity);
                    entities.SaveChanges();

                    sucursalDto.Id = entity.Id;
                }
                catch(Exception ex) { }                
            }
        }

        public void Update(SucursalDto sucursalDto)
        {
            try
            {
                var target = One(e => e.Id == sucursalDto.Id);

                if (target != null)
                {
                    var entity = new Sucursal();

                    Mapper.Map<SucursalDto, Sucursal>(sucursalDto, entity);

                    entities.Sucursales.Attach(entity);
                    entities.Entry(entity).State = EntityState.Modified;
                    entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public SucursalDto One(Func<SucursalDto, bool> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}