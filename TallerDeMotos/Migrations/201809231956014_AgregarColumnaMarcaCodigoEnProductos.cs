namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaMarcaCodigoEnProductos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "MarcaCodigo", c => c.Byte(nullable: false));
            CreateIndex("dbo.Productos", "MarcaCodigo");
            AddForeignKey("dbo.Productos", "MarcaCodigo", "dbo.Marcas", "Codigo");
            DropColumn("dbo.Productos", "Marca");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productos", "Marca", c => c.String(maxLength: 50));
            DropForeignKey("dbo.Productos", "MarcaCodigo", "dbo.Marcas");
            DropIndex("dbo.Productos", new[] { "MarcaCodigo" });
            DropColumn("dbo.Productos", "MarcaCodigo");
        }
    }
}
