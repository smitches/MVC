using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team_5_Project.DAL;
using Team_5_Project.Models;

namespace Team_5_Project.Controllers

{   
    public class FlightsController: Controller
    {
        


        private AppDbContext db = new AppDbContext();

        public ActionResult FlightsDepartedBeforeEighth()
        {
            List<Flight> allflights = db.Flights.ToList();
            foreach (Flight thisflight in allflights)
            {

                if (thisflight.DepartDateTime<new DateTime(2017, 12, 8, 0, 0, 0))
                {
                    thisflight.Departed = true;
                    db.Flights.Attach(thisflight);
                    db.Entry(thisflight).Property(x => x.Departed).IsModified = true;
                    db.SaveChanges();
                }
                        
                    
                

            }
            return RedirectToAction("Index");
        }

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

        public static List<DateTime> DecemberDaysLeft()
        {
            List<DateTime> DaysLeftList = new List<DateTime>();
            DateTime daybegins = DateTime.Now - DateTime.Now.TimeOfDay + new TimeSpan(24, 0, 0);
            while (daybegins < new DateTime(2017, 12, 26, 0, 0, 0))
            {
                DaysLeftList.Add(daybegins);
                daybegins += new TimeSpan(24, 0, 0);
            }
            return DaysLeftList;
        }

        public ActionResult SeedNewFlightNumber()
        {
            
            List<Day> daysflown = new List<Day>();
            Int32 maxindex = db.FlightNumbers.Max(c => c.FlightNumberID);
            FlightNumber newflightNumber = db.FlightNumbers.Find(maxindex);

            if (newflightNumber.DepartureDays.Count >0)
            {
                //var query = db.Flights.Where(c => c.DepartDateTime > DateTime.Now - DateTime.Now.TimeOfDay + new TimeSpan(24, 0, 0) && c.FlightNumber.FlightNumberID == newflightNumber.FlightNumberID).ToList();
                //foreach (Flight flightinfuturecancelled in query)
                //{
                //    var query2 = db.Seats.Where(c => c.Flight.FlightID == flightinfuturecancelled.FlightID).ToList();
                //    foreach( Seat seat in query2)
                //    {
                //        db.Seats.Remove(S)
                //    }
                //    db.Flights.Remove(flightinfuturecancelled);

                //}
                //db.SaveChanges();

                daysflown = newflightNumber.DepartureDays.ToList();
                foreach (DateTime Day in DecemberDaysLeft())
                {
                    String dayofweek = Day.DayOfWeek.ToString();
                    foreach (Day dayflown in daysflown)
                    {
                        if (dayofweek == dayflown.Name)
                        {
                            Flight newflight = new Flight(newflightNumber.BaseFare, db);
                            newflight.Cancelled = false;
                            newflight.DepartDateTime = Day + newflightNumber.DepartTime;
                            newflight.Departed = false;
                            newflight.FlightNumber = newflightNumber;
                            db.Flights.Add(newflight);
                            db.SaveChanges();
                            return RedirectToAction("Index", "Cities");
                                

                        }
                    }
                }
            }
            else
            {
                //var query = db.Flights.Where(c => c.DepartDateTime > DateTime.Now-DateTime.Now.TimeOfDay+new TimeSpan(24,0,0)&&c.FlightNumber.FlightNumberID==newflightNumber.FlightNumberID).ToList();
                //foreach (Flight flightinfuturecancelled in query)
                //{
                //    db.Flights.Remove(flightinfuturecancelled);

                //}
                //db.SaveChanges();
                return RedirectToAction("Index", "FlightNumbers");
            }
            return RedirectToAction("Index", "Routes");
        }

        
        public ActionResult CheckIn(int id)
        {
            Flight flight = db.Flights.Find(id);

            return View(flight);
        }

        public ActionResult CheckInPerson(int id, int ticketid)
        {
            Flight flight = db.Flights.Find(id);
            Ticket ticket = db.Tickets.Find(ticketid);

            ticket.CheckedIn = true;
            db.SaveChanges();

            return View("CheckIn",flight);
        }



        //public ActionResult Seed(FlightNumber thisflightnumber)
        //{

        //    List<Day> daysflown = new List<Day>();


