using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class TalonarioConfiguracion : EntityTypeConfiguration<Talonario>
    {
        public TalonarioConfiguracion()
        {
            Property(t => t.Id)
                .HasColumnName("Codigo");

            Property(t => t.CajaId)
                .HasColumnName("CajaCodigo");

            HasRequired(t => t.Caja)
                .WithMany(c => c.Talonarios)
                .WillCascadeOnDelete(false);
        }
    }
}