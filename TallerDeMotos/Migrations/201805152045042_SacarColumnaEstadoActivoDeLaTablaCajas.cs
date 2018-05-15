namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SacarColumnaEstadoActivoDeLaTablaCajas : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cajas", "EstadoActivo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cajas", "EstadoActivo", c => c.Boolean(nullable: false));
        }
    }
}
