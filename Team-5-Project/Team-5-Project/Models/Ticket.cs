using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team_5_Project.Models
{
    public class Ticket
    {
        public Int32 TicketID { get; set; }

        public Decimal ActualFare { get; set; }

        public Decimal DiscountedFare { get; set; }

        public Decimal ChildDiscount { get; set; }

        public Decimal SeniorDiscount { get; set; }

        public Boolean Internetyes { get; set; }

        public Decimal InternetDiscount { get; set; }

        public Decimal FirstClass { get; set; }

        public Decimal EarlyDiscount { get; set; }

        public Boolean PayWithMiles { get; set; }

        public Boolean CheckedIn { get; set; }

        public string LapChild { get; set; }

        //public Boolean PayInDollars { get; set; }

        [Required]
        public virtual Reservation Reservation { get; set; }

        public virtual Flight Flight { get; set; }

        [Required]
        public virtual Seat Seat { get; set; }

        public virtual AppUser Customer { get; set; }

        public Ticket(Seat seatobj, Reservation reserveobj)
        {
            Seat = seatobj;
            Reservation = reserveobj;
            
            ActualFare = 0.00m;
        }



        public Ticket() { }
    }
}