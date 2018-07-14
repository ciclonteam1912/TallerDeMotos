using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class FacturaVentaConfiguracion : EntityTypeConfiguration<FacturaVenta>
    {
        public FacturaVentaConfiguracion()
        {
            ToTable("FacturaVentas");

            Property(fv => fv.Id)
                .HasColumnName("Codigo");

            Property(fv => fv.UsuarioId)
                .HasColumnName("UsuarioCodigo");

            Property(fv => fv.TalonarioId)
                .HasColumnName("TalonarioCodigo");

            Property(fv => fv.EstadoId)
                .HasColumnName("EstadoCodigo");

            HasOptional(fv => fv.Presupuesto)
                .WithOptionalDependent(p => p.FacturaVenta)
                .Map(m => m.MapKey("PresupuestoCodigo"));

            HasRequired(fv => fv.Talonario)
                .WithMany(t => t.FacturaVentas)
                .WillCascadeOnDelete(false);

            HasRequired(fv => fv.Usuario)
                .WithMany(u => u.FacturaVentas)
                .WillCascadeOnDelete(false);

            HasRequired(fv => fv.Estado)
                .WithMany(e => e.FacturaVentas)
                .WillCascadeOnDelete(false);
        }
    }
}