using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class ProductoConfiguracion : EntityTypeConfiguration<Producto>
    {
        public ProductoConfiguracion()
        {
            ToTable("Productos");

            Property(p => p.Id)
                .HasColumnName("Codigo");

            HasMany(prod => prod.Proveedores)
                .WithMany(prov => prov.Productos)
                .Map(m => {
                    m.MapLeftKey("ProductoCodigo");
                    m.MapRightKey("ProveedorCodigo");
                    m.ToTable("ProductoProveedores");
                });
        }
    }
}