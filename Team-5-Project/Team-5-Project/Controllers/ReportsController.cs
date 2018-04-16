using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team_5_Project.Models;
using Team_5_Project.DAL;
using System.Data.Entity;

//Different types of reports that managers can access. 


namespace Team_5_Project.Controllers
{

    //only managers can create reports
    //[Authorize(Roles = "Manager")]
    public class ReportsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        ////Load the reports index page with useful stuff
        //public ActionResult Index()
        //{
        //    ReportsViewModel vm = new ReportsViewModel();
        //    return View(vm);
        //}

        //// POST: Reports
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(ReportType SelectedReportType)
        //{
        //   if(SelectedReportType == ReportType.Seats)
        //    {
        //        return RedirectToAction("SeatReport");
        //    }

        //   if(SelectedReportType == ReportType.Revenue)
        //    {
        //        return RedirectToAction("RevenueReport");
        //    }

        //    else
        //    {
        //        return RedirectToAction("BothReport");
        //    }
        //}

        ////Get for Seats Report
        //[HttpGet]
        //public ActionResult SeatReport()
        //{
        //    //Initialize a FSController to get its helper methods
        //    FlightSearchController FSController = new FlightSearchController();
        //    UpdateRouteName();
        //    //Pass all cities thru the viewbag to the dropdown list
        //    ViewBag.AllCities = FSController.GetAllCitiesMulti();
        //    //Pass all routes thru the viewbag to the dropdown list
        //    ViewBag.AllRoutes = FSController.GetAllRoutes();
        //    //Pass all SeatTypes thru the viewbag to the DDL
        //    ViewBag.AllSeatTypes = FSController.GetAllSeatTypes();
        //    return View();
        //}


        ////Seat Report
        //[HttpPost]
        //public ActionResult SeatReport([Bind(Include = "DateRangeStart, DateRangeEnd, DepartureCities, Route, SeatType")] ReportsViewModel model, int[] SelectedCityIDs, int? SelectedRouteID, int? SelectedSeatTypeID)
        //{
        //    //Update model to match selected info

        //    //update model.route

        //    model.Route = db.Routes.Find(SelectedRouteID);

        //    //update model.departure cities
        //    if (SelectedCityIDs != null)
        //    {
        //        foreach (int id in SelectedCityIDs)
        //        {
        //            List<City> CityList = db.Cities.Where(m => m.CityID == id).ToList();
        //            foreach (City city in CityList)
        //            {
        //                model.DepartureCities.Add(city);
        //            }
        //        }
        //    }


        //    //update model.seat type
        //    if (SelectedSeatTypeID != null)
        //    {
        //        model.SeatType = db.SeatType.FirstOrDefault(t => t.SeatTypeID == SelectedSeatTypeID);
        //    }

        //    //Make a new list of all the seats
        //    List<Seat> allSeats = db.Seats.ToList();

        //    var AllSeats = allSeats.AsQueryable();
        //    //FILTER ALLSEATS DOWN

        //    //Filter by start date
        //    if (model.DateRangeStart != null)
        //    {
        //        AllSeats = AllSeats.Where(s => DbFunctions.TruncateTime(s.Flight.DepartDateTime) >= DbFunctions.TruncateTime(model.DateRangeStart));
        //    }

        //    //Filter by end date
        //    if (model.DateRangeEnd != null)
        //    {
        //        AllSeats = AllSeats.Where(s => DbFunctions.TruncateTime(s.Flight.DepartDateTime) >= DbFunctions.TruncateTime(model.DateRangeEnd));
        //    }

        //    //Filter by DepartureCityID
        //    if (model.DepartureCities.Any(c => c.CityID == 0)==false)
        //    {
        //        //TempAllSeats will replace allSeats
        //        //TempAllSeats will contain all members of allSeats that are contained w/in departurecities
        //        List<Seat> TempAllSeats = new List<Seat>();
        //        foreach (Seat seat in AllSeats)
        //        {
        //            if (model.DepartureCities.Contains(seat.Flight.FlightNumber.startCity))
        //            {
        //                TempAllSeats.Add(seat);
        //            }
        //        }
        //        AllSeats = TempAllSeats.AsQueryable();
        //    }

