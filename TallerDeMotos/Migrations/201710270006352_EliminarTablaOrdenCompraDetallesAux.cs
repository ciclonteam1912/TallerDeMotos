namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EliminarTablaOrdenCompraDetallesAux : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrdenCompraDetallesAux", "OrdenCompraCodigo", "dbo.OrdenCompras");
            DropForeignKey("dbo.OrdenCompraDetallesAux", "ProductoCodigo", "dbo.Productos");
            DropIndex("dbo.OrdenCompraDetallesAux", new[] { "OrdenCompraCodigo" });
            DropIndex("dbo.OrdenCompraDetallesAux", new[] { "ProductoCodigo" });
            DropTable("dbo.OrdenCompraDetallesAux");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Codigo);
            
            CreateIndex("dbo.OrdenCompraDetallesAux", "ProductoCodigo");
            CreateIndex("dbo.OrdenCompraDetallesAux", "OrdenCompraCodigo");
            AddForeignKey("dbo.OrdenCompraDetallesAux", "ProductoCodigo", "dbo.Productos", "Codigo");
            AddForeignKey("dbo.OrdenCompraDetallesAux", "OrdenCompraCodigo", "dbo.OrdenCompras", "Codigo");
        }
    }
}
