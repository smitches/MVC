using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Team_5_Project.DAL;

namespace Team_5_Project.Models
{
    public class Reservation
    {
        //THIS IS OUR RESERVATION PK - DONT USE THIS FOR ANYTIHNG!
        public Int32 ReservationID { get; set; }
        
        //THis is our "RESERVATIONID"
        public Int32 ReservationNumber { get; set; }

        [Required]
        public virtual List<Ticket> Tickets { get; set; }

        public Boolean RoundTrip { get; set; }

        public virtual AppUser PrimaryTravelerID { get; set; }

        public Reservation() { }
        
        public Reservation(AppDbContext db)
        {
            Tickets = new List<Ticket>();
            if (db.Reservations.ToList().Count() == 0)
            {
                ReservationNumber = 10000;
            }
            else
            {
                ReservationNumber = db.Reservations.Max(c => c.ReservationNumber) + 1;
            }
        }
       
    }
}