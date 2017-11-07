namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EliminarRelacionUnoAUnoEntreFacturaVentasYTalonarios : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FacturaVentas", "Codigo", "dbo.Talonarios");
            DropColumn("dbo.FacturaVentas", "TalonarioCodigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FacturaVentas", "TalonarioCodigo", c => c.Int(nullable: false));
            AddForeignKey("dbo.FacturaVentas", "Codigo", "dbo.Talonarios", "Codigo");
        }
    }
}
