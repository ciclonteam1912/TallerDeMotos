using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class ClienteConfiguracion : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguracion()
        {
            Property(c => c.Id)
            .HasColumnName("Codigo");

            Property(c => c.PersoneriaId)
            .HasColumnName("PersoneriaCodigo");

            Property(c => c.TipoDocumentoId)
            .HasColumnName("TipoDocumentoCodigo");

            HasRequired(c => c.Personeria)
                .WithMany(p => p.Clientes)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.TipoDocumento)
                .WithMany(td => td.Clientes)
                .WillCascadeOnDelete(false);
        }
    }
}