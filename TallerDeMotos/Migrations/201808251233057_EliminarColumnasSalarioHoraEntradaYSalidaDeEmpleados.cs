namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EliminarColumnasSalarioHoraEntradaYSalidaDeEmpleados : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Empleados", "HoraDeEntrada");
            DropColumn("dbo.Empleados", "HoraDeSalida");
            DropColumn("dbo.Empleados", "Salario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empleados", "Salario", c => c.Int(nullable: false));
            AddColumn("dbo.Empleados", "HoraDeSalida", c => c.Time(precision: 7));
            AddColumn("dbo.Empleados", "HoraDeEntrada", c => c.Time(precision: 7));
        }
    }
}
