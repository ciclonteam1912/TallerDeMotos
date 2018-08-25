using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
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

            Property(e => e.CiudadId)
                .HasColumnName("CiudadCodigo");

            Property(e => e.NumeroDocumento)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_NumeroDocumento", 1) { IsUnique = true }));

            HasRequired(e => e.Cargo)
                .WithMany(c => c.Empleados)
                .WillCascadeOnDelete(false);
        }
    }
}