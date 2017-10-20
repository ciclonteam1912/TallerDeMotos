using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class CiudadConfiguracion : EntityTypeConfiguration<Ciudad>
    {
        public CiudadConfiguracion()
        {
            ToTable("Ciudades");

            HasMany(a => a.Aseguradoras)
                .WithRequired(c => c.Ciudad)
                .WillCascadeOnDelete(false);

            HasMany(c => c.Clientes)
                .WithRequired(c => c.Ciudad)
                .WillCascadeOnDelete(false);
            
            HasMany(a => a.Empleados)
                .WithRequired(c => c.Ciudad)
                .WillCascadeOnDelete(false);
        }
    }
}