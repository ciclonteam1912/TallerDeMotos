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

            Property(t => t.SucursalId)
                .HasColumnName("SucursalCodigo");

            HasRequired(t => t.Caja)
                .WithMany(c => c.Talonarios)
                .WillCascadeOnDelete(false);

            HasRequired(t => t.Sucursal)
                .WithMany(s => s.Talonarios)
                .WillCascadeOnDelete(false);
        }
    }
}