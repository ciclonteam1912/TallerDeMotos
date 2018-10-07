namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaProveedorContactos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProveedorContactos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProveedorCodigo = c.Int(nullable: false),
                        ContactoCodigo = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contactos", t => t.ContactoCodigo, cascadeDelete: true)
                .ForeignKey("dbo.Proveedores", t => t.ProveedorCodigo, cascadeDelete: true)
                .Index(t => t.ProveedorCodigo)
                .Index(t => t.ContactoCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProveedorContactos", "ProveedorCodigo", "dbo.Proveedores");
            DropForeignKey("dbo.ProveedorContactos", "ContactoCodigo", "dbo.Contactos");
            DropIndex("dbo.ProveedorContactos", new[] { "ContactoCodigo" });
            DropIndex("dbo.ProveedorContactos", new[] { "ProveedorCodigo" });
            DropTable("dbo.ProveedorContactos");
        }
    }
}
