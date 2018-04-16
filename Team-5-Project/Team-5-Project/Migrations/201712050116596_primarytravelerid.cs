namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primarytravelerid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Reservation_ReservationID", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "PrimaryTraveler_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reservations", new[] { "AppUser_Id" });
            DropIndex("dbo.Reservations", new[] { "PrimaryTraveler_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Reservation_ReservationID" });
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
            DropColumn("dbo.Reservations", "AppUser_Id");
            DropColumn("dbo.Reservations", "PrimaryTraveler_Id");
            DropColumn("dbo.AspNetUsers", "Reservation_ReservationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Reservation_ReservationID", c => c.Int());
            AddColumn("dbo.Reservations", "PrimaryTraveler_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Reservations", "AppUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.AppUserReservations", "Reservation_ReservationID", "dbo.Reservations");
            DropForeignKey("dbo.AppUserReservations", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AppUserReservations", new[] { "Reservation_ReservationID" });
            DropIndex("dbo.AppUserReservations", new[] { "AppUser_Id" });
            DropColumn("dbo.Reservations", "PrimaryTravelerID");
            DropTable("dbo.AppUserReservations");
            CreateIndex("dbo.AspNetUsers", "Reservation_ReservationID");
            CreateIndex("dbo.Reservations", "PrimaryTraveler_Id");
            CreateIndex("dbo.Reservations", "AppUser_Id");
            AddForeignKey("dbo.Reservations", "PrimaryTraveler_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Reservation_ReservationID", "dbo.Reservations", "ReservationID");
            AddForeignKey("dbo.Reservations", "AppUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
