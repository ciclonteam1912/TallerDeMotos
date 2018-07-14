namespace TallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminarColumnaPresupuestoCodigoDeFacturaVentas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FacturaVentas", "PresupuestoCodigo", "dbo.Presupuestos");
            DropIndex("dbo.FacturaVentas", new[] { "PresupuestoCodigo" });
            DropColumn("dbo.FacturaVentas", "PresupuestoCodigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FacturaVentas", "PresupuestoCodigo", c => c.Int());
            CreateIndex("dbo.FacturaVentas", "PresupuestoCodigo");
            AddForeignKey("dbo.FacturaVentas", "PresupuestoCodigo", "dbo.Presupuestos", "Codigo");
        }
    }
}
