using AutoMapper;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Dominio a Dominio
            Mapper.CreateMap<Cliente, Cliente>()
                .ForMember(c => c.FechaDeIngreso, opt => opt.Ignore());
            Mapper.CreateMap<Modelo, Modelo>();
            Mapper.CreateMap<Marca, Marca>();
            Mapper.CreateMap<Combustible, Combustible>();
            Mapper.CreateMap<Aseguradora, Aseguradora>();
            Mapper.CreateMap<Empleado, Empleado>()
                .ForMember(e => e.FechaDeIngreso, opt => opt.Ignore());
        }
    }
}