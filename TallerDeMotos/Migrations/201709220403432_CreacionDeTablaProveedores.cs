namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaProveedores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        RazonSocial = c.String(nullable: false, maxLength: 50),
                        Contacto = c.String(maxLength: 50),
                        Propietario = c.String(maxLength: 50),
                        Ruc = c.String(nullable: false, maxLength: 10),
                        Direccion = c.String(maxLength: 255),
                        Telefono = c.String(maxLength: 50),
                        CorreoElectronico = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Proveedores");
        }
    }
}
