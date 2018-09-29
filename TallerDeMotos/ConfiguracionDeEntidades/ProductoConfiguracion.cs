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

            Property(p => p.ProductoTipoId)
                .HasColumnName("ProductoTipoCodigo");

            HasMany(prod => prod.Proveedores)
                .WithMany(prov => prov.Productos)
                .Map(m => {
                    m.MapLeftKey("ProductoCodigo");
                    m.MapRightKey("ProveedorCodigo");
                    m.ToTable("ProductoProveedores");
                });

            HasOptional(p => p.Marca)
                           .WithOptionalDependent(p => p.Producto)
                           .Map(m => m.MapKey("MarcaCodigo"));
        }
    }
}