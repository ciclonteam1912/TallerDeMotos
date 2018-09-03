namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarIndiceUnicoEnLaColumnaNombreEnLaTablaMarcas : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Marcas", "Nombre", unique: true, name: "IX_NombreMarca");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Marcas", "IX_NombreMarca");
        }
    }
}
