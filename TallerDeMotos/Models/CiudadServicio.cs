using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models
{
    public class CiudadServicio : IDisposable
    {
        private ApplicationDbContext entities;

        public CiudadServicio()
        {
            entities = new ApplicationDbContext();
        }

        public IList<CiudadDto> GetAll()
        {
            IList<CiudadDto> result = new List<CiudadDto>(); 

            result = entities.Ciudades.Select(ciudad => new CiudadDto
            {
                Id = ciudad.Id,
                Nombre = ciudad.Nombre
            }).ToList();

            return result;
        }

        public IEnumerable<CiudadDto> Read()
        {
            return GetAll();
        }

        public void Create(CiudadDto ciudad)
        {
            if (ciudad.Id == 0)
            {
                var entity = new Ciudad();

                entity.Nombre = ciudad.Nombre;

                entities.Ciudades.Add(entity);
                entities.SaveChanges();

                ciudad.Id = entity.Id;
            }
        }

        public void Update(CiudadDto ciudadDto)
        {
            try
            {
                var target = One(e => e.Id == ciudadDto.Id);

                if (target != null)
                {
                    target.Nombre = ciudadDto.Nombre;

                    var entity = new Ciudad();

                    entity.Id = ciudadDto.Id;
                    entity.Nombre = ciudadDto.Nombre;

                    entities.Ciudades.Attach(entity);
                    entities.Entry(entity).State = EntityState.Modified;
                    entities.SaveChanges();
                }
            }
            catch(Exception ex)
            {
               
            }
        }

        public CiudadDto One(Func<CiudadDto, bool> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public void Destroy(CiudadDto ciudadDto)
        {
            var entity = new Ciudad();

            entity.Id = ciudadDto.Id;
            entities.Ciudades.Attach(entity);
            entities.Ciudades.Remove(entity);
            entities.SaveChanges();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}