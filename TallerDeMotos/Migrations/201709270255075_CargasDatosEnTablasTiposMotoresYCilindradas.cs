namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CargasDatosEnTablasTiposMotoresYCilindradas : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TiposMotores (Descripcion) VALUES ('Varilla')");
            Sql("INSERT INTO TiposMotores (Descripcion) VALUES ('Cadenita')");

            Sql("INSERT INTO Cilindradas (NumeroCilindrada) VALUES (100)");
            Sql("INSERT INTO Cilindradas (NumeroCilindrada) VALUES (110)");
            Sql("INSERT INTO Cilindradas (NumeroCilindrada) VALUES (150)");
            Sql("INSERT INTO Cilindradas (NumeroCilindrada) VALUES (170)");
            Sql("INSERT INTO Cilindradas (NumeroCilindrada) VALUES (200)");
            Sql("INSERT INTO Cilindradas (NumeroCilindrada) VALUES (250)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM TiposMotores WHERE Descripcion IN ('Varilla', 'Cadenita')");
            Sql("DELETE FROM Cilindradas WHERE NumeroCilindrada IN (100, 110, 150, 170, 200, 250)");
        }
    }
}
