using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class ModeloConfiguracion : EntityTypeConfiguration<Modelo>
    {
        public ModeloConfiguracion()
        {
            ToTable("Modelos");

            Property(m => m.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.MarcaId)
                .HasColumnName("MarcaCodigo");            
        }
    }
}