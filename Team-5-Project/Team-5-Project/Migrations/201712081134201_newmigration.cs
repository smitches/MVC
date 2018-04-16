namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "LapChild", c => c.Boolean(nullable: false));
            AddColumn("dbo.RevenueVMs", "SeatCount", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "ZipCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ZipCode", c => c.String(maxLength: 5));
            DropColumn("dbo.RevenueVMs", "SeatCount");
            DropColumn("dbo.Tickets", "LapChild");
        }
    }
}
