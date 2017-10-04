namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CargarDatosEnLaTablaEstados : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Estados (Descripcion) VALUES ('Pendiente')");
            Sql("INSERT INTO Estados (Descripcion) VALUES ('Aceptado')");
            Sql("INSERT INTO Estados (Descripcion) VALUES ('Anulado')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Estados WHERE Descripcion IN ('Pendiente', 'Aceptado', 'Anulado')");
        }
    }
}
