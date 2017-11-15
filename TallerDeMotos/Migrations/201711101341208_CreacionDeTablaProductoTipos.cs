namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaProductoTipos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductoTipos",
                c => new
                    {
                        Codigo = c.Byte(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductoTipos");
        }
    }
}
