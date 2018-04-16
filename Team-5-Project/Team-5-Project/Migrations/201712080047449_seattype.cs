namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seattype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SeatTypes",
                c => new
                    {
                        SeatTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SeatTypeID);
            
            AddColumn("dbo.Seats", "SeatType_SeatTypeID", c => c.Int());
            CreateIndex("dbo.Seats", "SeatType_SeatTypeID");
            AddForeignKey("dbo.Seats", "SeatType_SeatTypeID", "dbo.SeatTypes", "SeatTypeID");
            DropColumn("dbo.Seats", "SeatType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seats", "SeatType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Seats", "SeatType_SeatTypeID", "dbo.SeatTypes");
            DropIndex("dbo.Seats", new[] { "SeatType_SeatTypeID" });
            DropColumn("dbo.Seats", "SeatType_SeatTypeID");
            DropTable("dbo.SeatTypes");
        }
    }
}
