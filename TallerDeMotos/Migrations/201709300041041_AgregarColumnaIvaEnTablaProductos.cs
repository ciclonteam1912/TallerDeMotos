namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaIvaEnTablaProductos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "Iva", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productos", "Iva");
        }
    }
}
