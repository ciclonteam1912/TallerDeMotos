namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarPermisosPorDefecto2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Crear Talonario')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Editar Talonario')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Eliminar Talonario')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Crear Proveedor')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Editar Proveedor')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Eliminar Proveedor')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Crear Producto/Servicio')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Editar Producto/Servicio')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Eliminar Producto/Servicio')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Crear Caja')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Editar Caja')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Eliminar Caja')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Crear Presupuesto')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Editar Presupuesto')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Anular Presupuesto')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Crear Factura de Venta')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Crear Factura de Compra')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Crear Orden de Compra')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Anular Orden de Compra')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Realizar Apertura y Cierre')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Eliminar Apertura y Cierre')");
            Sql("INSERT INTO AspNetPermissions (Descripcion) VALUES ('Realizar Movimiento de Caja')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM AspNetPermissions WHERE Descripcion IN ('Crear Talonario', 'Editar Talonario', 'Eliminar Talonario')");
            Sql("DELETE FROM AspNetPermissions WHERE Descripcion IN ('Crear Proveedor', 'Editar Proveedor', 'Eliminar Proveedor')");
            Sql("DELETE FROM AspNetPermissions WHERE Descripcion IN ('Crear Producto/Servicio', 'Editar Producto/Servicio', 'Eliminar Producto/Servicio')");
            Sql("DELETE FROM AspNetPermissions WHERE Descripcion IN ('Crear Caja', 'Editar Caja', 'Eliminar Caja')");
            Sql("DELETE FROM AspNetPermissions WHERE Descripcion IN ('Crear Presupuesto', 'Editar Presupuesto', 'Anular Presupuesto')");
            Sql("DELETE FROM AspNetPermissions WHERE Descripcion IN ('Crear Factura de Venta')");
            Sql("DELETE FROM AspNetPermissions WHERE Descripcion IN ('Crear Factura de Compra')");
            Sql("DELETE FROM AspNetPermissions WHERE Descripcion IN ('Crear Orden de Compra', 'Anular Orden de Compra')");
            Sql("DELETE FROM AspNetPermissions WHERE Descripcion IN ('Realizar Apertura y Cierre', 'Eliminar Apertura y Cierre')");
            Sql("DELETE FROM AspNetPermissions WHERE Descripcion IN ('Realizar Movimiento de Caja')");
        }
    }
}
