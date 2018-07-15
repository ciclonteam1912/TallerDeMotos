namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarCampoSucursalCodigoEnTalonarios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Talonarios", "SucursalCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.Talonarios", "SucursalCodigo");
            AddForeignKey("dbo.Talonarios", "SucursalCodigo", "dbo.Sucursales", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Talonarios", "SucursalCodigo", "dbo.Sucursales");
            DropIndex("dbo.Talonarios", new[] { "SucursalCodigo" });
            DropColumn("dbo.Talonarios", "SucursalCodigo");
        }
    }
}
