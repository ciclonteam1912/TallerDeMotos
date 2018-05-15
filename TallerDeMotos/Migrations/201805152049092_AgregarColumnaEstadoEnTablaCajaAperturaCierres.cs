namespace TallerDeMotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarColumnaEstadoEnTablaCajaAperturaCierres : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CajaAperturaCierres", "EstaAbierta", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CajaAperturaCierres", "EstaAbierta");
        }
    }
}
