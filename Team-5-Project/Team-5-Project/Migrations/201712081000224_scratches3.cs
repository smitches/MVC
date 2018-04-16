namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scratches3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Flights", "RevenueVM_RevenueVMID", "dbo.RevenueVMs");
            DropIndex("dbo.Flights", new[] { "RevenueVM_RevenueVMID" });
            AddColumn("dbo.Tickets", "LapChild", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "ZipCode", c => c.String());
            DropColumn("dbo.Flights", "RevenueVM_RevenueVMID");
            DropTable("dbo.ReportTypes");
            DropTable("dbo.RevenueVMs");
            DropTable("dbo.TwoAirports");
        }
        
        public override void Down()
        {
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
            
            CreateTable(
                "dbo.RevenueVMs",
                c => new
                    {
                        RevenueVMID = c.Int(nullable: false, identity: true),
                        Revenue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RevenueVMID);
            
            CreateTable(
                "dbo.ReportTypes",
                c => new
                    {
                        ReportTypesID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ReportTypesID);
            
            AddColumn("dbo.Flights", "RevenueVM_RevenueVMID", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "ZipCode", c => c.String(maxLength: 5));
            DropColumn("dbo.Tickets", "LapChild");
            CreateIndex("dbo.Flights", "RevenueVM_RevenueVMID");
            AddForeignKey("dbo.Flights", "RevenueVM_RevenueVMID", "dbo.RevenueVMs", "RevenueVMID");
        }
    }
}
