using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class VehiculoConfiguracion : EntityTypeConfiguration<Vehiculo>
    {
        public VehiculoConfiguracion()
        {
            ToTable("Vehiculos");

            Property(v => v.Id)
                .HasColumnName("Codigo");

            Property(v => v.Matricula)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_Matricula", 1) { IsUnique = true }));

            Property(v => v.Chasis)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_Chasis", 2) { IsUnique = true }));            

            Property(v => v.AseguradoraId)
                .HasColumnName("AseguradoraCodigo");

            Property(v => v.CilindradaId)
                .HasColumnName("CilindradaCodigo");

            Property(v => v.ClienteId)
                .HasColumnName("ClienteCodigo");

            Property(v => v.CombustibleId)
                .HasColumnName("CombustibleCodigo");

            Property(v => v.ModeloId)
                .HasColumnName("ModeloCodigo");

            Property(v => v.TipoMotorId)
                .HasColumnName("TipoMotorCodigo");

            HasRequired(v => v.Aseguradora)
                .WithMany(a => a.Vehiculos)
                .WillCascadeOnDelete(false);

            HasRequired(v => v.Cilindrada)
                .WithMany(c => c.Vehiculos)
                .WillCascadeOnDelete(false);

            HasRequired(v => v.Combustible)
                .WithMany(c => c.Vehiculos)
                .WillCascadeOnDelete(false);

            HasRequired(v => v.Cliente)
                .WithMany(c => c.Vehiculos)
                .WillCascadeOnDelete(false);
            
            HasRequired(v => v.Modelo)
                .WithMany(m => m.Vehiculos)
                .WillCascadeOnDelete(false);

            HasRequired(v => v.TipoMotor)
                .WithMany(tm => tm.Vehiculos)
                .WillCascadeOnDelete(false);
        }
    }
}