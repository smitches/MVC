namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newscratch : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketFlights", "Ticket_TicketID", "dbo.Tickets");
            DropForeignKey("dbo.TicketFlights", "Flight_FlightID", "dbo.Flights");
            DropForeignKey("dbo.AppUserReservations", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppUserReservations", "Reservation_ReservationID", "dbo.Reservations");
            DropIndex("dbo.TicketFlights", new[] { "Ticket_TicketID" });
            DropIndex("dbo.TicketFlights", new[] { "Flight_FlightID" });
            DropIndex("dbo.AppUserReservations", new[] { "AppUser_Id" });
            DropIndex("dbo.AppUserReservations", new[] { "Reservation_ReservationID" });
            CreateTable(
                "dbo.SeatTypes",
                c => new
                    {
                        SeatTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SeatTypeID);
            
            AddColumn("dbo.FlightNumbers", "endCityAirport", c => c.String());
            AddColumn("dbo.Flights", "Departed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Seats", "SeatType_SeatTypeID", c => c.Int());
            AddColumn("dbo.Tickets", "ActualFare", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tickets", "ChildDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tickets", "SeniorDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tickets", "Internetyes", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "InternetDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tickets", "FirstClass", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tickets", "EarlyDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tickets", "PayWithMiles", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "CheckedIn", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "Customer_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Tickets", "Flight_FlightID", c => c.Int());
            AddColumn("dbo.Reservations", "RoundTrip", c => c.Boolean(nullable: false));
            AddColumn("dbo.Reservations", "PrimaryTravelerID_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Routes", "RouteName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Miles", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Reservations", "PrimaryTravelerID_Id");
            CreateIndex("dbo.Tickets", "Customer_Id");
            CreateIndex("dbo.Tickets", "Flight_FlightID");
            CreateIndex("dbo.Seats", "SeatType_SeatTypeID");
            AddForeignKey("dbo.Reservations", "PrimaryTravelerID_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tickets", "Customer_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tickets", "Flight_FlightID", "dbo.Flights", "FlightID");
            AddForeignKey("dbo.Seats", "SeatType_SeatTypeID", "dbo.SeatTypes", "SeatTypeID");
            DropColumn("dbo.Reservations", "ActualFare");
            DropTable("dbo.TicketFlights");
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
            
            CreateTable(
                "dbo.TicketFlights",
                c => new
                    {
                        Ticket_TicketID = c.Int(nullable: false),
                        Flight_FlightID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ticket_TicketID, t.Flight_FlightID });
            
            AddColumn("dbo.Reservations", "ActualFare", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Seats", "SeatType_SeatTypeID", "dbo.SeatTypes");
            DropForeignKey("dbo.Tickets", "Flight_FlightID", "dbo.Flights");
            DropForeignKey("dbo.Tickets", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "PrimaryTravelerID_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Seats", new[] { "SeatType_SeatTypeID" });
            DropIndex("dbo.Tickets", new[] { "Flight_FlightID" });
            DropIndex("dbo.Tickets", new[] { "Customer_Id" });
            DropIndex("dbo.Reservations", new[] { "PrimaryTravelerID_Id" });
            AlterColumn("dbo.AspNetUsers", "Miles", c => c.Int(nullable: false));
            DropColumn("dbo.Routes", "RouteName");
            DropColumn("dbo.Reservations", "PrimaryTravelerID_Id");
            DropColumn("dbo.Reservations", "RoundTrip");
            DropColumn("dbo.Tickets", "Flight_FlightID");
            DropColumn("dbo.Tickets", "Customer_Id");
            DropColumn("dbo.Tickets", "CheckedIn");
            DropColumn("dbo.Tickets", "PayWithMiles");
            DropColumn("dbo.Tickets", "EarlyDiscount");
            DropColumn("dbo.Tickets", "FirstClass");
            DropColumn("dbo.Tickets", "InternetDiscount");
            DropColumn("dbo.Tickets", "Internetyes");
            DropColumn("dbo.Tickets", "SeniorDiscount");
            DropColumn("dbo.Tickets", "ChildDiscount");
            DropColumn("dbo.Tickets", "ActualFare");
            DropColumn("dbo.Seats", "SeatType_SeatTypeID");
            DropColumn("dbo.Flights", "Departed");
            DropColumn("dbo.FlightNumbers", "endCityAirport");
            DropTable("dbo.SeatTypes");
            CreateIndex("dbo.AppUserReservations", "Reservation_ReservationID");
            CreateIndex("dbo.AppUserReservations", "AppUser_Id");
            CreateIndex("dbo.TicketFlights", "Flight_FlightID");
            CreateIndex("dbo.TicketFlights", "Ticket_TicketID");
            AddForeignKey("dbo.AppUserReservations", "Reservation_ReservationID", "dbo.Reservations", "ReservationID", cascadeDelete: true);
            AddForeignKey("dbo.AppUserReservations", "AppUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TicketFlights", "Flight_FlightID", "dbo.Flights", "FlightID", cascadeDelete: true);
            AddForeignKey("dbo.TicketFlights", "Ticket_TicketID", "dbo.Tickets", "TicketID", cascadeDelete: true);
        }
    }
}
