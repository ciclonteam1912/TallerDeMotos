using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class TipoDocumentoConfiguracion : EntityTypeConfiguration<TipoDocumento>
    {
        public TipoDocumentoConfiguracion()
        {
            ToTable("TipoDocumentos");

            Property(tp => tp.Id)
            .HasColumnName("Codigo")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(tp => tp.Descripcion)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}