        //    //Filter by Route
        //    if (SelectedRouteID!=null)
        //    {
        //        AllSeats = AllSeats.Where(s => s.Flight.FlightNumber.Route.RouteID == SelectedRouteID);
        //        model.Route = db.Routes.Find(SelectedRouteID);
        //    }

        //    //Filter by SeatType
        //    if (SelectedSeatTypeID!=null)
        //    {
        //        AllSeats = AllSeats.Where(s => s.SeatType == model.SeatType);
        //    }

        //    //Convert filtered IQueryable into a list
        //    List<Seat> AllSeatsList = AllSeats.ToList();
        //    model.Seats = AllSeatsList;


        //    int x = 32;
        //    int y = 0;
        //    int z = x / y;
        //    return View("SeatReportResult", model);
        //}

        ////Get for Revenue Report
        //[HttpGet]
        //public ActionResult RevenueReport()
        //{
        //    //Initialize a FSController to get its helper methods
        //    FlightSearchController FSController = new FlightSearchController();
        //    UpdateRouteName();
        //    //Pass all cities thru the viewbag to the dropdown list
        //    ViewBag.AllCities = FSController.GetAllCitiesMulti();
        //    //Pass all routes thru the viewbag to the dropdown list
        //    ViewBag.AllRoutes = FSController.GetAllRoutes();
        //    //Pass all SeatTypes thru the viewbag to the DDL
        //    ViewBag.AllSeatTypes = FSController.GetAllSeatTypes();
        //    return View();
        //}

        ////REVENUE REPORT POST
        //[HttpPost]
        //public ActionResult RevenueReport([Bind(Include = "DateRangeStart, DateRangeEnd, DepartureCities, Route, SeatType, Revenue")] ReportsViewModel model, int[] SelectedCityIDs, int SelectedRouteID, int SelectedSeatTypeID)
        //{
        //    //Update model to match selected info

        //    //update model.route
        //    if (model.Route == null)
        //    {
        //        model.Route = new Route();
        //    }
        //    model.Route.RouteID = SelectedRouteID;

        //    //update model.departure cities
        //    foreach (int id in SelectedCityIDs)
        //    {
        //        List<City> CityList = db.Cities.Where(m => m.CityID == id).ToList();
        //        foreach (City city in CityList)
        //        {
        //            model.DepartureCities.Add(city);
        //        }
        //    }

        //    //update model.seat type

        //    model.SeatType = db.SeatType.FirstOrDefault(t => t.SeatTypeID == SelectedSeatTypeID);

        //    //Make a new list of all the seats
        //    var AllSeats = from seat in db.Seats
        //                   select seat;

        //    //FILTER ALLSEATS DOWN

        //    //Filter by start date
        //    if (model.DateRangeStart != null)
        //    {
        //        AllSeats = AllSeats.Where(s => DbFunctions.TruncateTime(s.Flight.DepartDateTime) >= DbFunctions.TruncateTime(model.DateRangeStart));
        //    }

        //    //Filter by end date
        //    if (model.DateRangeEnd != null)
        //    {
        //        AllSeats = AllSeats.Where(s => DbFunctions.TruncateTime(s.Flight.DepartDateTime) >= DbFunctions.TruncateTime(model.DateRangeEnd));
        //    }

        //    //Filter by DepartureCityID
        //    if (model.DepartureCities.Any(c => c.CityID == 0) == false)
        //    {
        //        //TempAllSeats will replace allSeats
        //        //TempAllSeats will contain all members of allSeats that are contained w/in departurecities
        //        List<Seat> TempAllSeats = new List<Seat>();
        //        foreach (Seat seat in AllSeats)
        //        {
        //            if (model.DepartureCities.Contains(seat.Flight.FlightNumber.startCity))
        //            {
        //                TempAllSeats.Add(seat);
        //            }
        //        }
        //        AllSeats = TempAllSeats.AsQueryable();
        //    }

        //    //Filter by Route
        //    if (SelectedRouteID != 0)
        //    {
        //        AllSeats = AllSeats.Where(s => s.Flight.FlightNumber.Route.RouteID == SelectedRouteID);
        //        model.Route.RouteID = SelectedRouteID;
        //    }

