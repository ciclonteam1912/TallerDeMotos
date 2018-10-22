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

            Property(fvc => fvc.VehiculoId)
                .HasColumnName("VehiculoCodigo");

            HasRequired(fvc => fvc.FacturaVenta)
                .WithMany(fv => fv.FacturaVentaClientes)
                .WillCascadeOnDelete(false);

            HasRequired(fvc => fvc.Vehiculo)
                .WithMany(v => v.FacturaVentaClientes)
                .WillCascadeOnDelete(false);
        }
    }
}