        //    if (thisflightnumber.DepartureDays.ToList() != null)
        //    {
        //        daysflown= thisflightnumber.DepartureDays.ToList();
        //        foreach (Day dayflown in daysflown)
        //        {
        //            foreach(DateTime Day in DecemberDays())
        //            {
        //                if (Day.DayOfWeek.ToString() == dayflown.Name)
        //                {
        //                    Flight flight = new Flight(thisflightnumber.BaseFare);
        //                    flight.DepartDateTime = Day + thisflightnumber.DepartTime;
        //                    flight.FlightNumber = thisflightnumber;
        //                    db.Flights.Add(flight);
        //                    db.SaveChanges();
        //                }
        //            }

        //        }
        //    }


        //    return RedirectToAction("Index", "Flights");
        //}




        // GET: Flights
        public ActionResult Index()
        {
            return View(db.Flights.ToList());
        }

        // GET: Flights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            if (flight.Departed)
            {
                return View("PastFlightManifest", flight);
            }
            return View(flight);


        }

        public ActionResult FlightSearch()
        {
            FlightSearchController fs = new FlightSearchController();
            ViewBag.AllCities = fs.GetAllCities();


            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FlightSearch([Bind(Include = "BeginDepartureTimeRange,EndDepartureTimeRange")] FlightSearchViewModel model, int City1ID, int City2ID)
        {
            //datetime objects have a (yyyy,mm,dd,hh,mm,ss) so to get (yyyy,mm,dd,0,0,0) you subtract time of day
            //then to get the day after, you add 24 hrs
            DateTime enddate = model.EndDepartureTimeRange - model.EndDepartureTimeRange.TimeOfDay + new TimeSpan(24, 0, 0);
            DateTime startdate = model.BeginDepartureTimeRange - model.BeginDepartureTimeRange.TimeOfDay;
            List<Flight> fquery = db.Flights.Where(d => d.DepartDateTime >= startdate
            && d.DepartDateTime <= enddate).ToList();


            fquery = fquery.Where(c => c.FlightNumber.startCity.CityID == City1ID).ToList();

            City endcity = db.Cities.Find(City2ID);

            String endairport = endcity.Airport;
            fquery = fquery.Where(d => d.FlightNumber.endCityAirport == endairport).ToList();
            



            return View("Index", fquery);
        }


        public ActionResult Reserve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            if (flight.Cancelled)
            {
                ViewBag.Error = "ERROR: Sorry this flight was cancelled";
                return View("Index");
            }
            if (flight.Departed)
            {
                ViewBag.Error = "ERROR: Sorry this flight has departed";
                return View("Index");
            }
            int actualId = id.Value;
            ReservationsController cont = new ReservationsController();
            return cont.StartReservation(actualId);
        }


        // GET: Flights/Create
        public ActionResult Create()
        {
            ViewBag.FlightNumbers = GetAllFlightNumbers();
            return View();
        }

        public SelectList GetAllFlightNumbers()
        {
            List<FlightNumber> allFlightNumberList = db.FlightNumbers.ToList();

            SelectList allFlightNumbers = new SelectList(allFlightNumberList, "FlightNumberID", "Number");

            return allFlightNumbers;
        }

        // get all tickets to connect to flights
        public MultiSelectList GetAllTickets(Flight Flights)
        {
            var query = from m in db.Tickets
                        orderby m.TicketID
                        select m;
            List<Ticket> allTickets = query.ToList();

            List<Int32> SelectedTickets = new List<Int32>();


            foreach (Ticket m in Flights.Tickets)
            {
                SelectedTickets.Add(m.TicketID);
            }

            MultiSelectList allTicketsList = new MultiSelectList(allTickets, "TicketID", "Title", SelectedTickets);

            return allTicketsList;
        }


        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Create([Bind(Include = "FlightID,DepartTime")] Flight flight, int FlightNumberID)
        {
            if (ModelState.IsValid)
            {
                FlightNumber flightNumbertarget= db.FlightNumbers.Find(FlightNumberID);
                //flight.FlightNumber = flightNumbertarget;
                flight.DepartDateTime = flight.DepartDateTime + flightNumbertarget.DepartTime;
                flightNumbertarget.Flights.Add(flight);
                db.Flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flight);
        }

