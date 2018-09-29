namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SacarColumnaMarcaCodigoDeRelacionUnoAMuchosEnProductos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Productos", "MarcaCodigo", "dbo.Marcas");
            DropIndex("dbo.Productos", new[] { "MarcaCodigo" });
            DropColumn("dbo.Productos", "MarcaCodigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productos", "MarcaCodigo", c => c.Byte(nullable: false));
            CreateIndex("dbo.Productos", "MarcaCodigo");
            AddForeignKey("dbo.Productos", "MarcaCodigo", "dbo.Marcas", "Codigo");
        }
    }
}
