using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class ProveedorConfiguracion : EntityTypeConfiguration<Proveedor>
    {
        public ProveedorConfiguracion()
        {
            ToTable("Proveedores");

            Property(p => p.Id)
                .HasColumnName("Codigo");

            Property(c => c.CiudadId)
                .HasColumnName("CiudadCodigo");

            Property(p => p.Ruc)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_RucProveedor", 1) { IsUnique = true }));
        }
    }
}