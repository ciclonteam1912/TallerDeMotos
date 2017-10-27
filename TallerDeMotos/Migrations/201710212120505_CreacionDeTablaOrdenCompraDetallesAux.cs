namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaOrdenCompraDetallesAux : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrdenCompraDetallesAux",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        OrdenCompraCodigo = c.Int(nullable: false),
                        ProductoCodigo = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.OrdenCompras", t => t.OrdenCompraCodigo)
                .ForeignKey("dbo.Productos", t => t.ProductoCodigo)
                .Index(t => t.OrdenCompraCodigo)
                .Index(t => t.ProductoCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenCompraDetallesAux", "ProductoCodigo", "dbo.Productos");
            DropForeignKey("dbo.OrdenCompraDetallesAux", "OrdenCompraCodigo", "dbo.OrdenCompras");
            DropIndex("dbo.OrdenCompraDetallesAux", new[] { "ProductoCodigo" });
            DropIndex("dbo.OrdenCompraDetallesAux", new[] { "OrdenCompraCodigo" });
            DropTable("dbo.OrdenCompraDetallesAux");
        }
    }
}
