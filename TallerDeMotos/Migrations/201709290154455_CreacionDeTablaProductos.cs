namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaProductos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Marca = c.String(maxLength: 50),
                        PrecioCosto = c.Int(nullable: false),
                        PrecioVenta = c.Int(nullable: false),
                        ExistenciaInicial = c.Int(nullable: false),
                        ExistenciaActual = c.Int(nullable: false),
                        ExistenciaMinima = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Productos");
        }
    }
}
