namespace TallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarClaveUnicaEnColumnaRucDeProveedores : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Proveedores", "Ruc", unique: true, name: "IX_RucProveedor");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Proveedores", "IX_RucProveedor");
        }
    }
}
