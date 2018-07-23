using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TallerDeMotos.ConfiguracionDeEntidades;
using TallerDeMotos.Models.ModelosDeDominio;
using System.Collections.Generic;

namespace TallerDeMotos.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public ICollection<FacturaCompra> FacturaCompras { get; set; }
        public ICollection<Presupuesto> Presupuestos { get; set; }
        public ICollection<FacturaVenta> FacturaVentas { get; set; }
        public ICollection<OrdenCompra> OrdenCompras { get; set; }
        public ICollection<Caja> Cajas { get; set; }

        public ApplicationUser()
        {
            FacturaCompras = new HashSet<FacturaCompra>();
            Presupuestos = new HashSet<Presupuesto>();
            FacturaVentas = new HashSet<FacturaVenta>();
            OrdenCompras = new HashSet<OrdenCompra>();
            Cajas = new HashSet<Caja>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("TallerDeMotos", throwIfV1Schema: false)
        {
        }

        public DbSet<Personeria> Personerias { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Combustible> Combustibles { get; set; }
        public DbSet<Aseguradora> Aseguradoras { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<FormaPago> FormasPago { get; set; }
        public DbSet<Talonario> Talonarios { get; set; }
        public DbSet<ServicioBasico> ServiciosBasicos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<TipoMotor> TiposMotores { get; set; }
        public DbSet<Cilindrada> Cilindradas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<OrdenCompra> OrdenCompras { get; set; }
        public DbSet<OrdenCompraDetalle> OrdenCompraDetalles { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<FacturaCompra> FacturaCompras { get; set; }
        public DbSet<FacturaCompraDetalle> FacturaCompraDetalles { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<OrdenCompraAnulada> OrdenCompraAnuladas { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<PresupuestoDetalle> PresupuestoDetalles { get; set; }
        public DbSet<FacturaVenta> FacturaVentas { get; set; }
        public DbSet<FacturaVentaDetalle> FacturaVentaDetalles { get; set; }
        public DbSet<ProductoTipo> ProductoTipos { get; set; }
        public DbSet<Caja> Cajas { get; set; }
        public DbSet<AperturaCierreCaja> CajaAperturaCierres { get; set; }
        public DbSet<TipoMovimiento> TipoMovimientos { get; set; }
        public DbSet<MovimientoCaja> MovimientoCajas { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<MovimientoCajaFormaPago> MovimientosFormaPagos { get; set; }
        public DbSet<MovimientoFormaPagoBanco> MovimientoFormaPagosBancos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<FacturaVentaCliente> FacturaVentaClientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PersoneriaConfiguracion());
            modelBuilder.Configurations.Add(new TipoDocumentoConfiguracion());
            modelBuilder.Configurations.Add(new ClienteConfiguracion());
            modelBuilder.Configurations.Add(new MarcaConfiguracion());
            modelBuilder.Configurations.Add(new ModeloConfiguracion());
            modelBuilder.Configurations.Add(new CombustibleConfiguracion());
            modelBuilder.Configurations.Add(new AseguradoraConfiguracion());
            modelBuilder.Configurations.Add(new VehiculoConfiguracion());
            modelBuilder.Configurations.Add(new CargoConfiguracion());
            modelBuilder.Configurations.Add(new EmpleadoConfiguracion());
            modelBuilder.Configurations.Add(new FormaPagoConfiguracion());
            modelBuilder.Configurations.Add(new TalonarioConfiguracion());
            modelBuilder.Configurations.Add(new ServicioBasicoConfiguracion());
            modelBuilder.Configurations.Add(new ProveedorConfiguracion());
            modelBuilder.Configurations.Add(new TipoMotorConfiguracion());
            modelBuilder.Configurations.Add(new CilindradaConfiguracion());
            modelBuilder.Configurations.Add(new ProductoConfiguracion());
            modelBuilder.Configurations.Add(new OrdenCompraConfiguracion());
            modelBuilder.Configurations.Add(new OrdenCompraDetalleConfiguracion());
            modelBuilder.Configurations.Add(new EstadoConfiguracion());
            modelBuilder.Configurations.Add(new FacturaCompraConfiguracion());
            modelBuilder.Configurations.Add(new FacturaCompraDetalleConfiguracion());
            modelBuilder.Configurations.Add(new CiudadConfiguracion());
            modelBuilder.Configurations.Add(new OrdenCompraAnuladaConfiguracion());
            modelBuilder.Configurations.Add(new PresupuestoConfiguracion());
            modelBuilder.Configurations.Add(new PresupuestoDetalleConfiguracion());
            modelBuilder.Configurations.Add(new FacturaVentaConfiguracion());
            modelBuilder.Configurations.Add(new FacturaVentaDetalleConfiguracion());
            modelBuilder.Configurations.Add(new ProductoTipoConfiguracion());
            modelBuilder.Configurations.Add(new CajaConfiguracion());
            modelBuilder.Configurations.Add(new AperturaCierreCajaConfiguracion());
            modelBuilder.Configurations.Add(new TipoMovimientoConfiguracion());
            modelBuilder.Configurations.Add(new MovimientoCajaConfiguracion());
            modelBuilder.Configurations.Add(new BancoConfiguracion());
            modelBuilder.Configurations.Add(new MovimientoFormaPagoConfiguracion());
            modelBuilder.Configurations.Add(new MovimientoFormaPagoBancoConfiguracion());
            modelBuilder.Configurations.Add(new EmpresaConfiguracion());
            modelBuilder.Configurations.Add(new SucursalConfiguracion());
            modelBuilder.Configurations.Add(new FacturaVentaClienteConfiguracion());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}