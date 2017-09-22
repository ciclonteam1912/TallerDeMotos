using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class TalonarioConfiguracion : EntityTypeConfiguration<Talonario>
    {
        public TalonarioConfiguracion()
        {
            Property(t => t.Id)
                .HasColumnName("Codigo");
        }
    }
}