using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class PresupuestoDetalleConfiguracion : EntityTypeConfiguration<PresupuestoDetalle>
    {
        public PresupuestoDetalleConfiguracion()
        {
            ToTable("PresupuestoDetalles");

            Property(pd => pd.Id)
                .HasColumnName("Codigo");

            Property(pd => pd.PresupuestoId)
                .HasColumnName("PresupuestoCodigo");

            Property(pd => pd.ProductoId)
                .HasColumnName("ProductoCodigo");

            HasRequired(pd => pd.Presupuesto)
                .WithMany(p => p.PresupuestoDetalles)
                .WillCascadeOnDelete(false);

            HasRequired(pd => pd.Producto)
                .WithMany(p => p.PresupuestoDetalles)
                .WillCascadeOnDelete(false);
        }
    }
}