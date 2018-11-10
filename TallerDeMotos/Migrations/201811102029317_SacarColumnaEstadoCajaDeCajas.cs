namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SacarColumnaEstadoCajaDeCajas : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cajas", "EstadoCaja");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cajas", "EstadoCaja", c => c.Boolean(nullable: false));
        }
    }
}
