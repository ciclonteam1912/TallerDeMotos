namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarDatosPorDefectoEnTablaCargos : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Cargos (Nombre) VALUES ('Mec�nico')");
            Sql("INSERT INTO Cargos (Nombre) VALUES ('Limpiador')");
            Sql("INSERT INTO Cargos (Nombre) VALUES ('Otro')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Cargos WHERE Nombre IN ('Mec�nico', 'Limpiador', 'Otro')");
        }
    }
}
