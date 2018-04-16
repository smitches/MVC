namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "ReservationNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "DiscountedFare", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "DiscountedFare");
            DropColumn("dbo.Reservations", "ReservationNumber");
        }
    }
}
