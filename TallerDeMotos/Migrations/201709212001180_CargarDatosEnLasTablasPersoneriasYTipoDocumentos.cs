namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CargarDatosEnLasTablasPersoneriasYTipoDocumentos : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Personerias (Descripcion) VALUES ('F�sica')");
            Sql("INSERT INTO Personerias (Descripcion) VALUES ('Jur�dica')");

            Sql("INSERT INTO TipoDocumentos (Descripcion) VALUES ('C�dula')");
            Sql("INSERT INTO TipoDocumentos (Descripcion) VALUES ('RUC')");
            Sql("INSERT INTO TipoDocumentos (Descripcion) VALUES ('Pasaporte')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Personerias WHERE Descripcion IN ('F�sica', 'Jur�dica')");
            Sql("DELETE FROM TipoDocumentos WHERE Descripcion IN ('C�dula', 'RUC', 'Pasaporte')");
        }
    }
}
