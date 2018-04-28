using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class MovimientoCajaConfiguracion : EntityTypeConfiguration<MovimientoCaja>
    {
        public MovimientoCajaConfiguracion()
        {
            ToTable("MovimientoCajas");

            Property(mc => mc.Id)
                .HasColumnName("Codigo");

            Property(mc => mc.AperturaCierreCajaId)
                .HasColumnName("AperturaCierreCodigo");

            Property(mc => mc.FacturaCompraId)
                .HasColumnName("FacturaCompraCodigo");

            Property(mc => mc.TipoMovimientoId)
                .HasColumnName("TipoMovimientoCodigo");

            HasRequired(mc => mc.AperturaCierreCaja)
                .WithMany(ac => ac.MovimientoCajas)
                .WillCascadeOnDelete(false);

            HasRequired(mc => mc.FacturaCompra)
                .WithMany(fc => fc.MovimientoCajas)
                .WillCascadeOnDelete(false);

            HasRequired(mc => mc.TipoMovimiento)
                .WithMany(tm => tm.MovimientoCajas)
                .WillCascadeOnDelete(false);
        }
    }
}