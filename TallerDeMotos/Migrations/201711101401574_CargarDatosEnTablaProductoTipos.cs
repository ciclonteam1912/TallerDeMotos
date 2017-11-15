namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CargarDatosEnTablaProductoTipos : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ProductoTipos (Descripcion) VALUES ('Producto')");
            Sql("INSERT INTO ProductoTipos (Descripcion) VALUES ('Servicio')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM ProductoTipos WHERE Descripcion IN ('Producto', 'Servicio')");
        }
    }
}
