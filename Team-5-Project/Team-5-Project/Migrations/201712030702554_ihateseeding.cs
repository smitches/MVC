namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ihateseeding : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Flights", "SeatsAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flights", "SeatsAvailable", c => c.Int(nullable: false));
        }
    }
}
