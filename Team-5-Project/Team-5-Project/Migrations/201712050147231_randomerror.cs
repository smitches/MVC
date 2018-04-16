namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class randomerror : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "PrimaryTravelerID_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "Customer_Id" });
            DropIndex("dbo.Reservations", new[] { "PrimaryTravelerID_Id" });
            CreateTable(
                "dbo.AppUserReservations",
                c => new
                    {
                        AppUser_Id = c.String(nullable: false, maxLength: 128),
                        Reservation_ReservationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppUser_Id, t.Reservation_ReservationID })
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Reservations", t => t.Reservation_ReservationID, cascadeDelete: true)
                .Index(t => t.AppUser_Id)
                .Index(t => t.Reservation_ReservationID);
            
            AddColumn("dbo.Reservations", "PrimaryTravelerID", c => c.Int(nullable: false));
            DropColumn("dbo.Tickets", "Customer_Id");
            DropColumn("dbo.Reservations", "PrimaryTravelerID_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "PrimaryTravelerID_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Tickets", "Customer_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.AppUserReservations", "Reservation_ReservationID", "dbo.Reservations");
            DropForeignKey("dbo.AppUserReservations", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AppUserReservations", new[] { "Reservation_ReservationID" });
            DropIndex("dbo.AppUserReservations", new[] { "AppUser_Id" });
            DropColumn("dbo.Reservations", "PrimaryTravelerID");
            DropTable("dbo.AppUserReservations");
            CreateIndex("dbo.Reservations", "PrimaryTravelerID_Id");
            CreateIndex("dbo.Tickets", "Customer_Id");
            AddForeignKey("dbo.Tickets", "Customer_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Reservations", "PrimaryTravelerID_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
