namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seatchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seats", "SeatType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Seats", "SeatType");
        }
    }
}
