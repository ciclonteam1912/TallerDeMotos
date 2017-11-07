namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaTalonarioCodigoEnFacturaVentas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FacturaVentas", "TalonarioCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.FacturaVentas", "TalonarioCodigo");
            AddForeignKey("dbo.FacturaVentas", "TalonarioCodigo", "dbo.Talonarios", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturaVentas", "TalonarioCodigo", "dbo.Talonarios");
            DropIndex("dbo.FacturaVentas", new[] { "TalonarioCodigo" });
            DropColumn("dbo.FacturaVentas", "TalonarioCodigo");
        }
    }
}
