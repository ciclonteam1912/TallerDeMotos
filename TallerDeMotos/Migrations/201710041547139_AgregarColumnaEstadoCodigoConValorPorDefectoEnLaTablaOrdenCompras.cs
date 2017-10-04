namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaEstadoCodigoConValorPorDefectoEnLaTablaOrdenCompras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenCompras", "EstadoCodigo", c => c.Byte(nullable: false, defaultValue: 1));
            CreateIndex("dbo.OrdenCompras", "EstadoCodigo");
            AddForeignKey("dbo.OrdenCompras", "EstadoCodigo", "dbo.Estados", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenCompras", "EstadoCodigo", "dbo.Estados");
            DropIndex("dbo.OrdenCompras", new[] { "EstadoCodigo" });
            DropColumn("dbo.OrdenCompras", "EstadoCodigo");
        }
    }
}
