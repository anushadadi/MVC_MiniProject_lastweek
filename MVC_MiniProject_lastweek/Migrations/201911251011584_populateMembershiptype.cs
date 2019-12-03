namespace MVC_MiniProject_lastweek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMembershiptype : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into MembershipTypes(Id,SignUpFee,DurationInMonths,DiscountRate)Values(1,0,0,0)");
            Sql("Insert Into MembershipTypes(Id,SignUpFee,DurationInMonths,DiscountRate)Values(2,100,12,10)");
            Sql("Insert Into MembershipTypes(Id,SignUpFee,DurationInMonths,DiscountRate)Values(3,500,6,20)");
            Sql("Insert Into MembershipTypes(Id,SignUpFee,DurationInMonths,DiscountRate)Values(4,1000,4,30)");

        }
        
        public override void Down()
        {
        }
    }
}
