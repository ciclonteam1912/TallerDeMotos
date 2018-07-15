namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarDatosEnTablaEmpresas : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Empresas (RazonSocial, Ruc) VALUES ('Taller de Motos Pedrozo', '3222899-6')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Empresas WHERE RazonSocial IN ('Taller de Motos Pedrozo')");
        }
    }
}
