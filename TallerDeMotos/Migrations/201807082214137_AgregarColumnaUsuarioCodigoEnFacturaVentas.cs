namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaUsuarioCodigoEnFacturaVentas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FacturaVentas", "UsuarioCodigo", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.FacturaVentas", "UsuarioCodigo");
            AddForeignKey("dbo.FacturaVentas", "UsuarioCodigo", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturaVentas", "UsuarioCodigo", "dbo.AspNetUsers");
            DropIndex("dbo.FacturaVentas", new[] { "UsuarioCodigo" });
            DropColumn("dbo.FacturaVentas", "UsuarioCodigo");
        }
    }
}
