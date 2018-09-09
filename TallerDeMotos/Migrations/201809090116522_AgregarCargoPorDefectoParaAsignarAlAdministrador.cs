namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarCargoPorDefectoParaAsignarAlAdministrador : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Cargos (Nombre) VALUES ('Administrador')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Cargos WHERE Nombre IN ('Administrador')");
        }
    }
}
