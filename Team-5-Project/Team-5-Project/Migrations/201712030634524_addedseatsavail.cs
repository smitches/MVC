namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedseatsavail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "SeatsAvailable", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "SeatsAvailable");
        }
    }
}
