namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RevenueVMs", "SeatCount", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "MI", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "MI", c => c.String());
            DropColumn("dbo.RevenueVMs", "SeatCount");
        }
    }
}
