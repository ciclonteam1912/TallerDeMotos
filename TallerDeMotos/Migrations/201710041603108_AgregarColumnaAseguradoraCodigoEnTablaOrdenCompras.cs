namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaAseguradoraCodigoEnTablaOrdenCompras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenCompras", "AseguradoraCodigo", c => c.Byte(nullable: false));
            CreateIndex("dbo.OrdenCompras", "AseguradoraCodigo");
            AddForeignKey("dbo.OrdenCompras", "AseguradoraCodigo", "dbo.Aseguradoras", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenCompras", "AseguradoraCodigo", "dbo.Aseguradoras");
            DropIndex("dbo.OrdenCompras", new[] { "AseguradoraCodigo" });
            DropColumn("dbo.OrdenCompras", "AseguradoraCodigo");
        }
    }
}
