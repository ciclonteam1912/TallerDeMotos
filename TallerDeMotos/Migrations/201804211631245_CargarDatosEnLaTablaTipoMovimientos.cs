namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CargarDatosEnLaTablaTipoMovimientos : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TipoMovimientos (Descripcion) VALUES ('Ingreso')");
            Sql("INSERT INTO TipoMovimientos (Descripcion) VALUES ('Egreso')");
        }

        public override void Down()
        {
            Sql("DELETE FROM TipoMovimientos WHERE Descripcion IN ('Ingreso', 'Egreso')");

        }
    }
}
