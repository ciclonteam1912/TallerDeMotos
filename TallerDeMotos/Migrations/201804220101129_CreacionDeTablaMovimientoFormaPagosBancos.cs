namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaMovimientoFormaPagosBancos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovimientoFormaPagosBancos",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        MovimientoFormaPagoCodigo = c.Int(nullable: false),
                        BancoCodigo = c.Int(),
                        NroCheque = c.Int(),
                        NroAutorizacion = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Bancos", t => t.BancoCodigo)
                .ForeignKey("dbo.MovimientosFormaPagos", t => t.MovimientoFormaPagoCodigo)
                .Index(t => t.MovimientoFormaPagoCodigo)
                .Index(t => t.BancoCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovimientoFormaPagosBancos", "MovimientoFormaPagoCodigo", "dbo.MovimientosFormaPagos");
            DropForeignKey("dbo.MovimientoFormaPagosBancos", "BancoCodigo", "dbo.Bancos");
            DropIndex("dbo.MovimientoFormaPagosBancos", new[] { "BancoCodigo" });
            DropIndex("dbo.MovimientoFormaPagosBancos", new[] { "MovimientoFormaPagoCodigo" });
            DropTable("dbo.MovimientoFormaPagosBancos");
        }
    }
}
