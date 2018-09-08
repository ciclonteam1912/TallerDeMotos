namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EliminarRelacionUnoAMuchosEntreVehiculosYAseguradoras : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehiculos", "AseguradoraCodigo", "dbo.Aseguradoras");
            DropIndex("dbo.Vehiculos", new[] { "AseguradoraCodigo" });
            DropColumn("dbo.Vehiculos", "AseguradoraCodigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehiculos", "AseguradoraCodigo", c => c.Byte(nullable: false));
            CreateIndex("dbo.Vehiculos", "AseguradoraCodigo");
            AddForeignKey("dbo.Vehiculos", "AseguradoraCodigo", "dbo.Aseguradoras", "Codigo");
        }
    }
}
