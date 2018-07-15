namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarCampoCajaCodigoEnTalonarios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Talonarios", "CajaCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.Talonarios", "CajaCodigo");
            AddForeignKey("dbo.Talonarios", "CajaCodigo", "dbo.Cajas", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Talonarios", "CajaCodigo", "dbo.Cajas");
            DropIndex("dbo.Talonarios", new[] { "CajaCodigo" });
            DropColumn("dbo.Talonarios", "CajaCodigo");
        }
    }
}
