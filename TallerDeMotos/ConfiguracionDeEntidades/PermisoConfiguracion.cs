using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class PermisoConfiguracion: EntityTypeConfiguration<Permisos>
    {
        public PermisoConfiguracion()
        {
            ToTable("AspNetPermissions");

            Property(p => p.Descripcion)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_DescripcionPermiso", 1) { IsUnique = true }));

            HasMany(p => p.Roles)
                .WithMany(r => r.Permisos)
                .Map(p => p.ToTable("AspNetRolePermissions"));
        }
    }
}