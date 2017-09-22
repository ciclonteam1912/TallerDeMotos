using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class CargoConfiguracion : EntityTypeConfiguration<Cargo>
    {
        public CargoConfiguracion()
        {
            ToTable("Cargos");

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Codigo");

            Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Descripcion)
                .HasMaxLength(255);
        }
    }
}