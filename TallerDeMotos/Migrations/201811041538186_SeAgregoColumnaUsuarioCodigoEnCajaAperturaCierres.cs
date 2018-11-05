namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeAgregoColumnaUsuarioCodigoEnCajaAperturaCierres : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CajaAperturaCierres", "UsuarioCodigo", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.CajaAperturaCierres", "UsuarioCodigo");
            AddForeignKey("dbo.CajaAperturaCierres", "UsuarioCodigo", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CajaAperturaCierres", "UsuarioCodigo", "dbo.AspNetUsers");
            DropIndex("dbo.CajaAperturaCierres", new[] { "UsuarioCodigo" });
            DropColumn("dbo.CajaAperturaCierres", "UsuarioCodigo");
        }
    }
}
