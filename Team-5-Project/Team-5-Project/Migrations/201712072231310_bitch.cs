namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bitch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "CheckedIn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "CheckedIn");
        }
    }
}
