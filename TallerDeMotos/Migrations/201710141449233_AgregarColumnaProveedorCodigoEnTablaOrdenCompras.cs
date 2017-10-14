namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaProveedorCodigoEnTablaOrdenCompras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenCompras", "ProveedorCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.OrdenCompras", "ProveedorCodigo");
            AddForeignKey("dbo.OrdenCompras", "ProveedorCodigo", "dbo.Proveedores", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenCompras", "ProveedorCodigo", "dbo.Proveedores");
            DropIndex("dbo.OrdenCompras", new[] { "ProveedorCodigo" });
            DropColumn("dbo.OrdenCompras", "ProveedorCodigo");
        }
    }
}
