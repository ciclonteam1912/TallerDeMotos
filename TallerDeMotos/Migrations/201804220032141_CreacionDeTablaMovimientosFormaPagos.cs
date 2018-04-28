namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaMovimientosFormaPagos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovimientosFormaPagos",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        MovimientoCajaCodigo = c.Int(nullable: false),
                        FormaPagoCodigo = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.FormasPago", t => t.FormaPagoCodigo)
                .ForeignKey("dbo.MovimientoCajas", t => t.MovimientoCajaCodigo)
                .Index(t => t.MovimientoCajaCodigo)
                .Index(t => t.FormaPagoCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovimientosFormaPagos", "MovimientoCajaCodigo", "dbo.MovimientoCajas");
            DropForeignKey("dbo.MovimientosFormaPagos", "FormaPagoCodigo", "dbo.FormasPago");
            DropIndex("dbo.MovimientosFormaPagos", new[] { "FormaPagoCodigo" });
            DropIndex("dbo.MovimientosFormaPagos", new[] { "MovimientoCajaCodigo" });
            DropTable("dbo.MovimientosFormaPagos");
        }
    }
}
