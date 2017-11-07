namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaNumeroFacturaEnTablaFacturaVentas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FacturaVentas", "NumeroFactura", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FacturaVentas", "NumeroFactura");
        }
    }
}
