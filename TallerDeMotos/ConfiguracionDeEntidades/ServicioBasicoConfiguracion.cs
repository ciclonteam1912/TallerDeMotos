using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class ServicioBasicoConfiguracion : EntityTypeConfiguration<ServicioBasico>
    {
        public ServicioBasicoConfiguracion()
        {
            ToTable("ServiciosBasicos");

            Property(sb => sb.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}