namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class HacerNullableLasColumnasExistenciaInicialActualYMinimaEnTablaProductos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productos", "ExistenciaInicial", c => c.Int());
            AlterColumn("dbo.Productos", "ExistenciaActual", c => c.Int());
            AlterColumn("dbo.Productos", "ExistenciaMinima", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productos", "ExistenciaMinima", c => c.Int(nullable: false));
            AlterColumn("dbo.Productos", "ExistenciaActual", c => c.Int(nullable: false));
            AlterColumn("dbo.Productos", "ExistenciaInicial", c => c.Int(nullable: false));
        }
    }
}
