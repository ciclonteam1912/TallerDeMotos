using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class TipoMotorConfiguracion : EntityTypeConfiguration<TipoMotor>
    {
        public TipoMotorConfiguracion()
        {
            ToTable("TiposMotores");

            Property(p => p.Id)
            .HasColumnName("Codigo")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}