        //    //Filter by SeatType
        //    if (SelectedSeatTypeID != 0)
        //    {
        //        AllSeats = AllSeats.Where(s => s.SeatType == model.SeatType);
        //    }

        //    //Convert filtered IQueryable into a list
        //    List<Seat> AllSeatsList = AllSeats.ToList();
        //    model.Seats = AllSeatsList;

        //    //Calculate Revenue on Seats
        //    foreach (Seat seat in AllSeatsList)
        //    {
        //        if (seat.Ticket.Flight.Departed == true)
        //        {
        //            model.Revenue += seat.Ticket.DiscountedFare;
        //        }
        //    }

        //    return View("RevenueReportResult", model);
        //}

        ////Get for Both Report
        //[HttpGet]
        //public ActionResult BothReport()
        //{
        //    //Initialize a FSController to get its helper methods
        //    FlightSearchController FSController = new FlightSearchController();
        //    UpdateRouteName();
        //    //Pass all cities thru the viewbag to the dropdown list
        //    ViewBag.AllCities = FSController.GetAllCitiesMulti();
        //    //Pass all routes thru the viewbag to the dropdown list
        //    ViewBag.AllRoutes = FSController.GetAllRoutes();
        //    //Pass all SeatTypes thru the viewbag to the DDL
        //    ViewBag.AllSeatTypes = FSController.GetAllSeatTypes();
        //    return View();
        //}

        ////BOTH REPORT POST
        //[HttpPost]
        //public ActionResult BothReport([Bind(Include = "DateRangeStart, DateRangeEnd, DepartureCities, Route, SeatType, Revenue")] ReportsViewModel model, int[] SelectedCityIDs, int SelectedRouteID, int SelectedSeatTypeID)
        //{
        //    //Update model to match selected info

        //    //update model.route
        //    if (model.Route == null)
        //    {
        //        model.Route = new Route();
        //    }
        //    model.Route.RouteID = SelectedRouteID;

        //    //update model.departure cities
        //    foreach (int id in SelectedCityIDs)
        //    {
        //        List<City> CityList = db.Cities.Where(m => m.CityID == id).ToList();
        //        foreach (City city in CityList)
        //        {
        //            model.DepartureCities.Add(city);
        //        }
        //    }

        //    //update model.seat type

        //    model.SeatType = db.SeatType.FirstOrDefault(t => t.SeatTypeID == SelectedSeatTypeID);

        //    //Make a new list of all the seats
        //    var AllSeats = from seat in db.Seats
        //                   select seat;

        //    //FILTER ALLSEATS DOWN

        //    //Filter by start date
        //    if (model.DateRangeStart != null)
        //    {
        //        AllSeats = AllSeats.Where(s => DbFunctions.TruncateTime(s.Flight.DepartDateTime) >= DbFunctions.TruncateTime(model.DateRangeStart));
        //    }

        //    //Filter by end date
        //    if (model.DateRangeEnd != null)
        //    {
        //        AllSeats = AllSeats.Where(s => DbFunctions.TruncateTime(s.Flight.DepartDateTime) >= DbFunctions.TruncateTime(model.DateRangeEnd));
        //    }

        //    //Filter by DepartureCityID
        //    if (model.DepartureCities.Any(c => c.CityID == 0) == false)
        //    {
        //        //TempAllSeats will replace allSeats
        //        //TempAllSeats will contain all members of allSeats that are contained w/in departurecities
        //        List<Seat> TempAllSeats = new List<Seat>();
        //        foreach (Seat seat in AllSeats)
        //        {
        //            if (model.DepartureCities.Contains(seat.Flight.FlightNumber.startCity))
        //            {
        //                TempAllSeats.Add(seat);
        //            }
        //        }
        //        AllSeats = TempAllSeats.AsQueryable();
        //    }

        //    //Filter by Route
        //    if (SelectedRouteID != 0)
        //    {
        //        AllSeats = AllSeats.Where(s => s.Flight.FlightNumber.Route.RouteID == SelectedRouteID);
        //        model.Route.RouteID = SelectedRouteID;
        //    }

