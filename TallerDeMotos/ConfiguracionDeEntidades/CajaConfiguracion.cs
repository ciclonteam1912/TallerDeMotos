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

            HasRequired(t => t.Usuario)
                .WithMany(u => u.Cajas)
                .WillCascadeOnDelete(false);
        }
    }
}