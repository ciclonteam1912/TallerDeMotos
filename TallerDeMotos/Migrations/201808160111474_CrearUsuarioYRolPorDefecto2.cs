namespace TallerDeMotos.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CrearUsuarioYRolPorDefecto2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [EmpleadoCodigo]) VALUES (N'6cb1f3e1-1ca9-48c9-a265-5fb3ba9e1ba1', N'admingtmpedrozo@gmail.com', 0, N'APQO9CrOf7B+s2oIm1aIx5Y5YRrcxWlKOoJTFl5zH+TFwTfdDWw8ewrBr2R0Bucolg==', N'1c187358-2571-4781-b028-a31e593a7ded', NULL, 0, 0, NULL, 1, 0, N'admin', 1)

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6cb1f3e1-1ca9-48c9-a265-5fb3ba9e1ba1', N'c2625e46-98d0-42ee-9aec-d38a408ee62c')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
