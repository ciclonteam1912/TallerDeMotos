namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaMarcaCodigoEnProductosConRelacionUnoOCeroAUno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "MarcaCodigo", c => c.Byte());
            CreateIndex("dbo.Productos", "MarcaCodigo");
            AddForeignKey("dbo.Productos", "MarcaCodigo", "dbo.Marcas", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "MarcaCodigo", "dbo.Marcas");
            DropIndex("dbo.Productos", new[] { "MarcaCodigo" });
            DropColumn("dbo.Productos", "MarcaCodigo");
        }
    }
}
