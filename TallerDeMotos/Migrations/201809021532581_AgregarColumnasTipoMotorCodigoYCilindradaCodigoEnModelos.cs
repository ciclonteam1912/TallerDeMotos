namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnasTipoMotorCodigoYCilindradaCodigoEnModelos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Modelos", "CilindradaCodigo", c => c.Byte(nullable: false));
            AddColumn("dbo.Modelos", "TipoMotorCodigo", c => c.Byte(nullable: false));
            CreateIndex("dbo.Modelos", "CilindradaCodigo");
            CreateIndex("dbo.Modelos", "TipoMotorCodigo");
            AddForeignKey("dbo.Modelos", "CilindradaCodigo", "dbo.Cilindradas", "Codigo");
            AddForeignKey("dbo.Modelos", "TipoMotorCodigo", "dbo.TiposMotores", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modelos", "TipoMotorCodigo", "dbo.TiposMotores");
            DropForeignKey("dbo.Modelos", "CilindradaCodigo", "dbo.Cilindradas");
            DropIndex("dbo.Modelos", new[] { "TipoMotorCodigo" });
            DropIndex("dbo.Modelos", new[] { "CilindradaCodigo" });
            DropColumn("dbo.Modelos", "TipoMotorCodigo");
            DropColumn("dbo.Modelos", "CilindradaCodigo");
        }
    }
}
