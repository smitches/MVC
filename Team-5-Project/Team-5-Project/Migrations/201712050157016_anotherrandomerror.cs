namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherrandomerror : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "PrimaryTravelerID_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "Flight_FlightID", "dbo.Flights");
            DropIndex("dbo.Tickets", new[] { "Customer_Id" });
            DropIndex("dbo.Tickets", new[] { "Flight_FlightID" });
            DropIndex("dbo.Reservations", new[] { "PrimaryTravelerID_Id" });
            CreateTable(
                "dbo.TicketFlights",
                c => new
                    {
                        Ticket_TicketID = c.Int(nullable: false),
                        Flight_FlightID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ticket_TicketID, t.Flight_FlightID })
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketID, cascadeDelete: true)
                .ForeignKey("dbo.Flights", t => t.Flight_FlightID, cascadeDelete: true)
                .Index(t => t.Ticket_TicketID)
                .Index(t => t.Flight_FlightID);
            
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
            DropColumn("dbo.Tickets", "Flight_FlightID");
            DropColumn("dbo.Reservations", "PrimaryTravelerID_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "PrimaryTravelerID_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Tickets", "Flight_FlightID", c => c.Int());
            AddColumn("dbo.Tickets", "Customer_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.AppUserReservations", "Reservation_ReservationID", "dbo.Reservations");
            DropForeignKey("dbo.AppUserReservations", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TicketFlights", "Flight_FlightID", "dbo.Flights");
            DropForeignKey("dbo.TicketFlights", "Ticket_TicketID", "dbo.Tickets");
            DropIndex("dbo.AppUserReservations", new[] { "Reservation_ReservationID" });
            DropIndex("dbo.AppUserReservations", new[] { "AppUser_Id" });
            DropIndex("dbo.TicketFlights", new[] { "Flight_FlightID" });
            DropIndex("dbo.TicketFlights", new[] { "Ticket_TicketID" });
            DropColumn("dbo.Reservations", "PrimaryTravelerID");
            DropTable("dbo.AppUserReservations");
            DropTable("dbo.TicketFlights");
            CreateIndex("dbo.Reservations", "PrimaryTravelerID_Id");
            CreateIndex("dbo.Tickets", "Flight_FlightID");
            CreateIndex("dbo.Tickets", "Customer_Id");
            AddForeignKey("dbo.Tickets", "Flight_FlightID", "dbo.Flights", "FlightID");
            AddForeignKey("dbo.Tickets", "Customer_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Reservations", "PrimaryTravelerID_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
