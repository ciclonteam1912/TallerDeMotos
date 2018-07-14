namespace TallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminarColumnaFacturaVentaCodigoEnMovimientoCajas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovimientoCajas", "FacturaVentaCodigo", "dbo.FacturaVentas");
            DropIndex("dbo.MovimientoCajas", new[] { "FacturaVentaCodigo" });
            DropColumn("dbo.MovimientoCajas", "FacturaVentaCodigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovimientoCajas", "FacturaVentaCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.MovimientoCajas", "FacturaVentaCodigo");
            AddForeignKey("dbo.MovimientoCajas", "FacturaVentaCodigo", "dbo.FacturaVentas", "Codigo");
        }
    }
}
