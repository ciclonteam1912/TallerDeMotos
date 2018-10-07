using AutoMapper;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;

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
                .ForMember(v => v.FechaDeIngreso, opt => opt.Ignore())
                .ForMember(e => e.Aseguradora, opt => opt.Ignore());
            Mapper.CreateMap<FormaPago, FormaPago>();
            Mapper.CreateMap<Talonario, Talonario>();
            Mapper.CreateMap<ServicioBasico, ServicioBasico>();
            Mapper.CreateMap<Proveedor, Proveedor>();
            Mapper.CreateMap<Producto, Producto>()
                .ForMember(e => e.Marca, opt => opt.Ignore()); ;
            Mapper.CreateMap<Caja, Caja>();
            Mapper.CreateMap<AperturaCierreCaja, AperturaCierreCaja>();
            Mapper.CreateMap<ProveedorContactoDto, ProveedorContacto>();

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
            Mapper.CreateMap<Banco, BancoDto>();
            Mapper.CreateMap<MovimientoCaja, MovimientoCajaDto>();
            Mapper.CreateMap<AperturaCierreCaja, AperturaCierreDto>();
            Mapper.CreateMap<FacturaVenta, FacturaVentaDto>();
            Mapper.CreateMap<TipoMovimiento, TipoMovimientoDto>();
            Mapper.CreateMap<Caja, CajaDto>();
            Mapper.CreateMap<Empresa, EmpresaDto>();
            Mapper.CreateMap<Sucursal, SucursalDto>();
            Mapper.CreateMap<Cargo, CargoDto>();
            Mapper.CreateMap<ProveedorContacto, ProveedorContactoDto>();

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
            Mapper.CreateMap<MovimientoCajaViewModel, MovimientoCaja>();
            Mapper.CreateMap<MovimientoCajaViewModel, MovimientoFormaPagoBanco>();
            Mapper.CreateMap<SucursalDto, Sucursal>()
                .ForMember(s => s.Ciudad, opt => opt.Ignore())
                .ForMember(s => s.Empresa, opt => opt.Ignore())
                .ForMember(s => s.CiudadId, opt => opt.MapFrom(src => src.Ciudad.Id))
                .ForMember(s => s.EmpresaId, opt => opt.MapFrom(src => src.Empresa.Id));
            Mapper.CreateMap<EmpresaDto, Empresa>();
            Mapper.CreateMap<ProveedorDto, Proveedor>();
            Mapper.CreateMap<ProveedorContactoDto, ProveedorContacto>();
            Mapper.CreateMap<ProveedorViewModel, Proveedor>();
        }
    }
}