        //    //Filter by SeatType
        //    if (SelectedSeatTypeID != 0)
        //    {
        //        AllSeats = AllSeats.Where(s => s.SeatType == model.SeatType);
        //    }

        //    //Convert filtered IQueryable into a list
        //    List<Seat> AllSeatsList = AllSeats.ToList();
        //    model.Seats = AllSeatsList;

        //    //Calculate Revenue on Seats
        //    foreach (Seat seat in AllSeatsList)
        //    {
        //        if (seat.Ticket.Flight.Departed == true)
        //        {
        //            model.Revenue += seat.Ticket.DiscountedFare;
        //        }
        //    }

        //    return View("BothReportResult", model);
        //}

        ////Both Report
        //public ActionResult BothReport([Bind(Include = "DateRangeStart, DateRangeEnd, DepartureCities, RouteID, SeatType")] ReportsViewModel model)
        //{
        //    return View();
        //}

        ////Method that updates route names
        //public void UpdateRouteName()
        //{
        //    foreach (Route route in db.Routes)
        //    {
        //        string TempRouteName = route.Cities[0].CityName + "-" + route.Cities[1].CityName;

        //        if (route.RouteName != TempRouteName)
        //        {
        //            route.RouteName = TempRouteName;
        //        }
        //    }
        //    db.SaveChanges();
        //}
































        //BRIANS WORK BEGINS
        public ActionResult Index()
        {
            List<ReportTypes> reportTypesList = db.ReportType.ToList();
            
            ViewBag.ReportType = new SelectList(reportTypesList, "ReportTypesID", "Type");



            return View();
        }

        [HttpPost]
        public ActionResult Index(int ReportType)
        {
            if (ReportType == 1)
            {
                return RedirectToAction("GetRevenueReport");
            }
            if (ReportType == 2)
            {
                return RedirectToAction("GetSeatReport");
            }
            if (ReportType == 3)
            {
                return RedirectToAction("GetBothReport");
            }
            return View("Index");
        }


        public ActionResult GetRevenueReport()
        {
            ReportVM vm = new ReportVM();

            List<SeatType> Seattypes = db.SeatType.ToList();
            List<Int32> chosenseattypes = new List<int>();

            ViewBag.SeatTypes = new MultiSelectList(Seattypes, "SeatTypeID", "Name", chosenseattypes);

            List<City> AllCities = db.Cities.ToList();
            List<Int32> chosencities = new List<int>();

            ViewBag.Cities = new MultiSelectList(AllCities, "CityID", "CityName", chosencities);


            List<FlightNumber> allFlightNumbers = db.FlightNumbers.ToList();



            foreach (FlightNumber fn in allFlightNumbers)
            {
                TwoAirport thisroute = new TwoAirport();
                thisroute.City2Airport = fn.endCityAirport;
                thisroute.City1Airport = fn.startCity.Airport;
                thisroute.CityCombo = thisroute.City1Airport + " to " + thisroute.City2Airport;
                if (db.twoAirporSets.Where(c => c.City1Airport == thisroute.City1Airport && c.City2Airport == thisroute.City2Airport).ToList().Count == 0)
                {
                    db.twoAirporSets.Add(thisroute);
                    db.SaveChanges();
                }
            }

            List<TwoAirport> allroutes = db.twoAirporSets.ToList();
            List<Int32> selectedRoutes = new List<int>();
            ViewBag.Routes = new MultiSelectList(allroutes, "TwoAirportID", "CityCombo", selectedRoutes);

            return View(vm);
        }

