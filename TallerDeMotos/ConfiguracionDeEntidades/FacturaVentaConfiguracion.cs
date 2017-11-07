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

            Property(fv => fv.PresupuestoId)
                .HasColumnName("PresupuestoCodigo");

            Property(fv => fv.TalonarioId)
                .HasColumnName("TalonarioCodigo");

            HasRequired(fv => fv.Presupuesto)
                .WithRequiredDependent(p => p.FacturaVenta)
                .WillCascadeOnDelete(false);

            HasRequired(fv => fv.Talonario)
                .WithMany(t => t.FacturaVentas)
                .WillCascadeOnDelete(false);

            HasRequired(fv => fv.Usuario)
                .WithMany(u => u.FacturaVentas)
                .WillCascadeOnDelete(false);
        }
    }
}