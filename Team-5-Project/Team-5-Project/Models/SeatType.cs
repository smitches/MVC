using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team_5_Project.Models
{
    public class SeatType
    {
        //Static properties
        //PK
        public Int32 SeatTypeID { get; set; }

        //This is the name of the seat type (either economy or first class)
        public String Name { get; set; }

        //Navigation Properties
        public virtual List<Seat> Seats { get; set; }

    }
}