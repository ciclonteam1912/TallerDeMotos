using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models
{
    public class CargoServicio : IDisposable
    {
        private ApplicationDbContext entities;

        public CargoServicio()
        {
            entities = new ApplicationDbContext();
        }

        public IList<CargoDto> GetAll()
        {
            IList<CargoDto> result = new List<CargoDto>(); 

            result = entities.Cargos.Select(cargo => new CargoDto
            {
                Id = cargo.Id,
                Nombre = cargo.Nombre,
                Descripcion = cargo.Descripcion
            }).ToList();

            return result;
        }

        public IEnumerable<CargoDto> Read()
        {
            return GetAll();
        }

        public void Create(CargoDto cargo)
        {
            if (cargo.Id == 0)
            {
                var entity = new Cargo();

                entity.Nombre = cargo.Nombre;
                entity.Descripcion = cargo.Descripcion;

                entities.Cargos.Add(entity);
                entities.SaveChanges();

                cargo.Id = entity.Id;
            }
        }

        public void Update(CargoDto cargoDto)
        {
            try
            {
                var target = One(e => e.Id == cargoDto.Id);

                if (target != null)
                {
                    var entity = new Cargo();

                    entity.Id = cargoDto.Id;
                    entity.Nombre = cargoDto.Nombre;
                    entity.Descripcion = cargoDto.Descripcion;

                    entities.Cargos.Attach(entity);
                    entities.Entry(entity).State = EntityState.Modified;
                    entities.SaveChanges();
                }
            }
            catch(Exception ex)
            {
               
            }
        }

        public void Destroy(CargoDto cargoDto)
        {
            var entity = new Cargo();

            entity.Id = cargoDto.Id;
            entities.Cargos.Attach(entity);
            entities.Cargos.Remove(entity);
            entities.SaveChanges();                     
        }

        public CargoDto One(Func<CargoDto, bool> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}