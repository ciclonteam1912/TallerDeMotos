namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaEmpleadoCodigoEnTablaAspNetUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EmpleadoCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "EmpleadoCodigo", unique: true);
            AddForeignKey("dbo.AspNetUsers", "EmpleadoCodigo", "dbo.Empleados", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "EmpleadoCodigo", "dbo.Empleados");
            DropIndex("dbo.AspNetUsers", new[] { "EmpleadoCodigo" });
            DropColumn("dbo.AspNetUsers", "EmpleadoCodigo");
        }
    }
}
