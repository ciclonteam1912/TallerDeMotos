using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class ProductoTipoConfiguracion : EntityTypeConfiguration<ProductoTipo>
    {
        public ProductoTipoConfiguracion()
        {
            ToTable("ProductoTipos");

            Property(pt => pt.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(pt => pt.Productos)
                .WithRequired(p => p.ProductoTipo)
                .WillCascadeOnDelete(false);
        }
    }
}