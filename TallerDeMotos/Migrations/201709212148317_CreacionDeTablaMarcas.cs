namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaMarcas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Codigo = c.Byte(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Marcas");
        }
    }
}
