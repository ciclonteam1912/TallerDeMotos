namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaTiposMotores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TiposMotores",
                c => new
                    {
                        Codigo = c.Byte(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Codigo);
            
            AddColumn("dbo.Vehiculos", "TipoMotorCodigo", c => c.Byte(nullable: false));
            CreateIndex("dbo.Vehiculos", "TipoMotorCodigo");
            AddForeignKey("dbo.Vehiculos", "TipoMotorCodigo", "dbo.TiposMotores", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehiculos", "TipoMotorCodigo", "dbo.TiposMotores");
            DropIndex("dbo.Vehiculos", new[] { "TipoMotorCodigo" });
            DropColumn("dbo.Vehiculos", "TipoMotorCodigo");
            DropTable("dbo.TiposMotores");
        }
    }
}
