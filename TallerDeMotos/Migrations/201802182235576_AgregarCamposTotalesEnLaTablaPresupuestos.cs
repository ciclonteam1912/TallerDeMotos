namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarCamposTotalesEnLaTablaPresupuestos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Presupuestos", "TotalExenta", c => c.Long(nullable: false));
            AddColumn("dbo.Presupuestos", "TotalIvaCincoPorCiento", c => c.Long(nullable: false));
            AddColumn("dbo.Presupuestos", "TotalIvaDiezPorCiento", c => c.Long(nullable: false));
            AlterColumn("dbo.Presupuestos", "SubTotal", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Presupuestos", "SubTotal", c => c.Int(nullable: false));
            DropColumn("dbo.Presupuestos", "TotalIvaDiezPorCiento");
            DropColumn("dbo.Presupuestos", "TotalIvaCincoPorCiento");
            DropColumn("dbo.Presupuestos", "TotalExenta");
        }
    }
}
