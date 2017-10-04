namespace TallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionDeTablaOrdenCompras : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrdenCompras",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        OrdenCompraNumero = c.Int(nullable: false),
                        FechaDeEmision = c.DateTime(nullable: false),
                        FormaPagoCodigo = c.Byte(nullable: false),
                        SubTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.FormasPago", t => t.FormaPagoCodigo)
                .Index(t => t.OrdenCompraNumero, unique: true)
                .Index(t => t.FormaPagoCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenCompras", "FormaPagoCodigo", "dbo.FormasPago");
            DropIndex("dbo.OrdenCompras", new[] { "FormaPagoCodigo" });
            DropIndex("dbo.OrdenCompras", new[] { "OrdenCompraNumero" });
            DropTable("dbo.OrdenCompras");
        }
    }
}
