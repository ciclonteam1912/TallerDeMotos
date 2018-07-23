using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class CajaConfiguracion : EntityTypeConfiguration<Caja>
    {
        public CajaConfiguracion()
        {
            ToTable("Cajas");

            Property(c => c.Id)
                .HasColumnName("Codigo");

            Property(c => c.UsuarioId)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_Usuario", 1) { IsUnique = true }));

            HasRequired(t => t.Usuario)
                .WithMany(u => u.Cajas)
                .WillCascadeOnDelete(false);
        }
    }
}