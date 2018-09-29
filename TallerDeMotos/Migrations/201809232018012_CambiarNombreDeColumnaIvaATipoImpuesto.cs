namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CambiarNombreDeColumnaIvaATipoImpuesto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "TipoImpuesto", c => c.Byte());
            DropColumn("dbo.Productos", "Iva");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productos", "Iva", c => c.Byte());
            DropColumn("dbo.Productos", "TipoImpuesto");
        }
    }
}
