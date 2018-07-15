using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class EmpresaConfiguracion : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfiguracion()
        {
            ToTable("Empresas");

            Property(e => e.Id)
                .HasColumnName("Codigo");
        }
    }
}