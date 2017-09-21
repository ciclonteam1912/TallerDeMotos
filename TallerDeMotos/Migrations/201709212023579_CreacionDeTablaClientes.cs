namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaClientes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(maxLength: 50),
                        Telefono = c.String(maxLength: 50),
                        Direccion = c.String(maxLength: 255),
                        CorreoElectronico = c.String(maxLength: 50),
                        NombrePropietario = c.String(maxLength: 50),
                        FechaDeNacimiento = c.DateTime(),
                        FechaDeIngreso = c.DateTime(nullable: false),
                        PersoneriaCodigo = c.Byte(nullable: false),
                        TipoDocumentoCodigo = c.Byte(nullable: false),
                        ValorDocumento = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Personerias", t => t.PersoneriaCodigo)
                .ForeignKey("dbo.TipoDocumentos", t => t.TipoDocumentoCodigo)
                .Index(t => t.PersoneriaCodigo)
                .Index(t => t.TipoDocumentoCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "TipoDocumentoCodigo", "dbo.TipoDocumentos");
            DropForeignKey("dbo.Clientes", "PersoneriaCodigo", "dbo.Personerias");
            DropIndex("dbo.Clientes", new[] { "TipoDocumentoCodigo" });
            DropIndex("dbo.Clientes", new[] { "PersoneriaCodigo" });
            DropTable("dbo.Clientes");
        }
    }
}
