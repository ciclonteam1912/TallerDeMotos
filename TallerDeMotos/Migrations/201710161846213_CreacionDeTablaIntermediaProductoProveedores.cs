namespace TallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionDeTablaIntermediaProductoProveedores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductoProveedores",
                c => new
                    {
                        ProductoCodigo = c.Int(nullable: false),
                        ProveedorCodigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductoCodigo, t.ProveedorCodigo })
                .ForeignKey("dbo.Productos", t => t.ProductoCodigo, cascadeDelete: true)
                .ForeignKey("dbo.Proveedores", t => t.ProveedorCodigo, cascadeDelete: true)
                .Index(t => t.ProductoCodigo)
                .Index(t => t.ProveedorCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductoProveedores", "ProveedorCodigo", "dbo.Proveedores");
            DropForeignKey("dbo.ProductoProveedores", "ProductoCodigo", "dbo.Productos");
            DropIndex("dbo.ProductoProveedores", new[] { "ProveedorCodigo" });
            DropIndex("dbo.ProductoProveedores", new[] { "ProductoCodigo" });
            DropTable("dbo.ProductoProveedores");
        }
    }
}
