namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualfare : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "ActualFare", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Reservations", "ActualFare");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "ActualFare", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Tickets", "ActualFare");
        }
    }
}
