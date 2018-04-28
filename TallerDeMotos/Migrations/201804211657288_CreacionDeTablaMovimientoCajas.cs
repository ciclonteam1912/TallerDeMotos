namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaMovimientoCajas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovimientoCajas",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        AperturaCierreCodigo = c.Int(nullable: false),
                        FacturaCompraCodigo = c.Int(nullable: false),
                        TipoMovimientoCodigo = c.Byte(nullable: false),
                        Monto = c.Long(nullable: false),
                        Vuelto = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.CajaAperturaCierres", t => t.AperturaCierreCodigo)
                .ForeignKey("dbo.FacturaCompras", t => t.FacturaCompraCodigo)
                .ForeignKey("dbo.TipoMovimientos", t => t.TipoMovimientoCodigo)
                .Index(t => t.AperturaCierreCodigo)
                .Index(t => t.FacturaCompraCodigo)
                .Index(t => t.TipoMovimientoCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovimientoCajas", "TipoMovimientoCodigo", "dbo.TipoMovimientos");
            DropForeignKey("dbo.MovimientoCajas", "FacturaCompraCodigo", "dbo.FacturaCompras");
            DropForeignKey("dbo.MovimientoCajas", "AperturaCierreCodigo", "dbo.CajaAperturaCierres");
            DropIndex("dbo.MovimientoCajas", new[] { "TipoMovimientoCodigo" });
            DropIndex("dbo.MovimientoCajas", new[] { "FacturaCompraCodigo" });
            DropIndex("dbo.MovimientoCajas", new[] { "AperturaCierreCodigo" });
            DropTable("dbo.MovimientoCajas");
        }
    }
}
