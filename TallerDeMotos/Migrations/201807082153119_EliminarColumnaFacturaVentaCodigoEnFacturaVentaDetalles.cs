namespace TallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminarColumnaFacturaVentaCodigoEnFacturaVentaDetalles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FacturaVentaDetalles", "FacturaVentaCodigo", "dbo.FacturaVentas");
            DropIndex("dbo.FacturaVentaDetalles", new[] { "FacturaVentaCodigo" });
            DropColumn("dbo.FacturaVentaDetalles", "FacturaVentaCodigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FacturaVentaDetalles", "FacturaVentaCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.FacturaVentaDetalles", "FacturaVentaCodigo");
            AddForeignKey("dbo.FacturaVentaDetalles", "FacturaVentaCodigo", "dbo.FacturaVentas", "Codigo");
        }
    }
}
