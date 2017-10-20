namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaCiudadCodigoEnTablaEmpleados : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empleados", "CiudadCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.Empleados", "CiudadCodigo");
            AddForeignKey("dbo.Empleados", "CiudadCodigo", "dbo.Ciudades", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleados", "CiudadCodigo", "dbo.Ciudades");
            DropIndex("dbo.Empleados", new[] { "CiudadCodigo" });
            DropColumn("dbo.Empleados", "CiudadCodigo");
        }
    }
}
