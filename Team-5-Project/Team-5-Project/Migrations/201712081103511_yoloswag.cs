namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yoloswag : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RevenueVMs", "SeatCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RevenueVMs", "SeatCount", c => c.Int(nullable: false));
        }
    }
}
