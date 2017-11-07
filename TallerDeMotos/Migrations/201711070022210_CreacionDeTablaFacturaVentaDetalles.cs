namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaFacturaVentaDetalles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FacturaVentaDetalles",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        FacturaVentaCodigo = c.Int(nullable: false),
                        ProductoCodigo = c.Int(nullable: false),
                        Precio = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.FacturaVentas", t => t.FacturaVentaCodigo)
                .ForeignKey("dbo.Productos", t => t.ProductoCodigo)
                .Index(t => t.FacturaVentaCodigo)
                .Index(t => t.ProductoCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturaVentaDetalles", "ProductoCodigo", "dbo.Productos");
            DropForeignKey("dbo.FacturaVentaDetalles", "FacturaVentaCodigo", "dbo.FacturaVentas");
            DropIndex("dbo.FacturaVentaDetalles", new[] { "ProductoCodigo" });
            DropIndex("dbo.FacturaVentaDetalles", new[] { "FacturaVentaCodigo" });
            DropTable("dbo.FacturaVentaDetalles");
        }
    }
}
