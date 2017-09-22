using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class FormaPagoConfiguracion : EntityTypeConfiguration<FormaPago>
    {
        public FormaPagoConfiguracion()
        {
            ToTable("FormasPago");

            Property(fp => fp.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}