namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SacarColumnaUsuarioIdDeCajas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cajas", "UsuarioId", "dbo.AspNetUsers");
            DropIndex("dbo.Cajas", "IX_Usuario");
            DropColumn("dbo.Cajas", "UsuarioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cajas", "UsuarioId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Cajas", "UsuarioId", unique: true, name: "IX_Usuario");
            AddForeignKey("dbo.Cajas", "UsuarioId", "dbo.AspNetUsers", "Id");
        }
    }
}
