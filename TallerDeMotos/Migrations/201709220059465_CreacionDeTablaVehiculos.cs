namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaVehiculos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehiculos",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Matricula = c.String(nullable: false, maxLength: 20),
                        Chasis = c.String(nullable: false, maxLength: 20),
                        Kilometro = c.Single(),
                        Motor = c.String(maxLength: 20),
                        Cilindrada = c.Int(),
                        FechaDeIngreso = c.DateTime(nullable: false),
                        Color = c.String(maxLength: 20),
                        ModeloCodigo = c.Byte(nullable: false),
                        ClienteCodigo = c.Int(nullable: false),
                        CombustibleCodigo = c.Byte(nullable: false),
                        AseguradoraCodigo = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Aseguradoras", t => t.AseguradoraCodigo)
                .ForeignKey("dbo.Clientes", t => t.ClienteCodigo)
                .ForeignKey("dbo.Combustibles", t => t.CombustibleCodigo)
                .ForeignKey("dbo.Modelos", t => t.ModeloCodigo)
                .Index(t => t.Matricula, unique: true)
                .Index(t => t.Chasis, unique: true)
                .Index(t => t.ModeloCodigo)
                .Index(t => t.ClienteCodigo)
                .Index(t => t.CombustibleCodigo)
                .Index(t => t.AseguradoraCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehiculos", "ModeloCodigo", "dbo.Modelos");
            DropForeignKey("dbo.Vehiculos", "CombustibleCodigo", "dbo.Combustibles");
            DropForeignKey("dbo.Vehiculos", "ClienteCodigo", "dbo.Clientes");
            DropForeignKey("dbo.Vehiculos", "AseguradoraCodigo", "dbo.Aseguradoras");
            DropIndex("dbo.Vehiculos", new[] { "AseguradoraCodigo" });
            DropIndex("dbo.Vehiculos", new[] { "CombustibleCodigo" });
            DropIndex("dbo.Vehiculos", new[] { "ClienteCodigo" });
            DropIndex("dbo.Vehiculos", new[] { "ModeloCodigo" });
            DropIndex("dbo.Vehiculos", new[] { "Chasis" });
            DropIndex("dbo.Vehiculos", new[] { "Matricula" });
            DropTable("dbo.Vehiculos");
        }
    }
}
