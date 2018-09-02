namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SacarTipoDeMotorYCilindradaDeVehiculos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehiculos", "CilindradaCodigo", "dbo.Cilindradas");
            DropForeignKey("dbo.Vehiculos", "TipoMotorCodigo", "dbo.TiposMotores");
            DropIndex("dbo.Vehiculos", new[] { "TipoMotorCodigo" });
            DropIndex("dbo.Vehiculos", new[] { "CilindradaCodigo" });
            DropColumn("dbo.Vehiculos", "TipoMotorCodigo");
            DropColumn("dbo.Vehiculos", "CilindradaCodigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehiculos", "CilindradaCodigo", c => c.Byte(nullable: false));
            AddColumn("dbo.Vehiculos", "TipoMotorCodigo", c => c.Byte(nullable: false));
            CreateIndex("dbo.Vehiculos", "CilindradaCodigo");
            CreateIndex("dbo.Vehiculos", "TipoMotorCodigo");
            AddForeignKey("dbo.Vehiculos", "TipoMotorCodigo", "dbo.TiposMotores", "Codigo");
            AddForeignKey("dbo.Vehiculos", "CilindradaCodigo", "dbo.Cilindradas", "Codigo");
        }
    }
}
