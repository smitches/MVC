namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thegreatmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReportTypes",
                c => new
                    {
                        ReportTypesID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ReportTypesID);
            
            CreateTable(
                "dbo.RevenueVMs",
                c => new
                    {
                        RevenueVMID = c.Int(nullable: false, identity: true),
                        Revenue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RevenueVMID);
            
            CreateTable(
                "dbo.TwoAirports",
                c => new
                    {
                        TwoAirportID = c.Int(nullable: false, identity: true),
                        City1Airport = c.String(),
                        City2Airport = c.String(),
                        CityCombo = c.String(),
                    })
                .PrimaryKey(t => t.TwoAirportID);
            
            AddColumn("dbo.Flights", "RevenueVM_RevenueVMID", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "MI", c => c.String(maxLength: 1));
            AlterColumn("dbo.AspNetUsers", "ZipCode", c => c.String(maxLength: 5));
            CreateIndex("dbo.Flights", "RevenueVM_RevenueVMID");
            AddForeignKey("dbo.Flights", "RevenueVM_RevenueVMID", "dbo.RevenueVMs", "RevenueVMID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flights", "RevenueVM_RevenueVMID", "dbo.RevenueVMs");
            DropIndex("dbo.Flights", new[] { "RevenueVM_RevenueVMID" });
            AlterColumn("dbo.AspNetUsers", "ZipCode", c => c.String());
            AlterColumn("dbo.AspNetUsers", "MI", c => c.String());
            DropColumn("dbo.Flights", "RevenueVM_RevenueVMID");
            DropTable("dbo.TwoAirports");
            DropTable("dbo.RevenueVMs");
            DropTable("dbo.ReportTypes");
        }
    }
}
