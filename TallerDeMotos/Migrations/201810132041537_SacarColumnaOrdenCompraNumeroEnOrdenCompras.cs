namespace TallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SacarColumnaOrdenCompraNumeroEnOrdenCompras : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.OrdenCompras", new[] { "OrdenCompraNumero" });
            DropColumn("dbo.OrdenCompras", "OrdenCompraNumero");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrdenCompras", "OrdenCompraNumero", c => c.Int(nullable: false));
            CreateIndex("dbo.OrdenCompras", "OrdenCompraNumero", unique: true);
        }
    }
}
