using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class CiudadConfiguracion : EntityTypeConfiguration<Ciudad>
    {
        public CiudadConfiguracion()
        {
            ToTable("Ciudades");
            Property(c => c.Nombre)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_NombreCiudad", 1) { IsUnique = true }));

            HasMany(a => a.Aseguradoras)
                .WithRequired(c => c.Ciudad)
                .WillCascadeOnDelete(false);

            HasMany(c => c.Clientes)
                .WithRequired(c => c.Ciudad)
                .WillCascadeOnDelete(false);
            
            HasMany(a => a.Empleados)
                .WithRequired(c => c.Ciudad)
                .WillCascadeOnDelete(false);

            HasMany(a => a.Proveedores)
                .WithRequired(c => c.Ciudad)
                .WillCascadeOnDelete(false);
        }
    }
}