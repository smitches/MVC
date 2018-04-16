using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team_5_Project.Models
{
    public class ReportVM
    {
        public Int32 ReportVMID {get; set;}

        [DataType(DataType.Date)]
        public DateTime BegDate { get; set; }

        public List<Int32> CityIDs { get; set; }

        public List<Int32> SeatTypeIDs { get; set; }

        public List<Int32> RouteIDs { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public virtual ReportTypes ReportType { get; set; }
    }
    public class ReportTypes
    {
        public Int32 ReportTypesID { get; set; }

        public String Type { get; set; }
    }

    public class TwoAirport
    {
        public Int32 TwoAirportID { get; set; }

        public String City1Airport { get; set; }

        public String City2Airport { get; set; }

        public String CityCombo { get; set; }
    }

    public class RevenueVM
    {
        public Int32 RevenueVMID { get; set; }

        public Decimal Revenue { get; set; }

        public Int32 SeatCount { get; set; }

        public virtual List<Flight> Flights { get; set; }
    }
}