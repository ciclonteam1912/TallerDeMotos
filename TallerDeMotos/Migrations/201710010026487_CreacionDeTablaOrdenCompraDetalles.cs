namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaOrdenCompraDetalles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrdenCompraDetalles",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        OrdenCompraCodigo = c.Int(nullable: false),
                        ProductoCodigo = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.OrdenCompras", t => t.OrdenCompraCodigo)
                .ForeignKey("dbo.Productos", t => t.ProductoCodigo)
                .Index(t => t.OrdenCompraCodigo)
                .Index(t => t.ProductoCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenCompraDetalles", "ProductoCodigo", "dbo.Productos");
            DropForeignKey("dbo.OrdenCompraDetalles", "OrdenCompraCodigo", "dbo.OrdenCompras");
            DropIndex("dbo.OrdenCompraDetalles", new[] { "ProductoCodigo" });
            DropIndex("dbo.OrdenCompraDetalles", new[] { "OrdenCompraCodigo" });
            DropTable("dbo.OrdenCompraDetalles");
        }
    }
}
