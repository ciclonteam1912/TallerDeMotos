namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaPrecioProductoEnTablaFacturaCompraDetalles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FacturaCompraDetalles", "PrecioProducto", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FacturaCompraDetalles", "PrecioProducto");
        }
    }
}
