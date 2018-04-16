namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matchdb : DbMigration
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
            AddColumn("dbo.Tickets", "Customer_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Tickets", "Flight_FlightID", c => c.Int());
            AddColumn("dbo.Reservations", "PrimaryTravelerID_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tickets", "Customer_Id");
            CreateIndex("dbo.Tickets", "Flight_FlightID");
            CreateIndex("dbo.Reservations", "PrimaryTravelerID_Id");
            AddForeignKey("dbo.Reservations", "PrimaryTravelerID_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tickets", "Customer_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tickets", "Flight_FlightID", "dbo.Flights", "FlightID");
            DropColumn("dbo.Reservations", "PrimaryTravelerID");
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
            
            AddColumn("dbo.Reservations", "PrimaryTravelerID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tickets", "Flight_FlightID", "dbo.Flights");
            DropForeignKey("dbo.Tickets", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "PrimaryTravelerID_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reservations", new[] { "PrimaryTravelerID_Id" });
            DropIndex("dbo.Tickets", new[] { "Flight_FlightID" });
            DropIndex("dbo.Tickets", new[] { "Customer_Id" });
            DropColumn("dbo.Reservations", "PrimaryTravelerID_Id");
            DropColumn("dbo.Tickets", "Flight_FlightID");
            DropColumn("dbo.Tickets", "Customer_Id");
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
