namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArrivalTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "ArrivalTime", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "ArrivalTime");
        }
    }
}
