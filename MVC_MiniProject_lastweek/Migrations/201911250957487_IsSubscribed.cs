namespace MVC_MiniProject_lastweek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsSubscribed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubsribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubsribedToNewsLetter");
        }
    }
}
