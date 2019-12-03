namespace MVC_MiniProject_lastweek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
             INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e8d4e894-028b-440a-b9de-c2a7fb127511', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'15a6d842-738a-4228-8e0f-8fceb8d42671', N'anusha@hcl.com', 0, N'AN9Gv6GprnWlgIz0Z2mLKHocIS6ApGXfq74x6/TxP2U7r9Ow6Q1JjvcRWFpUPphiww==', N'7405afe9-4a41-4a44-8a2e-38228adc5a21', NULL, 0, 0, NULL, 1, 0, N'anusha@hcl.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'45564ee7-0a20-4592-b86d-b420e90315bc', N'admin@hcl.com', 0, N'AIIPQJvVRb58DyUsvB7T6ERaHZbZNhRIH1GDgA1uWRMGWkihn4x1xWzVQlFsD49pCw==', N'3ad520f1-c249-4b23-9d7a-19bcd7dc8753', NULL, 0, 0, NULL, 1, 0, N'admin@hcl.com')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'45564ee7-0a20-4592-b86d-b420e90315bc', N'e8d4e894-028b-440a-b9de-c2a7fb127511')
");
        }
        
        public override void Down()
        {
        }
    }
}
