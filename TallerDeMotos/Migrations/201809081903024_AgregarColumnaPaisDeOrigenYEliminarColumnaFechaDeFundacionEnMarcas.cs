namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaPaisDeOrigenYEliminarColumnaFechaDeFundacionEnMarcas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marcas", "PaisDeOrigen", c => c.String(maxLength: 20));
            DropColumn("dbo.Marcas", "FechaDeFundacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Marcas", "FechaDeFundacion", c => c.DateTime());
            DropColumn("dbo.Marcas", "PaisDeOrigen");
        }
    }
}
