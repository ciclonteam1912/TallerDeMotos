namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnasRepresentanteFechaDeFundacionEnMarcas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marcas", "Representante", c => c.String(maxLength: 50));
            AddColumn("dbo.Marcas", "FechaDeFundacion", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Marcas", "FechaDeFundacion");
            DropColumn("dbo.Marcas", "Representante");
        }
    }
}
