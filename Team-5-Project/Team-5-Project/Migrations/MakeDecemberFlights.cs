using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Team_5_Project.DAL;
using Team_5_Project.Models;

namespace Team_5_Project.Migrations
{
    public class MakeDecemberFlights
    {


        public static List<DateTime> DecemberDays()
        {
            DateTime incrementDate = new DateTime(2017, 12, 1, 0, 0, 0);
            List<DateTime> DecemberDays = new List<DateTime>();
            while (incrementDate < new DateTime(2017, 12, 26, 0, 0, 0))
            {
                DecemberDays.Add(incrementDate);
                incrementDate += new TimeSpan(24, 0, 0);
            }
            return DecemberDays;
        }

        public void SeedAllFlights(AppDbContext db)
        {
            List<FlightNumber> allFlightList = db.FlightNumbers.ToList();

            foreach (FlightNumber thisflightnumber in allFlightList)
            {
                List<Day> daysflown = new List<Day>();

                if (thisflightnumber.DepartureDays.ToList() != null)
                {
                    daysflown = thisflightnumber.DepartureDays.ToList();
                    foreach (DateTime Day in DecemberDays())
                        {
                        String dayofweek=Day.DayOfWeek.ToString();
                        foreach (Day dayflown in daysflown)
                        {
                            if (dayofweek == dayflown.Name)
                            {

                                Flight existingFlight = db.Flights.FirstOrDefault(c=>c.FlightNumber.FlightNumberID==thisflightnumber.FlightNumberID&&c.DepartDateTime.Day==(Day.Day));
                                if (existingFlight == null)
                                {
                                    Flight flight = new Flight(thisflightnumber.BaseFare,db);
                                    flight.DepartDateTime = Day + thisflightnumber.DepartTime;
                                    flight.FlightNumber = thisflightnumber;
                                    db.Flights.Add(flight);
                                    db.SaveChanges();
                                }
                                
                            }
                        }



                    }
                }

            }
        }
        
    }
}