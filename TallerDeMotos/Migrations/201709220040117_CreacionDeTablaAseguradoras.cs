namespace TallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionDeTablaAseguradoras : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aseguradoras",
                c => new
                    {
                        Codigo = c.Byte(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                        Contacto = c.String(maxLength: 50),
                        Ruc = c.String(maxLength: 10),
                        Direccion = c.String(maxLength: 255),
                        Telefono = c.String(maxLength: 50),
                        CorreoElectronico = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Aseguradoras");
        }
    }
}
