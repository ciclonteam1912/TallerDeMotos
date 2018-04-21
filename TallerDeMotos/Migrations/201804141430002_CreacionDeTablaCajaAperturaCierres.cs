namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaCajaAperturaCierres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CajaAperturaCierres",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        CajaCodigo = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        SaldoInicial = c.Long(nullable: false),
                        SaldoFinal = c.Long(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Cajas", t => t.CajaCodigo)
                .Index(t => t.CajaCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CajaAperturaCierres", "CajaCodigo", "dbo.Cajas");
            DropIndex("dbo.CajaAperturaCierres", new[] { "CajaCodigo" });
            DropTable("dbo.CajaAperturaCierres");
        }
    }
}
