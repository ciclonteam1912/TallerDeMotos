namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaFechaDeGuardadoEnTablaFacturaCompras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FacturaCompras", "FechaDeGuardado", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FacturaCompras", "FechaDeGuardado");
        }
    }
}
