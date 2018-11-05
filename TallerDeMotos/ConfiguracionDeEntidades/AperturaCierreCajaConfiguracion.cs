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

            Property(ac => ac.UsuarioId)
               .HasColumnName("UsuarioCodigo");

            HasRequired(ac => ac.Caja)
                .WithMany(c => c.AperturaCierres)
                .WillCascadeOnDelete(false);

            HasRequired(t => t.Usuario)
                .WithMany(u => u.AperturaCierresCajas)
                .WillCascadeOnDelete(false);
        }
    }
}