namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnasSucursalCodigoYEstadoCajaEnCajas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cajas", "SucursalCodigo", c => c.Int(nullable: false));
            AddColumn("dbo.Cajas", "EstadoCaja", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Cajas", "SucursalCodigo");
            AddForeignKey("dbo.Cajas", "SucursalCodigo", "dbo.Sucursales", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cajas", "SucursalCodigo", "dbo.Sucursales");
            DropIndex("dbo.Cajas", new[] { "SucursalCodigo" });
            DropColumn("dbo.Cajas", "EstadoCaja");
            DropColumn("dbo.Cajas", "SucursalCodigo");
        }
    }
}
