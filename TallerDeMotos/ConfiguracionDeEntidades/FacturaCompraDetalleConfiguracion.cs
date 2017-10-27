using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class FacturaCompraDetalleConfiguracion : EntityTypeConfiguration<FacturaCompraDetalle>
    {
        public FacturaCompraDetalleConfiguracion()
        {
            ToTable("FacturaCompraDetalles");

            Property(fcd => fcd.Id)
                .HasColumnName("Codigo");

            Property(fcd => fcd.FacturaCompraId)
                .HasColumnName("FacturaCompraCodigo");

            Property(ocd => ocd.ProductoId)
                .HasColumnName("ProductoCodigo");

            HasRequired(fcd => fcd.FacturaCompra)
                .WithMany(fc => fc.FacturaCompraDetalles)
                .WillCascadeOnDelete(false);

            HasRequired(fcd => fcd.Producto)
                .WithMany(p => p.FacturaCompraDetalles)
                .WillCascadeOnDelete(false);
        }
    }
}