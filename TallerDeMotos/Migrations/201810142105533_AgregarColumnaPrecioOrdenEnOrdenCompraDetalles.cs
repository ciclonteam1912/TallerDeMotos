namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaPrecioOrdenEnOrdenCompraDetalles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenCompraDetalles", "PrecioOrden", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrdenCompraDetalles", "PrecioOrden");
        }
    }
}
