namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pilotsandshit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "PilotFullName", c => c.String());
            AddColumn("dbo.Flights", "CoPilotFullName", c => c.String());
            AddColumn("dbo.Flights", "CabinCrewFullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "CabinCrewFullName");
            DropColumn("dbo.Flights", "CoPilotFullName");
            DropColumn("dbo.Flights", "PilotFullName");
        }
    }
}
