namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EliminarColumnaAseguradoraCodigoDeTablaOrdenCompras : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrdenCompras", "AseguradoraCodigo", "dbo.Aseguradoras");
            DropIndex("dbo.OrdenCompras", new[] { "AseguradoraCodigo" });
            DropColumn("dbo.OrdenCompras", "AseguradoraCodigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrdenCompras", "AseguradoraCodigo", c => c.Byte(nullable: false));
            CreateIndex("dbo.OrdenCompras", "AseguradoraCodigo");
            AddForeignKey("dbo.OrdenCompras", "AseguradoraCodigo", "dbo.Aseguradoras", "Codigo");
        }
    }
}
