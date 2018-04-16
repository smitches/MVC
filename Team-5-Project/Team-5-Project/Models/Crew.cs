using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team_5_Project.Models
{
    public class Crew
    {
        //Static Properties
        public Int32 CrewID { get; set; }

        //Navigation Properties
        public virtual List<AppUser> CrewMembers { get; set; }
        
        public virtual List<Flight> Flight { get; set; }

        public Crew()
        {
            CrewMembers = new List<AppUser>();
        }
    }
}