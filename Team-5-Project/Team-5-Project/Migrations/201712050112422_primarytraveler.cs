namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primarytraveler : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppUserReservations", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppUserReservations", "Reservation_ReservationID", "dbo.Reservations");
            DropIndex("dbo.AppUserReservations", new[] { "AppUser_Id" });
            DropIndex("dbo.AppUserReservations", new[] { "Reservation_ReservationID" });
            AddColumn("dbo.Reservations", "AppUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Reservations", "PrimaryTraveler_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Reservation_ReservationID", c => c.Int());
            CreateIndex("dbo.Reservations", "AppUser_Id");
            CreateIndex("dbo.Reservations", "PrimaryTraveler_Id");
            CreateIndex("dbo.AspNetUsers", "Reservation_ReservationID");
            AddForeignKey("dbo.Reservations", "AppUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Reservation_ReservationID", "dbo.Reservations", "ReservationID");
            AddForeignKey("dbo.Reservations", "PrimaryTraveler_Id", "dbo.AspNetUsers", "Id");
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
            
            DropForeignKey("dbo.Reservations", "PrimaryTraveler_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Reservation_ReservationID", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "Reservation_ReservationID" });
            DropIndex("dbo.Reservations", new[] { "PrimaryTraveler_Id" });
            DropIndex("dbo.Reservations", new[] { "AppUser_Id" });
            DropColumn("dbo.AspNetUsers", "Reservation_ReservationID");
            DropColumn("dbo.Reservations", "PrimaryTraveler_Id");
            DropColumn("dbo.Reservations", "AppUser_Id");
            CreateIndex("dbo.AppUserReservations", "Reservation_ReservationID");
            CreateIndex("dbo.AppUserReservations", "AppUser_Id");
            AddForeignKey("dbo.AppUserReservations", "Reservation_ReservationID", "dbo.Reservations", "ReservationID", cascadeDelete: true);
            AddForeignKey("dbo.AppUserReservations", "AppUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
