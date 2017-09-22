namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaTalonarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Talonarios",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Timbrado = c.Int(nullable: false),
                        FechaInicioVigencia = c.DateTime(nullable: false),
                        FechaFinVigencia = c.DateTime(nullable: false),
                        NumeroFacturaInicial = c.Int(nullable: false),
                        NumeroFacturaFinal = c.Int(nullable: false),
                        NumeroFacturaActual = c.Int(nullable: false),
                        EstaActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Talonarios");
        }
    }
}
