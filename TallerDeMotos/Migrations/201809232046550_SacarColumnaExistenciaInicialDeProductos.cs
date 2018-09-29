namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SacarColumnaExistenciaInicialDeProductos : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Productos", "ExistenciaInicial");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productos", "ExistenciaInicial", c => c.Int());
        }
    }
}
