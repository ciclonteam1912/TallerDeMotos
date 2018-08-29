namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarConstraintUniqueEnColumnaNombreDeLaTablaCiudades : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ciudades", "Nombre", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Ciudades", "Nombre", unique: true, name: "IX_NombreCiudad");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Ciudades", "IX_NombreCiudad");
            AlterColumn("dbo.Ciudades", "Nombre", c => c.String(nullable: false));
        }
    }
}
