namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaRucEnTablaTalonarios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Talonarios", "Ruc", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Talonarios", "Ruc");
        }
    }
}
