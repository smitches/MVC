using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team_5_Project.Models
{
    public class FlightNumber
    {
        public Int32 FlightNumberID { get; set; }

        public Int32 Number { get; set; }

        public virtual List<Day> DepartureDays { get; set; }

        public Boolean BeenDisabled { get; set; }
        
        public virtual City startCity { get; set; }

        public String endCityAirport { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name ="Departure Time")]
        public TimeSpan DepartTime { get; set; }

       

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public Decimal BaseFare { get; set; }

        public virtual Route Route {get; set;}
        
        public virtual List<Flight> Flights { get; set; }
    }
}