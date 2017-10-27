namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaSubtotalEnTablaFacturaCompras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FacturaCompras", "Subtotal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FacturaCompras", "Subtotal");
        }
    }
}
