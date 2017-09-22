using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class EmpleadoConfiguracion : EntityTypeConfiguration<Empleado>
    {
        public EmpleadoConfiguracion()
        {
            ToTable("Empleados");

            Property(e => e.Id)
                .HasColumnName("Codigo");

            Property(e => e.CargoId)
                .HasColumnName("CargoCodigo");

            HasRequired(e => e.Cargo)
                .WithMany(c => c.Empleados)
                .WillCascadeOnDelete(false);
        }
    }
}