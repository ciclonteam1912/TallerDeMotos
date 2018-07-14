namespace TallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionDeTablaFacturaVentas1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FacturaVentas",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        NumeroFactura = c.Int(nullable: false),
                        FechaFacturaVenta = c.DateTime(nullable: false),
                        SubTotal = c.Long(nullable: false),
                        TotalDiezPorCiento = c.Long(nullable: false),
                        TotalCincoPorCiento = c.Long(nullable: false),
                        TotalExenta = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FacturaVentas");
        }
    }
}
