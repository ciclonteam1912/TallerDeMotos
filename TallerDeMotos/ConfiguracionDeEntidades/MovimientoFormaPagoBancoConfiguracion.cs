using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class MovimientoFormaPagoBancoConfiguracion : EntityTypeConfiguration<MovimientoFormaPagoBanco>
    {
        public MovimientoFormaPagoBancoConfiguracion()
        {
            ToTable("MovimientoFormaPagosBancos");

            Property(m => m.Id)
                .HasColumnName("Codigo");

            Property(m => m.MovimientoCajaFormaPagoId)
                .HasColumnName("MovimientoFormaPagoCodigo");

            Property(m => m.BancoId)
                .HasColumnName("BancoCodigo");

            HasRequired(m => m.MovimientoCajaFormaPago)
                .WithMany(mfp => mfp.MovimientoFormaPagoBancos)
                .WillCascadeOnDelete(false);

            HasOptional(m => m.Banco)
                .WithMany(b => b.MovimientoFormaPagoBancos)
                .WillCascadeOnDelete(false);
        }
    }
}