        [HttpPost]
        public ActionResult GetRevenueReport(ReportVM vm, int[] SeatTypes, int[] Cities, int[] Routes)
        {
            List<Ticket> alltickets = db.Tickets.ToList();

            if (SeatTypes != null)
            {
                int thisint = SeatTypes[0];
                SeatType seattypeone = db.SeatType.Where(c => c.SeatTypeID == thisint).ToList().First();
                alltickets = alltickets.Where(c => c.Seat.SeatType.SeatTypeID == seattypeone.SeatTypeID).ToList();
                if (SeatTypes[1] > 0)
                {
                    thisint = SeatTypes[1];
                    List<Ticket> othertickets = db.Tickets.Where(c => c.Seat.SeatType.SeatTypeID == thisint).ToList();
                    foreach (Ticket ticket in othertickets)
                    {

                        alltickets.Add(ticket);
                    }
                }
            }

            if (Cities != null)
            {
                City city1 = db.Cities.Find(Cities[0]);
                alltickets = alltickets.Where(c => c.Flight.FlightNumber.endCityAirport == city1.Airport || c.Flight.FlightNumber.startCity.CityID == Cities[0]).ToList();
                int index = 1;
                while (Cities[index] > 0)
                {
                    int newint = Cities[index];
                    City newCity = db.Cities.Find(Cities[newint]);
                    List<Ticket> moretix = db.Tickets.Where(c => c.Flight.FlightNumber.endCityAirport == newCity.Airport || c.Flight.FlightNumber.startCity.CityID == Cities[index]).ToList();
                    foreach (Ticket ticket in moretix)
                    {
                        alltickets.Add(ticket);
                    }
                    index += 1;
                }
            }

            if (Routes != null)
            {
                TwoAirport route = db.twoAirporSets.Find(Routes[0]);
                alltickets = alltickets.Where(c => c.Flight.FlightNumber.endCityAirport == route.City2Airport || c.Flight.FlightNumber.startCity.Airport == route.City1Airport).ToList();
                int index = 1;
                while (Routes[index] > 0)
                {
                    int lastint = Routes[index];
                    TwoAirport newRoute = db.twoAirporSets.Find(lastint);
                    List<Ticket> moretix = db.Tickets.Where(c => c.Flight.FlightNumber.endCityAirport == route.City2Airport || c.Flight.FlightNumber.startCity.Airport == route.City1Airport).ToList();
                    foreach (Ticket ticket in moretix)
                    {
                        alltickets.Add(ticket);
                    }
                    index += 1;
                }
            }
            RevenueVM rvm = new RevenueVM();
            Decimal Revenue=0;

            alltickets = alltickets.Where(c => c.Flight.DepartDateTime >= vm.BegDate && c.Flight.DepartDateTime <= vm.EndDate).ToList();
            List<Flight> newlist = new List<Flight>();
            rvm.Flights = newlist;
            foreach (Ticket ticket in alltickets)
            {
                rvm.Flights.Add(ticket.Flight);

                if (ticket.Flight.Departed == true)
                {
                    Revenue += ticket.DiscountedFare;
                }
                
            }
            rvm.Revenue = Revenue;
            db.RevenueVms.Add(rvm);
            db.SaveChanges();
            
            return View("ShowRevenueReport",rvm);
        }

        //SEATS REPORTS 
        public ActionResult GetSeatReport()
        {
            ReportVM vm = new ReportVM();

            List<SeatType> Seattypes = db.SeatType.ToList();
            List<Int32> chosenseattypes = new List<int>();

            ViewBag.SeatTypes = new MultiSelectList(Seattypes, "SeatTypeID", "Name", chosenseattypes);

            List<City> AllCities = db.Cities.ToList();
            List<Int32> chosencities = new List<int>();

            ViewBag.Cities = new MultiSelectList(AllCities, "CityID", "CityName", chosencities);


            List<FlightNumber> allFlightNumbers = db.FlightNumbers.ToList();



            foreach (FlightNumber fn in allFlightNumbers)
            {
                TwoAirport thisroute = new TwoAirport();
                thisroute.City2Airport = fn.endCityAirport;
                thisroute.City1Airport = fn.startCity.Airport;
                thisroute.CityCombo = thisroute.City1Airport + " to " + thisroute.City2Airport;
                if (db.twoAirporSets.Where(c => c.City1Airport == thisroute.City1Airport && c.City2Airport == thisroute.City2Airport).ToList().Count == 0)
                {
                    db.twoAirporSets.Add(thisroute);
                    db.SaveChanges();
                }
            }

            List<TwoAirport> allroutes = db.twoAirporSets.ToList();
            List<Int32> selectedRoutes = new List<int>();
            ViewBag.Routes = new MultiSelectList(allroutes, "TwoAirportID", "CityCombo", selectedRoutes);

            return View(vm);
        }

