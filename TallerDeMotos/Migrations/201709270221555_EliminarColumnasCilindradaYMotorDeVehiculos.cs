namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EliminarColumnasCilindradaYMotorDeVehiculos : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehiculos", "Motor");
            DropColumn("dbo.Vehiculos", "Cilindrada");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehiculos", "Cilindrada", c => c.Int());
            AddColumn("dbo.Vehiculos", "Motor", c => c.String(maxLength: 20));
        }
    }
}
