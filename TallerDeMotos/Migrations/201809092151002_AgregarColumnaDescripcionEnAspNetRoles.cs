namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaDescripcionEnAspNetRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Descripcion", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.AspNetRoles", "Descripcion");
        }
    }
}
