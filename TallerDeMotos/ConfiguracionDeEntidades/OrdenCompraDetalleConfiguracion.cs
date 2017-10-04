using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class OrdenCompraDetalleConfiguracion : EntityTypeConfiguration<OrdenCompraDetalle>
    {
        public OrdenCompraDetalleConfiguracion()
        {
            ToTable("OrdenCompraDetalles");

            Property(ocd => ocd.Id)
                .HasColumnName("Codigo");

            Property(ocd => ocd.OrdenCompraId)
                .HasColumnName("OrdenCompraCodigo");

            Property(ocd => ocd.ProductoId)
                .HasColumnName("ProductoCodigo");

            HasRequired(ocd => ocd.OrdenCompra)
                .WithMany(oc => oc.OrdenCompraDetalles)
                .WillCascadeOnDelete(false);

            HasRequired(ocd => ocd.Producto)
                .WithMany(p => p.OrdenCompraDetalles)
                .WillCascadeOnDelete(false);
        }
    }
}