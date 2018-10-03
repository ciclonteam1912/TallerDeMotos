namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaPorcentajeGananciaEnProductoTipos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductoTipos", "PorcentajeGanancia", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductoTipos", "PorcentajeGanancia");
        }
    }
}
