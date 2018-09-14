namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarPermisosPorDefecto : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Crear Aseguradora')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Editar Aseguradora')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Eliminar Aseguradora')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Crear Cliente')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Editar Cliente')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Eliminar Cliente')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Crear Empleado')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Editar Empleado')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Eliminar Empleado')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Crear Veh�culo')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Editar Veh�culo')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Eliminar Veh�culo')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Crear Usuario')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Editar Usuario')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Eliminar Usuario')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Crear Rol')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Editar Rol')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Eliminar Rol')");

        }

        public override void Down()
        {
            Sql("DELETE FROM AspNetPermissions WHERE Descripcion IN ('Crear Aseguradora', 'Editar Aseguradora', 'Eliminar Aseguradora')");
            Sql("DELETE FROM AspNetPermissions WHERE Descripcion IN ('Crear Cliente', 'Editar Cliente', 'Eliminar Cliente')");
            Sql("DELETE FROM AspNetPermissions WHERE Descripcion IN ('Crear Empleado', 'Editar Empleado', 'Eliminar Empleado')");
            Sql("DELETE FROM AspNetPermissions WHERE Descripcion IN ('Crear Veh�culo', 'Editar Veh�culo', 'Eliminar Veh�culo')");
            Sql("DELETE FROM AspNetPermissions WHERE Descripcion IN ('Crear Usuario', 'Editar Usuario', 'Eliminar Usuario')");
            Sql("DELETE FROM AspNetPermissions WHERE Descripcion IN ('Crear Rol', 'Editar Rol', 'Eliminar Rol')");

        }
    }
}
