namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaPresupuestoDetalles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PresupuestoDetalles",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        PresupuestoCodigo = c.Int(nullable: false),
                        ProductoCodigo = c.Int(nullable: false),
                        Cantidad = c.Byte(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Presupuestos", t => t.PresupuestoCodigo)
                .ForeignKey("dbo.Productos", t => t.ProductoCodigo)
                .Index(t => t.PresupuestoCodigo)
                .Index(t => t.ProductoCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PresupuestoDetalles", "ProductoCodigo", "dbo.Productos");
            DropForeignKey("dbo.PresupuestoDetalles", "PresupuestoCodigo", "dbo.Presupuestos");
            DropIndex("dbo.PresupuestoDetalles", new[] { "ProductoCodigo" });
            DropIndex("dbo.PresupuestoDetalles", new[] { "PresupuestoCodigo" });
            DropTable("dbo.PresupuestoDetalles");
        }
    }
}
