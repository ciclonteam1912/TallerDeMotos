namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarCamposTotalesEnLaTablaFacturaVentas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FacturaVentas", "TotalDiezPorCiento", c => c.Long(nullable: false));
            AddColumn("dbo.FacturaVentas", "TotalCincoPorCiento", c => c.Long(nullable: false));
            AddColumn("dbo.FacturaVentas", "TotalExenta", c => c.Long(nullable: false));
            AlterColumn("dbo.FacturaVentas", "SubTotal", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FacturaVentas", "SubTotal", c => c.Int(nullable: false));
            DropColumn("dbo.FacturaVentas", "TotalExenta");
            DropColumn("dbo.FacturaVentas", "TotalCincoPorCiento");
            DropColumn("dbo.FacturaVentas", "TotalDiezPorCiento");
        }
    }
}
