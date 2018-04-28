using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class TipoMovimientoConfiguracion : EntityTypeConfiguration<TipoMovimiento>
    {
        public TipoMovimientoConfiguracion()
        {
            ToTable("TipoMovimientos");

            Property(tm => tm.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}