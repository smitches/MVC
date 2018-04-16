using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team_5_Project.Models
{
    
    public class City
    {

        public Int32 CityID { get; set; }

        //[Required(ErrorMessage = "Name is required.")]
        //[Index("CityIndex",IsUnique =true)]
        //[StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "City")]
        public String CityName { get; set; }


        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public String State { get; set; }

        //[Required(ErrorMessage = "Airport is required")]
        //[Index("AirportIndex", IsUnique =true)]
        [Display(Name = "Airport Name")]
        public String Airport { get; set; }
        
            

        public virtual List<Route> Routes { get; set; }

        public virtual List<FlightNumber> FlightNumbers { get; set; }
    }
}