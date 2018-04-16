namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmpTypetoRegViewModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Flights", "Departed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flights", "Departed", c => c.Boolean(nullable: false));
        }
    }
}
