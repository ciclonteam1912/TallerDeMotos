namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarRelacionMuchosAMuchosEntreAspNetRolesYAspNetPermissions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRolePermissions",
                c => new
                    {
                        Permisos_Id = c.Int(nullable: false),
                        ApplicationRole_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Permisos_Id, t.ApplicationRole_Id })
                .ForeignKey("dbo.AspNetPermissions", t => t.Permisos_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.ApplicationRole_Id, cascadeDelete: true)
                .Index(t => t.Permisos_Id)
                .Index(t => t.ApplicationRole_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetRolePermissions", "ApplicationRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetRolePermissions", "Permisos_Id", "dbo.AspNetPermissions");
            DropIndex("dbo.AspNetRolePermissions", new[] { "ApplicationRole_Id" });
            DropIndex("dbo.AspNetRolePermissions", new[] { "Permisos_Id" });
            DropTable("dbo.AspNetRolePermissions");
        }
    }
}
