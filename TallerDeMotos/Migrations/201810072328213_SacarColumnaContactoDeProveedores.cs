namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SacarColumnaContactoDeProveedores : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Proveedores", "Contacto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Proveedores", "Contacto", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
