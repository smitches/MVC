using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team_5_Project.Models
{
    public class Day
    {
        public Int32 DayID { get; set; }

        public String Name { get; set; }

        public virtual List<FlightNumber> FlightNumbers { get; set; }
    }
}