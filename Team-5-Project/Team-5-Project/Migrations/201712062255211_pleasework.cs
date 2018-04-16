namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pleasework : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "RoundTrip", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "RoundTrip");
        }
    }
}
