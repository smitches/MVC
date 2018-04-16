namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hallelujah : DbMigration
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
                        CityName = c.String(),
                        State = c.String(nullable: false),
                        Airport = c.String(),
                    })
                .PrimaryKey(t => t.CityID);
            
            CreateTable(
                "dbo.FlightNumbers",
                c => new
                    {
                        FlightNumberID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        BeenDisabled = c.Boolean(nullable: false),
                        endCityAirport = c.String(),
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
                        SeatsAvailable = c.Int(nullable: false),
                        Departed = c.Boolean(nullable: false),
                        DepartDateTime = c.DateTime(nullable: false),
                        ActualFare = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cancelled = c.Boolean(nullable: false),
                        Crew_CrewID = c.Int(),
                        FlightNumber_FlightNumberID = c.Int(),
                        RevenueVM_RevenueVMID = c.Int(),
                    })
                .PrimaryKey(t => t.FlightID)
                .ForeignKey("dbo.Crews", t => t.Crew_CrewID)
                .ForeignKey("dbo.FlightNumbers", t => t.FlightNumber_FlightNumberID)
                .ForeignKey("dbo.RevenueVMs", t => t.RevenueVM_RevenueVMID)
                .Index(t => t.Crew_CrewID)
                .Index(t => t.FlightNumber_FlightNumberID)
                .Index(t => t.RevenueVM_RevenueVMID);
            
            CreateTable(
                "dbo.Crews",
                c => new
                    {
                        CrewID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CrewID);
            
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
                        Miles = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                        CustomerSearchViewModel_CustomerSearchViewModelID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Crews", t => t.Crew_CrewID)
                .ForeignKey("dbo.CustomerSearchViewModels", t => t.CustomerSearchViewModel_CustomerSearchViewModelID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Crew_CrewID)
                .Index(t => t.CustomerSearchViewModel_CustomerSearchViewModelID);
            
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
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false, identity: true),
                        ReservationNumber = c.Int(nullable: false),
                        RoundTrip = c.Boolean(nullable: false),
                        PrimaryTravelerID_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReservationID)
                .ForeignKey("dbo.AspNetUsers", t => t.PrimaryTravelerID_Id)
                .Index(t => t.PrimaryTravelerID_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false),
                        ActualFare = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountedFare = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChildDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SeniorDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Internetyes = c.Boolean(nullable: false),
                        InternetDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstClass = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EarlyDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayWithMiles = c.Boolean(nullable: false),
                        CheckedIn = c.Boolean(nullable: false),
                        LapChild = c.Boolean(nullable: false),
                        Customer_Id = c.String(maxLength: 128),
                        Flight_FlightID = c.Int(),
                        Reservation_ReservationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id)
                .ForeignKey("dbo.Flights", t => t.Flight_FlightID)
                .ForeignKey("dbo.Reservations", t => t.Reservation_ReservationID, cascadeDelete: true)
                .ForeignKey("dbo.Seats", t => t.TicketID)
                .Index(t => t.TicketID)
                .Index(t => t.Customer_Id)
                .Index(t => t.Flight_FlightID)
                .Index(t => t.Reservation_ReservationID);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatID = c.Int(nullable: false, identity: true),
                        SeatName = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        Flight_FlightID = c.Int(),
                        SeatType_SeatTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.SeatID)
                .ForeignKey("dbo.Flights", t => t.Flight_FlightID)
                .ForeignKey("dbo.SeatTypes", t => t.SeatType_SeatTypeID)
                .Index(t => t.Flight_FlightID)
                .Index(t => t.SeatType_SeatTypeID);
            
            CreateTable(
                "dbo.SeatTypes",
                c => new
                    {
                        SeatTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SeatTypeID);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteID = c.Int(nullable: false, identity: true),
                        RouteName = c.String(),
                        Miles = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Hours = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.RouteID);
            
            CreateTable(
                "dbo.CustomerSearchViewModels",
                c => new
                    {
                        CustomerSearchViewModelID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AdvantageNumber = c.Int(),
                        MI = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Miles = c.Int(nullable: false),
                        PrimaryID = c.Int(nullable: false),
                        SeatID = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerSearchViewModelID)
                .ForeignKey("dbo.Seats", t => t.SeatID)
                .Index(t => t.SeatID);
            
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
                        SeatCount = c.Int(nullable: false),
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
            DropForeignKey("dbo.Flights", "RevenueVM_RevenueVMID", "dbo.RevenueVMs");
            DropForeignKey("dbo.CustomerSearchViewModels", "SeatID", "dbo.Seats");
            DropForeignKey("dbo.AspNetUsers", "CustomerSearchViewModel_CustomerSearchViewModelID", "dbo.CustomerSearchViewModels");
            DropForeignKey("dbo.FlightNumbers", "startCity_CityID", "dbo.Cities");
            DropForeignKey("dbo.FlightNumbers", "Route_RouteID", "dbo.Routes");
            DropForeignKey("dbo.RouteCities", "City_CityID", "dbo.Cities");
            DropForeignKey("dbo.RouteCities", "Route_RouteID", "dbo.Routes");
            DropForeignKey("dbo.Flights", "FlightNumber_FlightNumberID", "dbo.FlightNumbers");
            DropForeignKey("dbo.Flights", "Crew_CrewID", "dbo.Crews");
            DropForeignKey("dbo.AspNetUsers", "Crew_CrewID", "dbo.Crews");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "TicketID", "dbo.Seats");
            DropForeignKey("dbo.Seats", "SeatType_SeatTypeID", "dbo.SeatTypes");
            DropForeignKey("dbo.Seats", "Flight_FlightID", "dbo.Flights");
            DropForeignKey("dbo.Tickets", "Reservation_ReservationID", "dbo.Reservations");
            DropForeignKey("dbo.Tickets", "Flight_FlightID", "dbo.Flights");
            DropForeignKey("dbo.Tickets", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "PrimaryTravelerID_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DayFlightNumbers", "FlightNumber_FlightNumberID", "dbo.FlightNumbers");
            DropForeignKey("dbo.DayFlightNumbers", "Day_DayID", "dbo.Days");
            DropIndex("dbo.RouteCities", new[] { "City_CityID" });
            DropIndex("dbo.RouteCities", new[] { "Route_RouteID" });
            DropIndex("dbo.DayFlightNumbers", new[] { "FlightNumber_FlightNumberID" });
            DropIndex("dbo.DayFlightNumbers", new[] { "Day_DayID" });
            DropIndex("dbo.CustomerSearchViewModels", new[] { "SeatID" });
            DropIndex("dbo.Seats", new[] { "SeatType_SeatTypeID" });
            DropIndex("dbo.Seats", new[] { "Flight_FlightID" });
            DropIndex("dbo.Tickets", new[] { "Reservation_ReservationID" });
            DropIndex("dbo.Tickets", new[] { "Flight_FlightID" });
            DropIndex("dbo.Tickets", new[] { "Customer_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketID" });
            DropIndex("dbo.Reservations", new[] { "PrimaryTravelerID_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "CustomerSearchViewModel_CustomerSearchViewModelID" });
            DropIndex("dbo.AspNetUsers", new[] { "Crew_CrewID" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Flights", new[] { "RevenueVM_RevenueVMID" });
            DropIndex("dbo.Flights", new[] { "FlightNumber_FlightNumberID" });
            DropIndex("dbo.Flights", new[] { "Crew_CrewID" });
            DropIndex("dbo.FlightNumbers", new[] { "startCity_CityID" });
            DropIndex("dbo.FlightNumbers", new[] { "Route_RouteID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.RouteCities");
            DropTable("dbo.DayFlightNumbers");
            DropTable("dbo.TwoAirports");
            DropTable("dbo.RevenueVMs");
            DropTable("dbo.ReportTypes");
            DropTable("dbo.MailModels");
            DropTable("dbo.CustomerSearchViewModels");
            DropTable("dbo.Routes");
            DropTable("dbo.SeatTypes");
            DropTable("dbo.Seats");
            DropTable("dbo.Tickets");
            DropTable("dbo.Reservations");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Crews");
            DropTable("dbo.Flights");
            DropTable("dbo.Days");
            DropTable("dbo.FlightNumbers");
            DropTable("dbo.Cities");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
