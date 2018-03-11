namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeAgregoLaColumnaUsuarioCodigoEnTablaOrdenCompras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenCompras", "UsuarioId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.OrdenCompras", "UsuarioId");
            AddForeignKey("dbo.OrdenCompras", "UsuarioId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenCompras", "UsuarioId", "dbo.AspNetUsers");
            DropIndex("dbo.OrdenCompras", new[] { "UsuarioId" });
            DropColumn("dbo.OrdenCompras", "UsuarioId");
        }
    }
}
