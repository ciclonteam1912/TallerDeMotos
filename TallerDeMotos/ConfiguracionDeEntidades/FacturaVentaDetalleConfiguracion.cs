using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class FacturaVentaDetalleConfiguracion : EntityTypeConfiguration<FacturaVentaDetalle>
    {
        public FacturaVentaDetalleConfiguracion()
        {
            ToTable("FacturaVentaDetalles");

            Property(fvd => fvd.Id)
                .HasColumnName("Codigo");

            Property(fvd => fvd.FacturaVentaId)
                .HasColumnName("FacturaVentaCodigo");

            Property(fvd => fvd.ProductoId)
                .HasColumnName("ProductoCodigo");

            HasRequired(fvd => fvd.FacturaVenta)
                .WithMany(fv => fv.FacturaVentaDetalles)
                .WillCascadeOnDelete(false);

            HasRequired(fvd => fvd.Producto)
                .WithMany(p => p.FacturaVentaDetalles)
                .WillCascadeOnDelete(false);
        }
    }
}