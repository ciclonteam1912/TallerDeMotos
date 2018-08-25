namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarRestriccionUnicaYCambiarNombreColumnaCedulaEnEmpleados : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empleados", "NumeroDocumento", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Empleados", "NumeroDocumento", unique: true);
            DropColumn("dbo.Empleados", "Cedula");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empleados", "Cedula", c => c.String(nullable: false, maxLength: 50));
            DropIndex("dbo.Empleados", new[] { "NumeroDocumento" });
            DropColumn("dbo.Empleados", "NumeroDocumento");
        }
    }
}
