using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TallerDeMotos.ConfiguracionDeEntidades;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
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
            : base("DefaultConnection", throwIfV1Schema: false)
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
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}