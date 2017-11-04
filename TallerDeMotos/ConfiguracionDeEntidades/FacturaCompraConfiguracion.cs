using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class FacturaCompraConfiguracion : EntityTypeConfiguration<FacturaCompra>
    {
        public FacturaCompraConfiguracion()
        {
            ToTable("FacturaCompras");

            Property(fc => fc.Id)
                .HasColumnName("Codigo");            

            HasRequired(fc => fc.OrdenCompra)                
            .WithRequiredDependent(fc => fc.FacturaCompra)            
            .WillCascadeOnDelete(false);

            HasRequired(fc => fc.Usuario)
                .WithMany(u => u.FacturaCompras)
                .WillCascadeOnDelete(false);
        }
    }
}