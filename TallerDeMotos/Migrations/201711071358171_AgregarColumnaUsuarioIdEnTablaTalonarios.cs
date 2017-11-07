namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaUsuarioIdEnTablaTalonarios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Talonarios", "UsuarioId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Talonarios", "UsuarioId");
            AddForeignKey("dbo.Talonarios", "UsuarioId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Talonarios", "UsuarioId", "dbo.AspNetUsers");
            DropIndex("dbo.Talonarios", new[] { "UsuarioId" });
            DropColumn("dbo.Talonarios", "UsuarioId");
        }
    }
}
