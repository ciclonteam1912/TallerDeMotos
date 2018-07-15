namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EliminarCamposUsuarioIdYRucDeTalonarios : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Talonarios", "UsuarioId", "dbo.AspNetUsers");
            DropIndex("dbo.Talonarios", new[] { "UsuarioId" });
            DropColumn("dbo.Talonarios", "Ruc");
            DropColumn("dbo.Talonarios", "UsuarioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Talonarios", "UsuarioId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Talonarios", "Ruc", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.Talonarios", "UsuarioId");
            AddForeignKey("dbo.Talonarios", "UsuarioId", "dbo.AspNetUsers", "Id");
        }
    }
}
