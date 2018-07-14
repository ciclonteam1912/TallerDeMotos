namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EliminarTablaFacturaVentaDetalles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FacturaVentaDetalles", "ProductoCodigo", "dbo.Productos");
            DropIndex("dbo.FacturaVentaDetalles", new[] { "ProductoCodigo" });
            DropTable("dbo.FacturaVentaDetalles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FacturaVentaDetalles",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        ProductoCodigo = c.Int(nullable: false),
                        Precio = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateIndex("dbo.FacturaVentaDetalles", "ProductoCodigo");
            AddForeignKey("dbo.FacturaVentaDetalles", "ProductoCodigo", "dbo.Productos", "Codigo");
        }
    }
}
