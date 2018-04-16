using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team_5_Project.Models
{
    public class Route
    {
        //static properties
        public Int32 RouteID { get; set; }

        public string RouteName { get; set; }
        
        //navigational properties
        public virtual List<FlightNumber> FlightNumbers { get; set; }

        public virtual List<City> Cities { get; set; }

        public Route()
        {
            Miles = 0;
            Hours = new TimeSpan(0,0,0);

            Cities = new List<City>();
            FlightNumbers = new List<FlightNumber>();

        }

        [Required]
        public Decimal Miles { get; set; }

        [Required]
        public TimeSpan Hours { get; set; }
    }
}