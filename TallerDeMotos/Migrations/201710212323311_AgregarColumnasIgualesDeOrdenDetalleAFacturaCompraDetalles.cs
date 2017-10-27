namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnasIgualesDeOrdenDetalleAFacturaCompraDetalles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FacturaCompraDetalles", "ProductoCodigo", c => c.Int(nullable: false));
            AddColumn("dbo.FacturaCompraDetalles", "Cantidad", c => c.Int(nullable: false));
            AddColumn("dbo.FacturaCompraDetalles", "Total", c => c.Int(nullable: false));
            CreateIndex("dbo.FacturaCompraDetalles", "ProductoCodigo");
            AddForeignKey("dbo.FacturaCompraDetalles", "ProductoCodigo", "dbo.Productos", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturaCompraDetalles", "ProductoCodigo", "dbo.Productos");
            DropIndex("dbo.FacturaCompraDetalles", new[] { "ProductoCodigo" });
            DropColumn("dbo.FacturaCompraDetalles", "Total");
            DropColumn("dbo.FacturaCompraDetalles", "Cantidad");
            DropColumn("dbo.FacturaCompraDetalles", "ProductoCodigo");
        }
    }
}
