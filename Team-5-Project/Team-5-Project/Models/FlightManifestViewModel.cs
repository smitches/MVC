using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team_5_Project.Models
{
    public class FlightManifestViewModel
    {
        public virtual Flight Flight { get; set; }

        public virtual List<Seat> Seats { get; set; }
        
        public String Empty { get; set; }
        public FlightManifestViewModel()
        {
            Empty = "Empty";
        }
    }
}