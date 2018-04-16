using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Team_5_Project.DAL;

namespace Team_5_Project.Models
{
    
    public class Seat
    {
        //Seat PK
        public Int32 SeatID { get; set; }
        
        //Static properties
        public String SeatName { get; set; }
        public Boolean IsAvailable { get; set; }

        //Navigation Properties
        public virtual Ticket Ticket { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual SeatType SeatType{ get; set; }


        //Constructors
        public Seat() { }

        public Seat(string name, AppDbContext db)
        {
            SeatName = name;
            IsAvailable = true;
            if (SeatName[0] == '1' || SeatName[0] == '2')
            {
                SeatType = db.SeatType.FirstOrDefault(s => s.Name == "FirstClass");
            }
            else
            {
                SeatType = db.SeatType.FirstOrDefault(s => s.Name == "Economy");
            }
        }

    }
}