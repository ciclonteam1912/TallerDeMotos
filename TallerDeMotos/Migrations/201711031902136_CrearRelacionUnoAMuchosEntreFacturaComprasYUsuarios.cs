namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CrearRelacionUnoAMuchosEntreFacturaComprasYUsuarios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FacturaCompras", "UsuarioId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.FacturaCompras", "UsuarioId");
            AddForeignKey("dbo.FacturaCompras", "UsuarioId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturaCompras", "UsuarioId", "dbo.AspNetUsers");
            DropIndex("dbo.FacturaCompras", new[] { "UsuarioId" });
            DropColumn("dbo.FacturaCompras", "UsuarioId");
        }
    }
}
