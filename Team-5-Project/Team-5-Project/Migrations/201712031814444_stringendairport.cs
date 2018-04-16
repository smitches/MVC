namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringendairport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FlightNumbers", "endCityAirport", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FlightNumbers", "endCityAirport");
        }
    }
}
