namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaCiudadCodigoEnTablaProveedores : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proveedores", "CiudadCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.Proveedores", "CiudadCodigo");
            AddForeignKey("dbo.Proveedores", "CiudadCodigo", "dbo.Ciudades", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proveedores", "CiudadCodigo", "dbo.Ciudades");
            DropIndex("dbo.Proveedores", new[] { "CiudadCodigo" });
            DropColumn("dbo.Proveedores", "CiudadCodigo");
        }
    }
}
