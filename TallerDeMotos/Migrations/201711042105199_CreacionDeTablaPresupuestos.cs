namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaPresupuestos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Presupuestos",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        VehiculoCodigo = c.Int(nullable: false),
                        EstadoCodigo = c.Byte(nullable: false),
                        SubTotal = c.Int(nullable: false),
                        FechaDeEmision = c.DateTime(nullable: false),
                        UsuarioId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Estados", t => t.EstadoCodigo)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .ForeignKey("dbo.Vehiculos", t => t.VehiculoCodigo)
                .Index(t => t.VehiculoCodigo)
                .Index(t => t.EstadoCodigo)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Presupuestos", "VehiculoCodigo", "dbo.Vehiculos");
            DropForeignKey("dbo.Presupuestos", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Presupuestos", "EstadoCodigo", "dbo.Estados");
            DropIndex("dbo.Presupuestos", new[] { "UsuarioId" });
            DropIndex("dbo.Presupuestos", new[] { "EstadoCodigo" });
            DropIndex("dbo.Presupuestos", new[] { "VehiculoCodigo" });
            DropTable("dbo.Presupuestos");
        }
    }
}
