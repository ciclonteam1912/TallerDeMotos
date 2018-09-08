namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarRelacionUnoOCeroAUnoEntreAseguradorasYVehiculos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehiculos", "AseguradoraCodigo", c => c.Byte());
            CreateIndex("dbo.Vehiculos", "AseguradoraCodigo");
            AddForeignKey("dbo.Vehiculos", "AseguradoraCodigo", "dbo.Aseguradoras", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehiculos", "AseguradoraCodigo", "dbo.Aseguradoras");
            DropIndex("dbo.Vehiculos", new[] { "AseguradoraCodigo" });
            DropColumn("dbo.Vehiculos", "AseguradoraCodigo");
        }
    }
}
