namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SacarColumnaFacturaCompraCodigoEnTablaMovimientoCajas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovimientoCajas", "FacturaCompraCodigo", "dbo.FacturaCompras");
            DropIndex("dbo.MovimientoCajas", new[] { "FacturaCompraCodigo" });
            DropColumn("dbo.MovimientoCajas", "FacturaCompraCodigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovimientoCajas", "FacturaCompraCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.MovimientoCajas", "FacturaCompraCodigo");
            AddForeignKey("dbo.MovimientoCajas", "FacturaCompraCodigo", "dbo.FacturaCompras", "Codigo");
        }
    }
}
