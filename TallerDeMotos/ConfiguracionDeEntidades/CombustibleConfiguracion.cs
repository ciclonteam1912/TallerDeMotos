using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class CombustibleConfiguracion : EntityTypeConfiguration<Combustible>
    {
        public CombustibleConfiguracion()
        {
            Property(c => c.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}