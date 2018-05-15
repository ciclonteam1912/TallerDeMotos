using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models
{
    public class BancoServicio : IDisposable
    {
        private ApplicationDbContext entities;

        public BancoServicio()
        {
            entities = new ApplicationDbContext();
        }

        public IList<BancoDto> GetAll()
        {
            IList<BancoDto> result = new List<BancoDto>(); 

            result = entities.Bancos.Select(banco => new BancoDto
            {
                Id = banco.Id,
                Nombre = banco.Nombre
            }).ToList();

            return result;
        }

        public IEnumerable<BancoDto> Read()
        {
            return GetAll();
        }

        public void Create(BancoDto banco)
        {
            if (banco.Id == 0)
            {
                var entity = new Banco();

                entity.Nombre = banco.Nombre;

                entities.Bancos.Add(entity);
                entities.SaveChanges();

                banco.Id = entity.Id;
            }
        }

        public void Update(BancoDto bancoDto)
        {
            try
            {
                var target = One(e => e.Id == bancoDto.Id);

                if (target != null)
                {
                    target.Nombre = bancoDto.Nombre;

                    var entity = new Banco();

                    entity.Id = bancoDto.Id;
                    entity.Nombre = bancoDto.Nombre;

                    entities.Bancos.Attach(entity);
                    entities.Entry(entity).State = EntityState.Modified;
                    entities.SaveChanges();
                }
            }
            catch(Exception ex)
            {
               
            }
        }

        public BancoDto One(Func<BancoDto, bool> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}