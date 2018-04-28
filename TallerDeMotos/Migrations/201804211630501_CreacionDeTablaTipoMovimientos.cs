namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreacionDeTablaTipoMovimientos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoMovimientos",
                c => new
                    {
                        Codigo = c.Byte(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TipoMovimientos");
        }
    }
}
