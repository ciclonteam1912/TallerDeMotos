namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaFechaDeVencimientoEnOrdenCompras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenCompras", "FechaDeVencimiento", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrdenCompras", "FechaDeVencimiento");
        }
    }
}
