namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarTablaFacturaVentaClientes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FacturaVentaClientes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        FacturaVentaCodigo = c.Int(nullable: false),
                        ClienteCodigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Clientes", t => t.ClienteCodigo)
                .ForeignKey("dbo.FacturaVentas", t => t.FacturaVentaCodigo)
                .Index(t => t.FacturaVentaCodigo)
                .Index(t => t.ClienteCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturaVentaClientes", "FacturaVentaCodigo", "dbo.FacturaVentas");
            DropForeignKey("dbo.FacturaVentaClientes", "ClienteCodigo", "dbo.Clientes");
            DropIndex("dbo.FacturaVentaClientes", new[] { "ClienteCodigo" });
            DropIndex("dbo.FacturaVentaClientes", new[] { "FacturaVentaCodigo" });
            DropTable("dbo.FacturaVentaClientes");
        }
    }
}
