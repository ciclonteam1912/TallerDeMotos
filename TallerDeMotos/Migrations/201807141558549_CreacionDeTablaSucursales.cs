namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaSucursales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sucursales",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Direccion = c.String(nullable: false, maxLength: 255),
                        Telefono = c.String(nullable: false, maxLength: 50),
                        EmpresaCodigo = c.Int(nullable: false),
                        CiudadCodigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Ciudades", t => t.CiudadCodigo)
                .ForeignKey("dbo.Empresas", t => t.EmpresaCodigo)
                .Index(t => t.EmpresaCodigo)
                .Index(t => t.CiudadCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sucursales", "EmpresaCodigo", "dbo.Empresas");
            DropForeignKey("dbo.Sucursales", "CiudadCodigo", "dbo.Ciudades");
            DropIndex("dbo.Sucursales", new[] { "CiudadCodigo" });
            DropIndex("dbo.Sucursales", new[] { "EmpresaCodigo" });
            DropTable("dbo.Sucursales");
        }
    }
}
