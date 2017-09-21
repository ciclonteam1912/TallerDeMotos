namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaModelos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Modelos",
                c => new
                    {
                        Codigo = c.Byte(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                        MarcaCodigo = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Marcas", t => t.MarcaCodigo)
                .Index(t => t.MarcaCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modelos", "MarcaCodigo", "dbo.Marcas");
            DropIndex("dbo.Modelos", new[] { "MarcaCodigo" });
            DropTable("dbo.Modelos");
        }
    }
}
