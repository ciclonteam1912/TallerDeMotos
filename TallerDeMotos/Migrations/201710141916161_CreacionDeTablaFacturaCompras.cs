namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaFacturaCompras : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FacturaCompras",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        Timbrado = c.Int(nullable: false),
                        FacturaNumero = c.Int(nullable: false),
                        FechaFacturaCompra = c.DateTime(nullable: false),
                        OrdenCompraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.OrdenCompras", t => t.Codigo)
                .Index(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturaCompras", "Codigo", "dbo.OrdenCompras");
            DropIndex("dbo.FacturaCompras", new[] { "Codigo" });
            DropTable("dbo.FacturaCompras");
        }
    }
}
