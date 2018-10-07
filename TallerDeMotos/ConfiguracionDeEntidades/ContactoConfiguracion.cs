using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class ContactoConfiguracion : EntityTypeConfiguration<Contacto>
    {
        public ContactoConfiguracion()
        {
            ToTable("Contactos");

            Property(c => c.Id)
                .HasColumnName("Codigo");
        }
    }
}