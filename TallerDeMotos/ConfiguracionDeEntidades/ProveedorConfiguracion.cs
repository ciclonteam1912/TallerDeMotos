using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class ProveedorConfiguracion : EntityTypeConfiguration<Proveedor>
    {
        public ProveedorConfiguracion()
        {
            ToTable("Proveedores");

            Property(p => p.Id)
                .HasColumnName("Codigo");
        }
    }
}