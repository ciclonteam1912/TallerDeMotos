namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarEmpleadoPorDefectoEnTablaEmpleados : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Empleados (Nombre, Apellido, Cedula, Salario, FechaDeIngreso, CargoCodigo, CiudadCodigo) VALUES ('Administrador', 'Administrador', '0', 0, 15/8/2018, 3, 1)");
        }

        public override void Down()
        {
            Sql("DELETE FROM Empleados WHERE Nombre IN ('Administrador')");
        }
    }
}
