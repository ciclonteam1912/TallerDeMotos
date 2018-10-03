namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CargarDatosEnTablaProductoTipos2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ProductoTipos (Descripcion, PorcentajeGanancia) VALUES ('Accesorios', 10)");
            Sql("INSERT INTO ProductoTipos (Descripcion, PorcentajeGanancia) VALUES ('Repuesto', 10)");
            Sql("UPDATE ProductoTipos SET PorcentajeGanancia = 10 WHERE Descripcion = 'Producto'");
        }
        
        public override void Down()
        {
            Sql("UPDATE ProductoTipos SET PorcentajeGanancia = null WHERE Descripcion = 'Producto'");
            Sql("DELETE FROM ProductoTipos WHERE Descripcion IN ('Accesorios', 'Repuesto')");
        }
    }
}
