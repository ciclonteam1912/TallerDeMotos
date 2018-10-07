namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CargarContactosPorDefectoEnContactos : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Contactos (Descripcion) VALUES ('Twitter')");
            Sql("INSERT INTO Contactos (Descripcion) VALUES ('Facebook')");
            Sql("INSERT INTO Contactos (Descripcion) VALUES ('Instagram')");
            Sql("INSERT INTO Contactos (Descripcion) VALUES ('Página Web')");
            Sql("INSERT INTO Contactos (Descripcion) VALUES ('Celular')");
            Sql("INSERT INTO Contactos (Descripcion) VALUES ('Teléfono')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Contactos WHERE Descripcion IN ('Twitter', 'Facebook', 'Instagram', 'Página Web', 'Celular', 'Teléfono')");
        }
    }
}
