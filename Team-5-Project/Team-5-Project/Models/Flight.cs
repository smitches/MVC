using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Team_5_Project.DAL;

namespace Team_5_Project.Models
{
    
    public class Flight
    {
        private AppDbContext db = new AppDbContext();
        public Int32 FlightID { get; set; }

        public Int32 SeatsAvailable { get; set; }

        public Boolean Departed { get; set; }       

        private static List<String> ListofAllSeats()
        {
            List<String> allseatslist = new List<String>();
            allseatslist.Add("1A");
            allseatslist.Add("1B");
            allseatslist.Add("2A");
            allseatslist.Add("2B");
            allseatslist.Add("3A");
            allseatslist.Add("3B");
            allseatslist.Add("3C");
            allseatslist.Add("3D");
            allseatslist.Add("4A");
            allseatslist.Add("4B");
            allseatslist.Add("4C");
            allseatslist.Add("4D");
            allseatslist.Add("5A");
            allseatslist.Add("5B");
            allseatslist.Add("5C");
            allseatslist.Add("5D");
            return allseatslist;
        }
        
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        public DateTime DepartDateTime { get; set; }

        public Decimal ActualFare { get; set; }

        public Boolean Cancelled { get; set; }

        public string PilotFullName { get; set; }
        public string CoPilotFullName { get; set; }
        public string CabinCrewFullName { get; set; }

        //Navigation Properties
        public virtual FlightNumber FlightNumber { get; set; }

        public virtual List<Ticket> Tickets { get; set; }

        public virtual List<Seat> Seats { get; set; }

        public virtual Crew Crew { get; set; }

        //Constructors
        public Flight() { }

        public Flight(Decimal basefare, AppDbContext db)
        {
            ActualFare = basefare;
            Seats = new List<Seat>();
            foreach (String seatname in ListofAllSeats())
            {
                Seats.Add(new Seat(seatname, db));
            }
            SeatsAvailable = 16;
            Departed = false;
        }
    }
    
}