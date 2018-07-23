using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class FacturaVentaClienteConfiguracion : EntityTypeConfiguration<FacturaVentaCliente>
    {
        public FacturaVentaClienteConfiguracion()
        {
            ToTable("FacturaVentaClientes");

            Property(fvc => fvc.Id)
                .HasColumnName("Codigo");

            Property(fvc => fvc.FacturaVentaId)
                .HasColumnName("FacturaVentaCodigo");


            Property(fvc => fvc.ClienteId)
                .HasColumnName("ClienteCodigo");

            HasRequired(fvc => fvc.FacturaVenta)
                .WithMany(fv => fv.FacturaVentaClientes)
                .WillCascadeOnDelete(false);

            HasRequired(fvc => fvc.Cliente)
                .WithMany(c => c.FacturaVentaClientes)
                .WillCascadeOnDelete(false);
        }
    }
}