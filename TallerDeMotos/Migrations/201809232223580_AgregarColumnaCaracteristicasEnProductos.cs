namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaCaracteristicasEnProductos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "Caracteristicas", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productos", "Caracteristicas");
        }
    }
}
