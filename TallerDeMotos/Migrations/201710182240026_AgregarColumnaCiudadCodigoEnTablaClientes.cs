namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaCiudadCodigoEnTablaClientes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "CiudadCodigo", c => c.Int(nullable: false));
            CreateIndex("dbo.Clientes", "CiudadCodigo");
            AddForeignKey("dbo.Clientes", "CiudadCodigo", "dbo.Ciudades", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "CiudadCodigo", "dbo.Ciudades");
            DropIndex("dbo.Clientes", new[] { "CiudadCodigo" });
            DropColumn("dbo.Clientes", "CiudadCodigo");
        }
    }
}
