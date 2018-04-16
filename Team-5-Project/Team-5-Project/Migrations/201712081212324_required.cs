namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Reservation_ReservationID", "dbo.Reservations");
            DropIndex("dbo.Tickets", new[] { "Reservation_ReservationID" });
            AlterColumn("dbo.Tickets", "Reservation_ReservationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "Reservation_ReservationID");
            AddForeignKey("dbo.Tickets", "Reservation_ReservationID", "dbo.Reservations", "ReservationID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Reservation_ReservationID", "dbo.Reservations");
            DropIndex("dbo.Tickets", new[] { "Reservation_ReservationID" });
            AlterColumn("dbo.Tickets", "Reservation_ReservationID", c => c.Int());
            CreateIndex("dbo.Tickets", "Reservation_ReservationID");
            AddForeignKey("dbo.Tickets", "Reservation_ReservationID", "dbo.Reservations", "ReservationID");
        }
    }
}
