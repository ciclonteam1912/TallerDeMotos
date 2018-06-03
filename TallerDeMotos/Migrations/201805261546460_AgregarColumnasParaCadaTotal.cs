namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnasParaCadaTotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PresupuestoDetalles", "TotalLineaExenta", c => c.Int(nullable: false));
            AddColumn("dbo.PresupuestoDetalles", "TotalLineaCincoXCiento", c => c.Int(nullable: false));
            AddColumn("dbo.PresupuestoDetalles", "TotalLineaDiezXCiento", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PresupuestoDetalles", "TotalLineaDiezXCiento");
            DropColumn("dbo.PresupuestoDetalles", "TotalLineaCincoXCiento");
            DropColumn("dbo.PresupuestoDetalles", "TotalLineaExenta");
        }
    }
}
