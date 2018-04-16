namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class viewmodelupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Miles", c => c.Int(nullable: false));
            DropColumn("dbo.Tickets", "PayWithMiles");
            DropColumn("dbo.Reservations", "RoundTrip");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "RoundTrip", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "PayWithMiles", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Miles", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
