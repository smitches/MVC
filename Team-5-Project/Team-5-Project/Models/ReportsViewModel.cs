using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team_5_Project.Models
{
    public class ReportsViewModel
    {
        //Beginning of Date Range 
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name = "From: ")]
        public DateTime DateRangeStart { get; set; }

        //End of Date Range
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name = "To: ")]
        public DateTime DateRangeEnd { get; set; }

        //City
        [Display(Name = "Departure Airport Location")]
        public List<City> DepartureCities { get; set; }

        //Revenue
        public Decimal Revenue { get; set; }

        //Route
        [Display(Name = "Route")]
        public Route Route { get; set; }

        //Economy or FirstClass
        [Display(Name = "Seating Type")]
        public SeatType SeatType { get; set; }

        public List<Seat> Seats { get; set; }



        public ReportsViewModel()
        {
            Seats = new List<Seat>();
            DepartureCities = new List<City>();
            DateRangeStart = new DateTime(2017, 11, 30);
            DateRangeEnd = new DateTime(2017, 12, 31);
        }
    }
}