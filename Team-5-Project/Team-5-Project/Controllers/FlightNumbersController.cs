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
    public class FlightNumbersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        //public ActionResult MakeEndAirport()
        //{
        //    List<FlightNumber> allflightnums = db.FlightNumbers.ToList();
        //    foreach (FlightNumber thisflightnum in allflightnums)
        //    {
                
        //        Route thisroute = thisflightnum.Route;
        //        foreach (City city in thisroute.Cities)
        //        {
        //            if (city.CityID != thisflightnum.startCity.CityID)
        //            {
        //                thisflightnum.endCityAirport = city.Airport;
        //                db.FlightNumbers.Attach(thisflightnum);
        //                db.Entry(thisflightnum).Property(x => x.endCityAirport).IsModified = true;
        //                db.SaveChanges();
        //            }
        //        }
                
        //    }
        //    return RedirectToAction("Index");
        //}
       

        // GET: FlightNumbers
        public ActionResult Index()
        {
            return View(db.FlightNumbers.ToList());
        }

        // GET: FlightNumbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightNumber flightNumber = db.FlightNumbers.Find(id);
            if (flightNumber == null)
            {
                return HttpNotFound();
            }
            List<Day> DaysChosen = flightNumber.DepartureDays;
            String DaysChosenTogether = "";
            foreach (Day day in DaysChosen)
            {
                DaysChosenTogether += day.Name + " ";
            }
            ViewBag.DepartureDayNames = DaysChosenTogether;
            return View(flightNumber);
        }

        public MultiSelectList GetAllDays()
        {
            List<Day> allDays = db.Days.OrderBy(c=>c.DayID).ToList();


            List<Int32> SelectedDays = new List<Int32>();

            MultiSelectList DaysSelectListMulti = new MultiSelectList(allDays,"DayID","Name",SelectedDays);
            return DaysSelectListMulti;

        }
        // GET: FlightNumbers/Create
        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            //List<DayOfWeek> alldays = GetAllDays();
            //MultiSelectList SelectedDays = new MultiSelectList(alldays);

            ViewBag.AllDays = GetAllDays();

            ViewBag.AllAirports = GetALlAirports();
            return View();
        }

        public SelectList GetALlAirports()
        {
            List<City> allCities = db.Cities.OrderBy(c => c.Airport).ToList();
            SelectList CitySelected = new SelectList(allCities, "CityID", "Airport");
            return CitySelected;
        }

        // POST: FlightNumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Create([Bind(Include = "FlightNumberID,Number,DepartTime,BaseFare")] FlightNumber flightNumber, int[] DaysChosenList, int StartCityID, int EndCityID)
        {
            if (ModelState.IsValid)
            {
                if (db.FlightNumbers.FirstOrDefault(c => c.Number == flightNumber.Number) != null)
                {
                    ViewBag.AllDays = GetAllDays();

                    ViewBag.AllAirports = GetALlAirports();
                    ViewBag.Error = "Error: Unique Flight Number Needed";
                    return View();
                }
                if (StartCityID == EndCityID)
                {
                    ViewBag.AllDays = GetAllDays();

                    ViewBag.AllAirports = GetALlAirports();
                    ViewBag.Error = "Error the two cities must be different";
                    return View();
                }
                flightNumber.DepartureDays = new List<Day>();
                Route flightRoute = new Route();
                if (DaysChosenList != null)
                {


                    foreach (int DaySelected in DaysChosenList)
                    {

                        flightNumber.DepartureDays.Add(db.Days.Find(DaySelected));
                    }
                }
                if (DaysChosenList == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                City startCity = db.Cities.Find(StartCityID);
                City endCity = db.Cities.Find(EndCityID);
                List<Route> allRoutes = db.Routes.ToList();
                foreach (Route thisroute in allRoutes)
                {
                    List<City> thisroutescities = thisroute.Cities.ToList();
                    if (thisroutescities.Contains(startCity) && thisroutescities.Contains(endCity))
                    {
                        flightRoute = thisroute;
                    }
                }
                    //Route flightRoute = db.Routes.Where(c => c.Cities.Contains(startCity) && c.Cities.Contains(endCity)).ToList().First();
                flightNumber.startCity = (db.Cities.Find(StartCityID));
                flightNumber.Route = flightRoute;
                flightNumber.endCityAirport = endCity.Airport;
                flightNumber.BeenDisabled = false;

                db.FlightNumbers.Add(flightNumber);
                db.SaveChanges();
                return RedirectToAction("SeedNewFlightNumber", "Flights");

                
            }
            ViewBag.DaysChosenList = GetAllDays(); 

            ViewBag.AllAirports = GetALlAirports();
            return View(flightNumber);
        }

        public MultiSelectList GetAllDays(FlightNumber flightnumber)
        {
            List<Day> allDays = db.Days.OrderBy(c => c.DayID).ToList();


            List<Int32> SelectedDays = new List<Int32>();
            foreach(Day day in flightnumber.DepartureDays)
            {
                SelectedDays.Add(day.DayID);
            }

            MultiSelectList DaysSelectListMulti = new MultiSelectList(allDays, "DayID", "Name", SelectedDays);
            return DaysSelectListMulti;
        }


        public SelectList GetALlAirports(FlightNumber flightnumber, int index)
        {
            List<City> allCities = db.Cities.OrderBy(c => c.Airport).ToList();
            SelectList CitySelected;
            if (index == 0)
            {
                CitySelected = new SelectList(allCities, "CityID", "Airport", flightnumber.startCity.CityID);
            }
            else
            {
                CitySelected = new SelectList(allCities, "CityID", "Airport", flightnumber.Route.Cities.Where(c=>c!= flightnumber.startCity));
            }
        
            
            return CitySelected;
        }


        // GET: FlightNumbers/Edit/5
        [Authorize(Roles = "Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightNumber flightNumber = db.FlightNumbers.Find(id);
            if (flightNumber == null)
            {
                return HttpNotFound();
            }
            ViewBag.StartAirport = GetALlAirports(flightNumber, 0);
            ViewBag.EndAirport = GetALlAirports(flightNumber, 1);
            ViewBag.AllDays = GetAllDays(flightNumber);
            return View(flightNumber);
        }

        // POST: FlightNumbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Edit([Bind(Include = "FlightNumberID,Number,DepartTime,BaseFare,BeenDisabled")] FlightNumber flightNumber, int[] DaysChosenList)
        {
            
            if (ModelState.IsValid)
            {
                checkoutviewmodel vm = new checkoutviewmodel();
                FlightNumber flightNumbertochange = db.FlightNumbers.Find(flightNumber.FlightNumberID);
                List<Day> newdeparturedaylist = new List<Day>();
                foreach (int Dayofweek in DaysChosenList)
                {
                    newdeparturedaylist.Add(db.Days.Find(Dayofweek));
                }
                if (flightNumbertochange.DepartureDays.ToList() != newdeparturedaylist)
                {
                    flightNumbertochange.DepartureDays = newdeparturedaylist;
                }

                if (flightNumbertochange.DepartTime!= flightNumber.DepartTime)
                {
                    flightNumbertochange.DepartTime = flightNumber.DepartTime;
                }

                if (flightNumbertochange.BaseFare != flightNumber.BaseFare)
                {
                    flightNumbertochange.BaseFare = flightNumber.BaseFare;
                }
                flightNumbertochange.BeenDisabled = flightNumber.BeenDisabled;
                Boolean safe = false;
                foreach (Flight flight in db.Flights.Where(c => c.FlightNumber.Number == flightNumbertochange.Number).Where(c=>c.DepartDateTime>DateTime.Now).ToList())
                {
                    foreach (Day day in flightNumbertochange.DepartureDays)
                    {
                        if (flight.DepartDateTime.Day.ToString() == day.Name)
                        {
                            safe = true;
                        }
                            
                    }
                    DateTime iterate = new DateTime(2017, 12, 8);
                    while (iterate < new DateTime(2017, 12, 26)) 
                    {
                        foreach (Day day in flightNumbertochange.DepartureDays)
                        {
                            if (day.Name == iterate.ToString())
                            {
                                if (db.Flights.Where(c => c.FlightNumber.FlightNumberID == flightNumbertochange.FlightNumberID && c.DepartDateTime.Date == iterate.Date).ToList().Count == 0)
                                {
                                    Flight newflight = new Flight(flightNumbertochange.BaseFare, db);
                                    newflight.Cancelled = false;
                                    newflight.DepartDateTime = iterate + flightNumbertochange.DepartTime;
                                    newflight.Departed = false;
                                    newflight.FlightNumber = flightNumbertochange;
                                    db.Flights.Add(newflight);
                                    db.SaveChanges();
                                }
                            }

                        }
                        iterate += new TimeSpan(24, 0, 0);
                    }

                    if (safe)
                    {
                        //flight time might change
                        flight.DepartDateTime += (flightNumbertochange.DepartTime - flight.DepartDateTime.TimeOfDay);
                    }
                    else
                    {
                        flight.Cancelled = true;
                        Int32 maxID = db.Reservations.Max(x => x.ReservationID);
                        Reservation newestReservation = db.Reservations.Find(maxID);
                        List<Ticket> ReservationWithNewTickets = db.Tickets.Where(x => x.Reservation.ReservationID == newestReservation.ReservationID).ToList();
                        foreach (Ticket ThisTicket in ReservationWithNewTickets)
                        {
                            vm.Email = ThisTicket.Customer.Email;
                            vm.FirstName = ThisTicket.Customer.FirstName;
                            vm.LastName = ThisTicket.Customer.LastName;
                            vm.Flightnumber = ThisTicket.Flight.FlightNumber.Number;
                            vm.DepartDateTime = ThisTicket.Flight.DepartDateTime;
                        }
                        MailModelsController c = new MailModelsController();
                        ActionResult newresult = c.FlightCancelled(vm);
                    }
                    
                    if (flightNumbertochange.BeenDisabled == true)
                    {
                        flight.Cancelled = true;
                        //TODO: DELETE THE FLIGHT BUT FIRST FIND OUT WHO ALL IS ON THE FLIGHT
                    }
                    flight.ActualFare = flightNumbertochange.BaseFare;
                    //TODO: EMAIL THE PEOPLE OF THE CHANGES MY DUDES
                }
                
                db.Entry(flightNumbertochange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flightNumber);
        }

        // GET: FlightNumbers/Delete/5
        [Authorize(Roles = "Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightNumber flightNumber = db.FlightNumbers.Find(id);
            if (flightNumber == null)
            {
                return HttpNotFound();
            }
            return View(flightNumber);
        }

        // POST: FlightNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult DeleteConfirmed(int id)
        {
            FlightNumber flightNumber = db.FlightNumbers.Find(id);
            db.FlightNumbers.Remove(flightNumber);
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

        
    }
}
