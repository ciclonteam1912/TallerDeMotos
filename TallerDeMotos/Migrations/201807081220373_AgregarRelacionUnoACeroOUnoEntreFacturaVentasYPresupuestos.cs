namespace TallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarRelacionUnoACeroOUnoEntreFacturaVentasYPresupuestos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FacturaVentas", "PresupuestoCodigo", c => c.Int());
            CreateIndex("dbo.FacturaVentas", "PresupuestoCodigo");
            AddForeignKey("dbo.FacturaVentas", "PresupuestoCodigo", "dbo.Presupuestos", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturaVentas", "PresupuestoCodigo", "dbo.Presupuestos");
            DropIndex("dbo.FacturaVentas", new[] { "PresupuestoCodigo" });
            DropColumn("dbo.FacturaVentas", "PresupuestoCodigo");
        }
    }
}
