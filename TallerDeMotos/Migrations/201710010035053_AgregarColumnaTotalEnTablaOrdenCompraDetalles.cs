namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaTotalEnTablaOrdenCompraDetalles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenCompraDetalles", "Total", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrdenCompraDetalles", "Total");
        }
    }
}
