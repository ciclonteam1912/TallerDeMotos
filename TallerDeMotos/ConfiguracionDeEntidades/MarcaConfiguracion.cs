using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class MarcaConfiguracion : EntityTypeConfiguration<Marca>
    {
        public MarcaConfiguracion()
        {
            Property(m => m.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Nombre)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_NombreMarca", 1) { IsUnique = true }));

            HasMany(mar => mar.Modelos)
                .WithRequired(mod => mod.Marca)
                .WillCascadeOnDelete(false);
        }
    }
}