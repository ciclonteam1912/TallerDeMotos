using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class AseguradoraConfiguracion : EntityTypeConfiguration<Aseguradora>
    {
        public AseguradoraConfiguracion()
        {
            Property(a => a.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}