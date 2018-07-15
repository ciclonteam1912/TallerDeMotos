using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class SucursalConfiguracion : EntityTypeConfiguration<Sucursal>
    {
        public SucursalConfiguracion()
        {
            ToTable("Sucursales");

            Property(s => s.Id)
                .HasColumnName("Codigo");

            Property(s => s.EmpresaId)
                .HasColumnName("EmpresaCodigo");

            Property(s => s.CiudadId)
                .HasColumnName("CiudadCodigo");

            HasRequired(s => s.Empresa)
                .WithMany(e => e.Sucursales)
                .WillCascadeOnDelete(false);

            HasRequired(s => s.Ciudad)
                .WithMany(c => c.Sucursales)
                .WillCascadeOnDelete(false);
        }
    }
}