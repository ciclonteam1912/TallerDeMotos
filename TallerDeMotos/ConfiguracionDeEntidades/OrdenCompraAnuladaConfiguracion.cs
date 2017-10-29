using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class OrdenCompraAnuladaConfiguracion : EntityTypeConfiguration<OrdenCompraAnulada>
    {
        public OrdenCompraAnuladaConfiguracion()
        {
            ToTable("OrdenCompraAnuladas");

            Property(oca => oca.Id)
                .HasColumnName("Codigo");

            Property(oca => oca.OrdenCompraId)
                .HasColumnName("OrdenCompraCodigo");

            HasRequired(oca => oca.OrdenCompra)
                .WithMany(oc => oc.OrdenCompraAnuladas)
                .WillCascadeOnDelete(false);
        }
    }
}