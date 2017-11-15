namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaProductoTipoCodigoEnTablaProductos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "ProductoTipoCodigo", c => c.Byte(nullable: false));
            CreateIndex("dbo.Productos", "ProductoTipoCodigo");
            AddForeignKey("dbo.Productos", "ProductoTipoCodigo", "dbo.ProductoTipos", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "ProductoTipoCodigo", "dbo.ProductoTipos");
            DropIndex("dbo.Productos", new[] { "ProductoTipoCodigo" });
            DropColumn("dbo.Productos", "ProductoTipoCodigo");
        }
    }
}
