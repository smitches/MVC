using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team_5_Project.Models
{
    public class FlightSearchViewModel
    {

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name = "Departs from")]
        public DateTime BeginDepartureTimeRange { get; set; }

        [Display(Name ="Departure Airport")]
        public Int32 DepartureCityID { get; set; }


        [Display(Name = "Arrival Airport")]
        public Int32 ArrivalCityID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name = "Until")]
        public DateTime EndDepartureTimeRange { get; set; }

        public Int32 SeatsNeeded { get; set; }

        public virtual Flight departureflight { get; set; }

        public Boolean Nonstop { get; set; }

        public Boolean RoundTrip { get; set; }

        public List<Flight> availableflights { get; set; }

        public string fake { get; set; }

        public string fake2 { get; set; }


    }
    public class ReturnFSVM : FlightSearchViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name = "Departs from")]
        public DateTime ReturnBeginDepartureTimeRange { get; set; }

        [Display(Name = "Departure Airport")]
        public Int32 ReturnDepartureCityID { get; set; }


        [Display(Name = "Arrival Airport")]
        public Int32 ReturnArrivalCityID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name = "Until")]
        public DateTime ReturnEndDepartureTimeRange { get; set; }

        public virtual Flight returnflight { get; set; }

        public Boolean nonstoptwo { get; set; }

        public List<Flight> availableReturnFlights { get; set; }

        public Reservation reservation { get; set; }

        public List <Seat> Seats { get; set; }
    }
}