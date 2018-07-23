namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CambiarColumnaUsuarioCodigoAUsuarioIdEnCajas : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cajas", name: "UsuarioCodigo", newName: "UsuarioId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Cajas", name: "UsuarioId", newName: "UsuarioCodigo");
        }
    }
}
