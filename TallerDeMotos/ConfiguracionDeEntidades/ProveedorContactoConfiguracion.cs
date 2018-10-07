using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class ProveedorContactoConfiguracion: EntityTypeConfiguration<ProveedorContacto>
    {
        public ProveedorContactoConfiguracion()
        {
            ToTable("ProveedorContactos");

            Property(pc => pc.ProveedorId)
                .HasColumnName("ProveedorCodigo");

            Property(pc => pc.ContactoId)
                .HasColumnName("ContactoCodigo");
        }
    }
}