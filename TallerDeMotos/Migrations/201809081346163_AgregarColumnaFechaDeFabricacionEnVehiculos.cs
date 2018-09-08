namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AgregarColumnaFechaDeFabricacionEnVehiculos : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Vehiculos", new[] { "Matricula" });
            AddColumn("dbo.Vehiculos", "FechaDeFabricacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehiculos", "Matricula", c => c.String(maxLength: 20));
            AlterColumn("dbo.Vehiculos", "Color", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Vehiculos", "Matricula", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vehiculos", new[] { "Matricula" });
            AlterColumn("dbo.Vehiculos", "Color", c => c.String(maxLength: 20));
            AlterColumn("dbo.Vehiculos", "Matricula", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Vehiculos", "FechaDeFabricacion");
            CreateIndex("dbo.Vehiculos", "Matricula", unique: true);
        }
    }
}
