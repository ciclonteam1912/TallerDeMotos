namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaCiudadCodigoEnTablaAseguradoras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aseguradoras", "CiudadCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.Aseguradoras", "CiudadCodigo");
            AddForeignKey("dbo.Aseguradoras", "CiudadCodigo", "dbo.Ciudades", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aseguradoras", "CiudadCodigo", "dbo.Ciudades");
            DropIndex("dbo.Aseguradoras", new[] { "CiudadCodigo" });
            DropColumn("dbo.Aseguradoras", "CiudadCodigo");
        }
    }
}
