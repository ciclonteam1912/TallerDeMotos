namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaFacturaCompraDetalles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FacturaCompraDetalles",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        FacturaCompraCodigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.FacturaCompras", t => t.FacturaCompraCodigo)
                .Index(t => t.FacturaCompraCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturaCompraDetalles", "FacturaCompraCodigo", "dbo.FacturaCompras");
            DropIndex("dbo.FacturaCompraDetalles", new[] { "FacturaCompraCodigo" });
            DropTable("dbo.FacturaCompraDetalles");
        }
    }
}
