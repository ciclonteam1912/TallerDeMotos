using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class AperturaCierreCajaConfiguracion : EntityTypeConfiguration<AperturaCierreCaja>
    {
        public AperturaCierreCajaConfiguracion()
        {
            ToTable("CajaAperturaCierres");

            Property(ac => ac.Id)
                .HasColumnName("Codigo");

            Property(ac => ac.CajaId)
                .HasColumnName("CajaCodigo");

            HasRequired(ac => ac.Caja)
                .WithMany(c => c.AperturaCierres)
                .WillCascadeOnDelete(false);
        }
    }
}