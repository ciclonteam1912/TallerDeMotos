namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CargarDatosEnLasTablasPersoneriasYTipoDocumentos : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Personerias (Descripcion) VALUES ('Física')");
            Sql("INSERT INTO Personerias (Descripcion) VALUES ('Jurídica')");

            Sql("INSERT INTO TipoDocumentos (Descripcion) VALUES ('Cédula')");
            Sql("INSERT INTO TipoDocumentos (Descripcion) VALUES ('RUC')");
            Sql("INSERT INTO TipoDocumentos (Descripcion) VALUES ('Pasaporte')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Personerias WHERE Descripcion IN ('Física', 'Jurídica')");
            Sql("DELETE FROM TipoDocumentos WHERE Descripcion IN ('Cédula', 'RUC', 'Pasaporte')");
        }
    }
}
