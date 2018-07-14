namespace TallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminarTablaFacturaVentas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FacturaVentas", "EstadoCodigo", "dbo.Estados");
            DropForeignKey("dbo.FacturaVentas", "TalonarioCodigo", "dbo.Talonarios");
            DropForeignKey("dbo.FacturaVentas", "UsuarioId", "dbo.AspNetUsers");
            DropIndex("dbo.FacturaVentas", new[] { "TalonarioCodigo" });
            DropIndex("dbo.FacturaVentas", new[] { "UsuarioId" });
            DropIndex("dbo.FacturaVentas", new[] { "EstadoCodigo" });
            DropTable("dbo.FacturaVentas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FacturaVentas",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        TalonarioCodigo = c.Int(nullable: false),
                        NumeroFactura = c.Int(nullable: false),
                        FechaFacturaVenta = c.DateTime(nullable: false),
                        SubTotal = c.Long(nullable: false),
                        TotalDiezPorCiento = c.Long(nullable: false),
                        TotalCincoPorCiento = c.Long(nullable: false),
                        TotalExenta = c.Long(nullable: false),
                        UsuarioId = c.String(nullable: false, maxLength: 128),
                        EstadoCodigo = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateIndex("dbo.FacturaVentas", "EstadoCodigo");
            CreateIndex("dbo.FacturaVentas", "UsuarioId");
            CreateIndex("dbo.FacturaVentas", "TalonarioCodigo");
            AddForeignKey("dbo.FacturaVentas", "UsuarioId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FacturaVentas", "TalonarioCodigo", "dbo.Talonarios", "Codigo");
            AddForeignKey("dbo.FacturaVentas", "EstadoCodigo", "dbo.Estados", "Codigo");
        }
    }
}