        // GET: Flights/Edit/5
        [Authorize(Roles = "Manager, Agent")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }


            //Add drop-down stuff for viewbag

            List<AppUser> AllPilots = db.Users.Where(u => u.EmpType == "Pilot").ToList();
            List<AppUser> AllCoPilots = db.Users.Where(u => u.EmpType == "Co-Pilot").ToList();
            List<AppUser> AllCrew = db.Users.Where(u => u.EmpType == "Cabin Crew").ToList();


            foreach (AppUser employee in db.Users.Where(u => u.EmpType != "Customer"))
            {
                employee.FullName = employee.FirstName+" "+employee.LastName;
            }
            ViewBag.Pilots = new SelectList(AllPilots, "id", "FullName");
            ViewBag.CoPilots = new SelectList(AllCoPilots, "id", "FullName");
            ViewBag.CrewMembers = new SelectList(AllCrew, "id", "FullName");
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager, Agent")]
        public ActionResult Edit([Bind(Include = "FlightID,ActualFare,DepartDateTime,Departed,Cancelled")] Flight flight, string Pilot, string CoPilot, string Crew)
        {
            //Int32 xa = 7;
            //Int32 ya = 0;
            //Int32 za = xa / ya;
            //Flight OriginalFlight = db.Flights.Find(flight.FlightID);
            //flight.SeatsAvailable = OriginalFlight.SeatsAvailable;
            //flight.Departed = OriginalFlight.Departed;
            //flight.DepartDateTime = OriginalFlight.DepartDateTime;
            //flight.ActualFare = OriginalFlight.ActualFare;
            //flight.Cancelled = OriginalFlight.Cancelled;
            //flight.PilotFullName = OriginalFlight.PilotFullName;
            //flight.CoPilotFullName = OriginalFlight.CoPilotFullName;
            //flight.CabinCrewFullName = OriginalFlight.CabinCrewFullName;
            //flight.FlightNumber = OriginalFlight.FlightNumber;
            //flight.Tickets = OriginalFlight.Tickets;
            //flight.Seats = OriginalFlight.Seats;
            //flight.Crew = OriginalFlight.Crew;

            flight = db.Flights.Find(flight.FlightID);

            if (ModelState.IsValid)
            {
          
                db.Entry(flight).State = EntityState.Modified;

                if (flight.Departed)
                {
                    foreach (Ticket ticket in flight.Tickets.ToList())
                    {
                        if (ticket.PayWithMiles == false && ticket.CheckedIn)
                        {
                            ticket.Customer.Miles += flight.FlightNumber.Route.Miles;
                        }
                    }

                }
                //update the crew
                AppUser pilot = db.Users.Find(Pilot);
                AppUser copilot = db.Users.Find(CoPilot);
                AppUser crew = db.Users.Find(Crew);
                List<AppUser> totalcrew = new List<AppUser>();
                totalcrew.Add(pilot);
                totalcrew.Add(copilot);
                totalcrew.Add(crew);
                db.Entry(flight).Entity.Crew = new Crew();
                db.Entry(flight).Entity.Crew.CrewMembers = totalcrew;
                db.Entry(flight).Entity.PilotFullName = pilot.FirstName + " " + pilot.LastName; 
                db.Entry(flight).Entity.CoPilotFullName = copilot.FirstName + " " + copilot.LastName;
                db.Entry(flight).Entity.CabinCrewFullName = crew.FirstName + " " + crew.LastName;
                //Int32 xa = 7;
                //Int32 ya = 0;
                //Int32 za = xa / ya;


                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        // GET: Flights/Delete/5
        [Authorize(Roles = "Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize(Roles = "Manager, Agent")]
        public ActionResult DepartFlight(int flightid)
        {
            Flight flight = db.Flights.Find(flightid);
            foreach (Ticket ticket in flight.Tickets.ToList())
            {
                if (ticket.PayWithMiles == false && ticket.CheckedIn)
                {
                    ticket.Customer.Miles += flight.FlightNumber.Route.Miles;
                }
            }
            return View("Index");
        }
    }
}
