namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaEmpleados : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Cedula = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(maxLength: 255),
                        Telefono = c.String(maxLength: 50),
                        CorreoElectronico = c.String(maxLength: 50),
                        FechaDeNacimiento = c.DateTime(),
                        HoraDeEntrada = c.Time(precision: 7),
                        HoraDeSalida = c.Time(precision: 7),
                        Salario = c.Int(nullable: false),
                        FechaDeIngreso = c.DateTime(nullable: false),
                        CargoCodigo = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Cargos", t => t.CargoCodigo)
                .Index(t => t.CargoCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleados", "CargoCodigo", "dbo.Cargos");
            DropIndex("dbo.Empleados", new[] { "CargoCodigo" });
            DropTable("dbo.Empleados");
        }
    }
}
