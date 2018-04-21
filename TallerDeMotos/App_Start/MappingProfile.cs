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
            Mapper.CreateMap<Caja, Caja>();
            Mapper.CreateMap<AperturaCierreCaja, AperturaCierreCaja>();

            //Dominio a DTO
            Mapper.CreateMap<OrdenCompra, OrdenCompraDto>();
            Mapper.CreateMap<Estado, EstadoDto>();
            Mapper.CreateMap<Aseguradora, AseguradoraDto>();
            Mapper.CreateMap<FormaPago, FormaPagoDto>();
            Mapper.CreateMap<Proveedor, ProveedorDto>();
            Mapper.CreateMap<FacturaCompra, FacturaCompraDto>();
            Mapper.CreateMap<Ciudad, CiudadDto>();
            Mapper.CreateMap<Presupuesto, PresupuestoDto>();
            Mapper.CreateMap<Vehiculo, VehiculoDto>();
            Mapper.CreateMap<Cliente, ClienteDto>();

            //DTO a Dominio
            Mapper.CreateMap<OrdenCompraDto, OrdenCompra>();
            Mapper.CreateMap<OrdenCompraDetalleDto, OrdenCompraDetalle>();
            Mapper.CreateMap<EstadoDto, Estado>();
            Mapper.CreateMap<FacturaCompraDto, FacturaCompra>();
            Mapper.CreateMap<FacturaCompraDetalleDto, FacturaCompraDetalle>();
            Mapper.CreateMap<CiudadDto, Ciudad>();
            Mapper.CreateMap<PresupuestoDto, Presupuesto>();
            Mapper.CreateMap<PresupuestoDetalleDto, PresupuestoDetalle>();
            Mapper.CreateMap<FacturaVentaDto, FacturaVenta>();
            Mapper.CreateMap<FacturaVentaDetalleDto, FacturaVentaDetalle>();
        }
    }
}