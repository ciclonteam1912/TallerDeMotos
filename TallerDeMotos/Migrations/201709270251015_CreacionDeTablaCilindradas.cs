namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaCilindradas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cilindradas",
                c => new
                    {
                        Codigo = c.Byte(nullable: false, identity: true),
                        NumeroCilindrada = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            AddColumn("dbo.Vehiculos", "CilindradaCodigo", c => c.Byte(nullable: false));
            CreateIndex("dbo.Vehiculos", "CilindradaCodigo");
            AddForeignKey("dbo.Vehiculos", "CilindradaCodigo", "dbo.Cilindradas", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehiculos", "CilindradaCodigo", "dbo.Cilindradas");
            DropIndex("dbo.Vehiculos", new[] { "CilindradaCodigo" });
            DropColumn("dbo.Vehiculos", "CilindradaCodigo");
            DropTable("dbo.Cilindradas");
        }
    }
}
