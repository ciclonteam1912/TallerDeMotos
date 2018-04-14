namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaCajas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cajas",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        UsuarioId = c.String(nullable: false, maxLength: 128),
                        EstadoActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cajas", "UsuarioId", "dbo.AspNetUsers");
            DropIndex("dbo.Cajas", new[] { "UsuarioId" });
            DropTable("dbo.Cajas");
        }
    }
}
