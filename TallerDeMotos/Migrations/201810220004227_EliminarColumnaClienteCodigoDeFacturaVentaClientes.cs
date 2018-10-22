namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EliminarColumnaClienteCodigoDeFacturaVentaClientes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FacturaVentaClientes", "ClienteCodigo", "dbo.Clientes");
            DropIndex("dbo.FacturaVentaClientes", new[] { "ClienteCodigo" });
            DropColumn("dbo.FacturaVentaClientes", "ClienteCodigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FacturaVentaClientes", "ClienteCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.FacturaVentaClientes", "ClienteCodigo");
            AddForeignKey("dbo.FacturaVentaClientes", "ClienteCodigo", "dbo.Clientes", "Codigo");
        }
    }
}
