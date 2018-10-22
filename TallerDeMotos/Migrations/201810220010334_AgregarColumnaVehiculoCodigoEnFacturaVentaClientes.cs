namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaVehiculoCodigoEnFacturaVentaClientes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FacturaVentaClientes", "VehiculoCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.FacturaVentaClientes", "VehiculoCodigo");
            AddForeignKey("dbo.FacturaVentaClientes", "VehiculoCodigo", "dbo.Vehiculos", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturaVentaClientes", "VehiculoCodigo", "dbo.Vehiculos");
            DropIndex("dbo.FacturaVentaClientes", new[] { "VehiculoCodigo" });
            DropColumn("dbo.FacturaVentaClientes", "VehiculoCodigo");
        }
    }
}
