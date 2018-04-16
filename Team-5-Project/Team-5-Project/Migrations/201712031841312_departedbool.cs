namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class departedbool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "Departed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "Departed");
        }
    }
}