        [HttpPost]
        public ActionResult GetSeatReport(ReportVM vm, int[] SeatTypes, int[] Cities, int[] Routes)
        {
            List<Ticket> alltickets = db.Tickets.ToList();

            if (SeatTypes != null)
            {
                int thisint = SeatTypes[0];
                SeatType seattypeone = db.SeatType.Where(c => c.SeatTypeID == thisint).ToList().First();
                alltickets = alltickets.Where(c => c.Seat.SeatType.SeatTypeID == seattypeone.SeatTypeID).ToList();
                if (SeatTypes[1] > 0)
                {
                    thisint = SeatTypes[1];
                    List<Ticket> othertickets = db.Tickets.Where(c => c.Seat.SeatType.SeatTypeID == thisint).ToList();
                    foreach (Ticket ticket in othertickets)
                    {

                        alltickets.Add(ticket);
                    }
                }
            }

            if (Cities != null)
            {
                City city1 = db.Cities.Find(Cities[0]);
                alltickets = alltickets.Where(c => c.Flight.FlightNumber.endCityAirport == city1.Airport || c.Flight.FlightNumber.startCity.CityID == Cities[0]).ToList();
                int index = 1;
                while (Cities[index] > 0)
                {
                    int newint = Cities[index];
                    City newCity = db.Cities.Find(Cities[newint]);
                    List<Ticket> moretix = db.Tickets.Where(c => c.Flight.FlightNumber.endCityAirport == newCity.Airport || c.Flight.FlightNumber.startCity.CityID == Cities[index]).ToList();
                    foreach (Ticket ticket in moretix)
                    {
                        alltickets.Add(ticket);
                    }
                    index += 1;
                }
            }

            if (Routes != null)
            {
                TwoAirport route = db.twoAirporSets.Find(Routes[0]);
                alltickets = alltickets.Where(c => c.Flight.FlightNumber.endCityAirport == route.City2Airport || c.Flight.FlightNumber.startCity.Airport == route.City1Airport).ToList();
                int index = 1;
                while (Routes[index] > 0)
                {
                    int lastint = Routes[index];
                    TwoAirport newRoute = db.twoAirporSets.Find(lastint);
                    List<Ticket> moretix = db.Tickets.Where(c => c.Flight.FlightNumber.endCityAirport == route.City2Airport || c.Flight.FlightNumber.startCity.Airport == route.City1Airport).ToList();
                    foreach (Ticket ticket in moretix)
                    {
                        alltickets.Add(ticket);
                    }
                    index += 1;
                }
            }
            RevenueVM rvm = new RevenueVM();
            int seatcount = 0;

            alltickets = alltickets.Where(c => c.Flight.DepartDateTime >= vm.BegDate && c.Flight.DepartDateTime <= vm.EndDate).ToList();
            List<Flight> newlist = new List<Flight>();
            rvm.Flights = newlist;
            foreach (Ticket ticket in alltickets)
            {
                seatcount += 1;
                rvm.Flights.Add(ticket.Flight);
            }
            rvm.SeatCount = seatcount;
            db.RevenueVms.Add(rvm);
            db.SaveChanges();

            return View("ShowSeatReport", rvm);
        }

