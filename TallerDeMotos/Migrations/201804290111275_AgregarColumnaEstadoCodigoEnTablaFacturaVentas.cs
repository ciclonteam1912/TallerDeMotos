namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaEstadoCodigoEnTablaFacturaVentas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FacturaVentas", "EstadoCodigo", c => c.Byte(nullable: false));
            CreateIndex("dbo.FacturaVentas", "EstadoCodigo");
            AddForeignKey("dbo.FacturaVentas", "EstadoCodigo", "dbo.Estados", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturaVentas", "EstadoCodigo", "dbo.Estados");
            DropIndex("dbo.FacturaVentas", new[] { "EstadoCodigo" });
            DropColumn("dbo.FacturaVentas", "EstadoCodigo");
        }
    }
}
