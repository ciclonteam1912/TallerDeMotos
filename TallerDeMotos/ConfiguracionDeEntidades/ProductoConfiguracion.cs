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
        }
    }
}