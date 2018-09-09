namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaAspNetPermissions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetPermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Descripcion, unique: true, name: "IX_DescripcionPermiso");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetPermissions", "IX_DescripcionPermiso");
            DropTable("dbo.AspNetPermissions");
        }
    }
}
