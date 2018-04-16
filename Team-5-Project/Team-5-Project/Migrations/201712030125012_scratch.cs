namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scratch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 20),
                        State = c.String(nullable: false),
                        Airport = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.CityID)
                .Index(t => t.CityName, unique: true, name: "CityIndex")
                .Index(t => t.Airport, unique: true, name: "AirportIndex");
            
            CreateTable(
                "dbo.FlightNumbers",
                c => new
                    {
                        FlightNumberID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        BeenDisabled = c.Boolean(nullable: false),
                        DepartTime = c.Time(nullable: false, precision: 7),
                        BaseFare = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Route_RouteID = c.Int(),
                        startCity_CityID = c.Int(),
                    })
                .PrimaryKey(t => t.FlightNumberID)
                .ForeignKey("dbo.Routes", t => t.Route_RouteID)
                .ForeignKey("dbo.Cities", t => t.startCity_CityID)
                .Index(t => t.Route_RouteID)
                .Index(t => t.startCity_CityID);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        DayID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DayID);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightID = c.Int(nullable: false, identity: true),
                        DepartDateTime = c.DateTime(nullable: false),
                        ActualFare = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cancelled = c.Boolean(nullable: false),
                        FlightNumber_FlightNumberID = c.Int(),
                        Crew_CrewID = c.Int(),
                    })
                .PrimaryKey(t => t.FlightID)
                .ForeignKey("dbo.FlightNumbers", t => t.FlightNumber_FlightNumberID)
                .ForeignKey("dbo.Crews", t => t.Crew_CrewID)
                .Index(t => t.FlightNumber_FlightNumberID)
                .Index(t => t.Crew_CrewID);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatID = c.Int(nullable: false, identity: true),
                        SeatName = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        Flight_FlightID = c.Int(),
                    })
                .PrimaryKey(t => t.SeatID)
                .ForeignKey("dbo.Flights", t => t.Flight_FlightID)
                .Index(t => t.Flight_FlightID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false),
                        Reservation_ReservationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Reservations", t => t.Reservation_ReservationID, cascadeDelete: true)
                .ForeignKey("dbo.Seats", t => t.TicketID)
                .Index(t => t.TicketID)
                .Index(t => t.Reservation_ReservationID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false, identity: true),
                        ActualFare = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ReservationID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        MI = c.String(),
                        LastName = c.String(nullable: false),
                        AdvantageNumber = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        City = c.String(),
                        Address = c.String(),
                        ZipCode = c.String(),
                        State = c.String(),
                        Miles = c.Int(nullable: false),
                        SSN = c.String(),
                        EmpType = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Crew_CrewID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Crews", t => t.Crew_CrewID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Crew_CrewID);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Crews",
                c => new
                    {
                        CrewID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CrewID);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteID = c.Int(nullable: false, identity: true),
                        Miles = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Hours = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.RouteID);
            
            CreateTable(
                "dbo.MailModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        From = c.String(nullable: false),
                        To = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DayFlightNumbers",
                c => new
                    {
                        Day_DayID = c.Int(nullable: false),
                        FlightNumber_FlightNumberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Day_DayID, t.FlightNumber_FlightNumberID })
                .ForeignKey("dbo.Days", t => t.Day_DayID, cascadeDelete: true)
                .ForeignKey("dbo.FlightNumbers", t => t.FlightNumber_FlightNumberID, cascadeDelete: true)
                .Index(t => t.Day_DayID)
                .Index(t => t.FlightNumber_FlightNumberID);
            
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
            
            CreateTable(
                "dbo.RouteCities",
                c => new
                    {
                        Route_RouteID = c.Int(nullable: false),
                        City_CityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Route_RouteID, t.City_CityID })
                .ForeignKey("dbo.Routes", t => t.Route_RouteID, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.City_CityID, cascadeDelete: true)
                .Index(t => t.Route_RouteID)
                .Index(t => t.City_CityID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FlightNumbers", "startCity_CityID", "dbo.Cities");
            DropForeignKey("dbo.FlightNumbers", "Route_RouteID", "dbo.Routes");
            DropForeignKey("dbo.RouteCities", "City_CityID", "dbo.Cities");
            DropForeignKey("dbo.RouteCities", "Route_RouteID", "dbo.Routes");
            DropForeignKey("dbo.Tickets", "TicketID", "dbo.Seats");
            DropForeignKey("dbo.Tickets", "Reservation_ReservationID", "dbo.Reservations");
            DropForeignKey("dbo.Flights", "Crew_CrewID", "dbo.Crews");
            DropForeignKey("dbo.AspNetUsers", "Crew_CrewID", "dbo.Crews");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppUserReservations", "Reservation_ReservationID", "dbo.Reservations");
            DropForeignKey("dbo.AppUserReservations", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TicketFlights", "Flight_FlightID", "dbo.Flights");
            DropForeignKey("dbo.TicketFlights", "Ticket_TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Seats", "Flight_FlightID", "dbo.Flights");
            DropForeignKey("dbo.Flights", "FlightNumber_FlightNumberID", "dbo.FlightNumbers");
            DropForeignKey("dbo.DayFlightNumbers", "FlightNumber_FlightNumberID", "dbo.FlightNumbers");
            DropForeignKey("dbo.DayFlightNumbers", "Day_DayID", "dbo.Days");
            DropIndex("dbo.RouteCities", new[] { "City_CityID" });
            DropIndex("dbo.RouteCities", new[] { "Route_RouteID" });
            DropIndex("dbo.AppUserReservations", new[] { "Reservation_ReservationID" });
            DropIndex("dbo.AppUserReservations", new[] { "AppUser_Id" });
            DropIndex("dbo.TicketFlights", new[] { "Flight_FlightID" });
            DropIndex("dbo.TicketFlights", new[] { "Ticket_TicketID" });
            DropIndex("dbo.DayFlightNumbers", new[] { "FlightNumber_FlightNumberID" });
            DropIndex("dbo.DayFlightNumbers", new[] { "Day_DayID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Crew_CrewID" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Tickets", new[] { "Reservation_ReservationID" });
            DropIndex("dbo.Tickets", new[] { "TicketID" });
            DropIndex("dbo.Seats", new[] { "Flight_FlightID" });
            DropIndex("dbo.Flights", new[] { "Crew_CrewID" });
            DropIndex("dbo.Flights", new[] { "FlightNumber_FlightNumberID" });
            DropIndex("dbo.FlightNumbers", new[] { "startCity_CityID" });
            DropIndex("dbo.FlightNumbers", new[] { "Route_RouteID" });
            DropIndex("dbo.Cities", "AirportIndex");
            DropIndex("dbo.Cities", "CityIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.RouteCities");
            DropTable("dbo.AppUserReservations");
            DropTable("dbo.TicketFlights");
            DropTable("dbo.DayFlightNumbers");
            DropTable("dbo.MailModels");
            DropTable("dbo.Routes");
            DropTable("dbo.Crews");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Reservations");
            DropTable("dbo.Tickets");
            DropTable("dbo.Seats");
            DropTable("dbo.Flights");
            DropTable("dbo.Days");
            DropTable("dbo.FlightNumbers");
            DropTable("dbo.Cities");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
