namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaEmpresas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        RazonSocial = c.String(nullable: false, maxLength: 50),
                        Ruc = c.String(nullable: false, maxLength: 50),
                        CorreoElectronico = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Empresas");
        }
    }
}
