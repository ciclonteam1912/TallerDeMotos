namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarRestriccionUnicaEnColumnaUsuarioCodigo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cajas", new[] { "UsuarioId" });
            RenameColumn(table: "dbo.Cajas", name: "UsuarioId", newName: "UsuarioCodigo");
            CreateIndex("dbo.Cajas", "UsuarioCodigo", unique: true, name: "IX_Usuario");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cajas", "IX_Usuario");
            RenameColumn(table: "dbo.Cajas", name: "UsuarioCodigo", newName: "UsuarioId");
            CreateIndex("dbo.Cajas", "UsuarioId");
        }
    }
}
