using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class PresupuestoConfiguracion : EntityTypeConfiguration<Presupuesto>
    {
        public PresupuestoConfiguracion()
        {
            ToTable("Presupuestos");

            Property(p => p.Id)
                .HasColumnName("Codigo");

            Property(p => p.VehiculoId)
                .HasColumnName("VehiculoCodigo");

            Property(p => p.EstadoId)
                .HasColumnName("EstadoCodigo");

            HasRequired(p => p.Estado)
                .WithMany(e => e.Presupuestos)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Usuario)
                .WithMany(u => u.Presupuestos)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Vehiculo)
                .WithMany(v => v.Presupuestos)
                .WillCascadeOnDelete(false);
        }
    }
}