namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaFechaDeValidezEnPresupuestos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Presupuestos", "FechaDeValidez", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Presupuestos", "FechaDeValidez");
        }
    }
}