        ///BOTH REPORTS 
        public ActionResult GetBothReport()
        {
            ReportVM vm = new ReportVM();

            List<SeatType> Seattypes = db.SeatType.ToList();
            List<Int32> chosenseattypes = new List<int>();

            ViewBag.SeatTypes = new MultiSelectList(Seattypes, "SeatTypeID", "Name", chosenseattypes);

            List<City> AllCities = db.Cities.ToList();
            List<Int32> chosencities = new List<int>();

            ViewBag.Cities = new MultiSelectList(AllCities, "CityID", "CityName", chosencities);


            List<FlightNumber> allFlightNumbers = db.FlightNumbers.ToList();



            foreach (FlightNumber fn in allFlightNumbers)
            {
                TwoAirport thisroute = new TwoAirport();
                thisroute.City2Airport = fn.endCityAirport;
                thisroute.City1Airport = fn.startCity.Airport;
                thisroute.CityCombo = thisroute.City1Airport + " to " + thisroute.City2Airport;
                if (db.twoAirporSets.Where(c => c.City1Airport == thisroute.City1Airport && c.City2Airport == thisroute.City2Airport).ToList().Count == 0)
                {
                    db.twoAirporSets.Add(thisroute);
                    db.SaveChanges();
                }
            }

            List<TwoAirport> allroutes = db.twoAirporSets.ToList();
            List<Int32> selectedRoutes = new List<int>();
            ViewBag.Routes = new MultiSelectList(allroutes, "TwoAirportID", "CityCombo", selectedRoutes);

            return View(vm);
        }

        [HttpPost]
        public ActionResult GetBothReport(ReportVM vm, int[] SeatTypes, int[] Cities, int[] Routes)
        {
            List<Ticket> alltickets = db.Tickets.ToList();

            if (SeatTypes != null)
            {
                int thisint = SeatTypes[0];
                SeatType seattypeone = db.SeatType.Where(c => c.SeatTypeID == thisint).ToList().First();
                alltickets = alltickets.Where(c => c.Seat.SeatType.SeatTypeID == seattypeone.SeatTypeID).ToList();
                if (SeatTypes[1] > 0)
                {
                    thisint = SeatTypes[1];
                    List<Ticket> othertickets = db.Tickets.Where(c => c.Seat.SeatType.SeatTypeID == thisint).ToList();
                    foreach (Ticket ticket in othertickets)
                    {

                        alltickets.Add(ticket);
                    }
                }
            }

            if (Cities != null)
            {
                City city1 = db.Cities.Find(Cities[0]);
                alltickets = alltickets.Where(c => c.Flight.FlightNumber.endCityAirport == city1.Airport || c.Flight.FlightNumber.startCity.CityID == Cities[0]).ToList();
                int index = 1;
                while (Cities[index] > 0)
                {
                    int newint = Cities[index];
                    City newCity = db.Cities.Find(Cities[newint]);
                    List<Ticket> moretix = db.Tickets.Where(c => c.Flight.FlightNumber.endCityAirport == newCity.Airport || c.Flight.FlightNumber.startCity.CityID == Cities[index]).ToList();
                    foreach (Ticket ticket in moretix)
                    {
                        alltickets.Add(ticket);
                    }
                    index += 1;
                }
            }

            if (Routes != null)
            {
                TwoAirport route = db.twoAirporSets.Find(Routes[0]);
                alltickets = alltickets.Where(c => c.Flight.FlightNumber.endCityAirport == route.City2Airport || c.Flight.FlightNumber.startCity.Airport == route.City1Airport).ToList();
                int index = 1;
                while (Routes[index] > 0)
                {
                    int lastint = Routes[index];
                    TwoAirport newRoute = db.twoAirporSets.Find(lastint);
                    List<Ticket> moretix = db.Tickets.Where(c => c.Flight.FlightNumber.endCityAirport == route.City2Airport || c.Flight.FlightNumber.startCity.Airport == route.City1Airport).ToList();
                    foreach (Ticket ticket in moretix)
                    {
                        alltickets.Add(ticket);
                    }
                    index += 1;
                }
            }
            RevenueVM rvm = new RevenueVM();
            int seatcount = 0;
            Decimal Revenue = 0;

            alltickets = alltickets.Where(c => c.Flight.DepartDateTime >= vm.BegDate && c.Flight.DepartDateTime <= vm.EndDate).ToList();
            List<Flight> newlist = new List<Flight>();
            rvm.Flights = newlist;
            foreach (Ticket ticket in alltickets)
            {
                seatcount += 1;
                rvm.Flights.Add(ticket.Flight);
                if (ticket.Flight.Departed == true)
                {
                    Revenue += ticket.DiscountedFare;
                }
            }
            rvm.SeatCount = seatcount;
            db.RevenueVms.Add(rvm);
            db.SaveChanges();

            return View("ShowBothReport", rvm);
        }
    }
}

          