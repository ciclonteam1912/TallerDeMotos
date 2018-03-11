namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class HacerObligatoriosAlgunosCamposDeLaTablaProveedores : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Proveedores", "Contacto", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Proveedores", "Direccion", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Proveedores", "Telefono", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Proveedores", "Telefono", c => c.String(maxLength: 50));
            AlterColumn("dbo.Proveedores", "Direccion", c => c.String(maxLength: 255));
            AlterColumn("dbo.Proveedores", "Contacto", c => c.String(maxLength: 50));
        }
    }
}
