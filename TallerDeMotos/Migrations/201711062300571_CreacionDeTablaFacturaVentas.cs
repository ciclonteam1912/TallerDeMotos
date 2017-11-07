namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaFacturaVentas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FacturaVentas",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        PresupuestoCodigo = c.Int(nullable: false),
                        TalonarioCodigo = c.Int(nullable: false),
                        FechaFacturaVenta = c.DateTime(nullable: false),
                        SubTotal = c.Int(nullable: false),
                        UsuarioId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Presupuestos", t => t.Codigo)
                .ForeignKey("dbo.Talonarios", t => t.Codigo)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.Codigo)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturaVentas", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FacturaVentas", "Codigo", "dbo.Talonarios");
            DropForeignKey("dbo.FacturaVentas", "Codigo", "dbo.Presupuestos");
            DropIndex("dbo.FacturaVentas", new[] { "UsuarioId" });
            DropIndex("dbo.FacturaVentas", new[] { "Codigo" });
            DropTable("dbo.FacturaVentas");
        }
    }
}
