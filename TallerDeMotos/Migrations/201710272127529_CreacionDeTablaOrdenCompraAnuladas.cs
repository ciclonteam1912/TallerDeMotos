namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaOrdenCompraAnuladas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrdenCompraAnuladas",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        OrdenCompraCodigo = c.Int(nullable: false),
                        MotivoAnulacion = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.OrdenCompras", t => t.OrdenCompraCodigo)
                .Index(t => t.OrdenCompraCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenCompraAnuladas", "OrdenCompraCodigo", "dbo.OrdenCompras");
            DropIndex("dbo.OrdenCompraAnuladas", new[] { "OrdenCompraCodigo" });
            DropTable("dbo.OrdenCompraAnuladas");
        }
    }
}
