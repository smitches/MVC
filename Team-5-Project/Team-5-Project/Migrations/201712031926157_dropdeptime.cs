namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropdeptime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Flights", "ArrivalTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flights", "ArrivalTime", c => c.DateTime(nullable: false));
        }
    }
}
