namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movedcustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppUserReservations", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppUserReservations", "Reservation_ReservationID", "dbo.Reservations");
            DropIndex("dbo.AppUserReservations", new[] { "AppUser_Id" });
            DropIndex("dbo.AppUserReservations", new[] { "Reservation_ReservationID" });
            AddColumn("dbo.Tickets", "Customer_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Reservations", "PrimaryTravelerID_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tickets", "Customer_Id");
            CreateIndex("dbo.Reservations", "PrimaryTravelerID_Id");
            AddForeignKey("dbo.Reservations", "PrimaryTravelerID_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tickets", "Customer_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Reservations", "PrimaryTravelerID");
            DropTable("dbo.AppUserReservations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AppUserReservations",
                c => new
                    {
                        AppUser_Id = c.String(nullable: false, maxLength: 128),
                        Reservation_ReservationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppUser_Id, t.Reservation_ReservationID });
            
            AddColumn("dbo.Reservations", "PrimaryTravelerID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tickets", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "PrimaryTravelerID_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reservations", new[] { "PrimaryTravelerID_Id" });
            DropIndex("dbo.Tickets", new[] { "Customer_Id" });
            DropColumn("dbo.Reservations", "PrimaryTravelerID_Id");
            DropColumn("dbo.Tickets", "Customer_Id");
            CreateIndex("dbo.AppUserReservations", "Reservation_ReservationID");
            CreateIndex("dbo.AppUserReservations", "AppUser_Id");
            AddForeignKey("dbo.AppUserReservations", "Reservation_ReservationID", "dbo.Reservations", "ReservationID", cascadeDelete: true);
            AddForeignKey("dbo.AppUserReservations", "AppUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
