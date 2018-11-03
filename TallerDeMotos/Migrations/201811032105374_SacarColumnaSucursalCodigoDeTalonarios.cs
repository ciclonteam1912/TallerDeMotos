namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SacarColumnaSucursalCodigoDeTalonarios : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Talonarios", "SucursalCodigo", "dbo.Sucursales");
            DropIndex("dbo.Talonarios", new[] { "SucursalCodigo" });
            DropColumn("dbo.Talonarios", "SucursalCodigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Talonarios", "SucursalCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.Talonarios", "SucursalCodigo");
            AddForeignKey("dbo.Talonarios", "SucursalCodigo", "dbo.Sucursales", "Codigo");
        }
    }
}
