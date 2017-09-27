using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class CilindradaConfiguracion : EntityTypeConfiguration<Cilindrada>
    {
        public CilindradaConfiguracion()
        {
            Property(p => p.Id)
            .HasColumnName("Codigo")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}