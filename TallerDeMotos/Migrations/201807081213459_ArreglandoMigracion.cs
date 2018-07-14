namespace TallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArreglandoMigracion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FacturaVentas", "Codigo", "dbo.Presupuestos");
            DropForeignKey("dbo.FacturaVentaDetalles", "FacturaVentaCodigo", "dbo.FacturaVentas");
            DropForeignKey("dbo.MovimientoCajas", "FacturaVentaCodigo", "dbo.FacturaVentas");
            DropIndex("dbo.FacturaVentas", new[] { "Codigo" });
            DropPrimaryKey("dbo.FacturaVentas");
            AlterColumn("dbo.FacturaVentas", "Codigo", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.FacturaVentas", "Codigo");
            AddForeignKey("dbo.FacturaVentaDetalles", "FacturaVentaCodigo", "dbo.FacturaVentas", "Codigo");
            AddForeignKey("dbo.MovimientoCajas", "FacturaVentaCodigo", "dbo.FacturaVentas", "Codigo");
            DropColumn("dbo.FacturaVentas", "PresupuestoCodigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FacturaVentas", "PresupuestoCodigo", c => c.Int(nullable: false));
            DropForeignKey("dbo.MovimientoCajas", "FacturaVentaCodigo", "dbo.FacturaVentas");
            DropForeignKey("dbo.FacturaVentaDetalles", "FacturaVentaCodigo", "dbo.FacturaVentas");
            DropPrimaryKey("dbo.FacturaVentas");
            AlterColumn("dbo.FacturaVentas", "Codigo", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.FacturaVentas", "Codigo");
            CreateIndex("dbo.FacturaVentas", "Codigo");
            AddForeignKey("dbo.MovimientoCajas", "FacturaVentaCodigo", "dbo.FacturaVentas", "Codigo");
            AddForeignKey("dbo.FacturaVentaDetalles", "FacturaVentaCodigo", "dbo.FacturaVentas", "Codigo");
            AddForeignKey("dbo.FacturaVentas", "Codigo", "dbo.Presupuestos", "Codigo");
        }
    }
}
