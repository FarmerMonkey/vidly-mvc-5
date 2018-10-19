namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0e4e50fb-aafb-48e7-bf84-3dd226489629', N'admin@domain.com', 0, N'ADWsDom680mwiSmt9lERACDDWbMyzbDf4JuHEOs0uHM/qVULkJZ/9CtMRTZ1MFOEtg==', N'09c7e7c4-cfe7-446c-9636-21369f880520', NULL, 0, 0, NULL, 1, 0, N'admin@domain.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c07f3620-fa29-4471-a819-830b4eb7555e', N'guest@vidly.com', 0, N'AB5Q7oaxUavBUn83ovmx8Om68gJ73hTZezObMxK2I/HV1MSaLE2ug1eKDdhk9EKBNA==', N'74fc73cd-1544-4167-b479-529144d7b07d', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6a8f3d35-7737-49c0-b42e-f6050afeb554', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0e4e50fb-aafb-48e7-bf84-3dd226489629', N'6a8f3d35-7737-49c0-b42e-f6050afeb554')
");
        }

        public override void Down()
        {
        }
    }
}
