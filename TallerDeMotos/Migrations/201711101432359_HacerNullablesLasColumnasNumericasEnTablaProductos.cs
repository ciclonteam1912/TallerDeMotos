namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class HacerNullablesLasColumnasNumericasEnTablaProductos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productos", "PrecioCosto", c => c.Int());
            AlterColumn("dbo.Productos", "PrecioVenta", c => c.Int());
            AlterColumn("dbo.Productos", "Iva", c => c.Byte());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productos", "Iva", c => c.Byte(nullable: false));
            AlterColumn("dbo.Productos", "PrecioVenta", c => c.Int(nullable: false));
            AlterColumn("dbo.Productos", "PrecioCosto", c => c.Int(nullable: false));
        }
    }
}
