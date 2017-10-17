using AutoMapper;
using TallerDeMotos.Dtos;
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
            Mapper.CreateMap<Vehiculo, Vehiculo>()
                .ForMember(v => v.FechaDeIngreso, opt => opt.Ignore());
            Mapper.CreateMap<FormaPago, FormaPago>();
            Mapper.CreateMap<Talonario, Talonario>();
            Mapper.CreateMap<ServicioBasico, ServicioBasico>();
            Mapper.CreateMap<Proveedor, Proveedor>();
            Mapper.CreateMap<Producto, Producto>();

            //Dominio a DTO
            Mapper.CreateMap<OrdenCompra, OrdenCompraDto>();
            Mapper.CreateMap<Estado, EstadoDto>();
            Mapper.CreateMap<Aseguradora, AseguradoraDto>();
            Mapper.CreateMap<FormaPago, FormaPagoDto>();
            Mapper.CreateMap<Proveedor, ProveedorDto>();
            //DTO a Dominio
            Mapper.CreateMap<OrdenCompraDto, OrdenCompra>();
            Mapper.CreateMap<OrdenCompraDetalleDto, OrdenCompraDetalle>();
            Mapper.CreateMap<EstadoDto, Estado>();
            Mapper.CreateMap<FacturaCompraDto, FacturaCompra>();
        }
    }
}