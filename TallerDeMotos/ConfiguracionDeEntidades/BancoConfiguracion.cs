using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class BancoConfiguracion : EntityTypeConfiguration<Banco>
    {
        public BancoConfiguracion()
        {
            ToTable("Bancos");

            Property(b => b.Id)
                .HasColumnName("Codigo");
        }
    }
}