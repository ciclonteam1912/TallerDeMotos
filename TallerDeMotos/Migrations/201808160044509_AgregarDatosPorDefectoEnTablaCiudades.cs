namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarDatosPorDefectoEnTablaCiudades : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Ciudades (Nombre) VALUES ('Asunci�n')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Ciudades WHERE Nombre IN ('Asunci�n')");
        }
    }
}
