namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarEmpleadoPorDefectoEnTablaEmpleados : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Empleados (Nombre, Apellido, FechaDeIngreso, CargoCodigo, CiudadCodigo, NumeroDocumento) VALUES ('Administrador', 'Administrador', 15/8/2018, 8, 1, '0')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Empleados WHERE Nombre IN ('Administrador')");
        }
    }
}
