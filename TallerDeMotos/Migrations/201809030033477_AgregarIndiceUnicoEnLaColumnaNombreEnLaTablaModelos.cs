namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarIndiceUnicoEnLaColumnaNombreEnLaTablaModelos : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Modelos", "Nombre", unique: true, name: "IX_NombreModelo");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Modelos", "IX_NombreModelo");
        }
    }
}
