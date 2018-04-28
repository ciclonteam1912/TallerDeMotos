using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class MovimientoFormaPagoConfiguracion : EntityTypeConfiguration<MovimientoCajaFormaPago>
    {
        public MovimientoFormaPagoConfiguracion()
        {
            ToTable("MovimientosFormaPagos");

            Property(m => m.Id)
                .HasColumnName("Codigo");

            Property(m => m.FormaPagoId)
                 .HasColumnName("FormaPagoCodigo");

            Property(m => m.MovimientoCajaId)
                .HasColumnName("MovimientoCajaCodigo");

            HasRequired(m => m.MovimientoCaja)
                .WithMany(mc => mc.MovimientosFormaPagos)
                .WillCascadeOnDelete(false);

            HasRequired(m => m.FormaPago)
                .WithMany(mc => mc.MovimientosFormaPagos)
                .WillCascadeOnDelete(false);
        }
    }
}