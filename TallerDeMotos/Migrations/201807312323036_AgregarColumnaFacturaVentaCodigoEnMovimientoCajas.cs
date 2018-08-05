namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaFacturaVentaCodigoEnMovimientoCajas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovimientoCajas", "FacturaVentaCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.MovimientoCajas", "FacturaVentaCodigo");
            AddForeignKey("dbo.MovimientoCajas", "FacturaVentaCodigo", "dbo.FacturaVentas", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovimientoCajas", "FacturaVentaCodigo", "dbo.FacturaVentas");
            DropIndex("dbo.MovimientoCajas", new[] { "FacturaVentaCodigo" });
            DropColumn("dbo.MovimientoCajas", "FacturaVentaCodigo");
        }
    }
}
