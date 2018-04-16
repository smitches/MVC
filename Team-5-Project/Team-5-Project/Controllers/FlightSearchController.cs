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
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Team_5_Project.Controllers
{
    //public enum 
    //    { Before12Pm, After12Pm };
    public class FlightSearchController : Controller
    {
        private AppDbContext db = new AppDbContext();
        private ApplicationSignInManager _signInManager;
        private AppUserManager _userManager;

        // GET: FlightSearch
        public ActionResult Index()
        {
            return View();
        }

        //detailed search
        public ActionResult FlightSearch()
        {
            ViewBag.AllCities = GetAllCities();


            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FlightSearch([Bind(Include = "BeginDepartureTimeRange,EndDepartureTimeRange,SeatsNeeded,Nonstop,RoundTrip")] FlightSearchViewModel model, int City1ID, int City2ID)
        {
            //datetime objects have a (yyyy,mm,dd,hh,mm,ss) so to get (yyyy,mm,dd,0,0,0) you subtract time of day
            //then to get the day after, you add 24 hrs
            if (model.BeginDepartureTimeRange < DateTime.Now.Date)
            {
                ViewBag.Error = "Begin time must be in future";
                ViewBag.AllCities = GetAllCities();
                return View();
            }
            if (model.EndDepartureTimeRange < DateTime.Now.Date)
            {
                ViewBag.AllCities = GetAllCities();
                ViewBag.Error = "End time must be in future";
                return View();
            }
            if (model.EndDepartureTimeRange < model.BeginDepartureTimeRange)
            {
                ViewBag.AllCities = GetAllCities();
                ViewBag.Error = "End time must be after begin time";
                return View();
            }
            if (City1ID==City2ID)
            {
                ViewBag.AllCities = GetAllCities();
                ViewBag.Error = "You must pick different cities";
                return View();
            }

            DateTime enddate = model.EndDepartureTimeRange - model.EndDepartureTimeRange.TimeOfDay + new TimeSpan(24, 0, 0);
            DateTime startdate = model.BeginDepartureTimeRange - model.BeginDepartureTimeRange.TimeOfDay;
            List<Flight> fquery = db.Flights.Where(d => d.DepartDateTime >= startdate
            && d.DepartDateTime <= enddate)
                .Where(d => d.Departed == false && d.Cancelled == false)
                .Where(c => c.SeatsAvailable >= model.SeatsNeeded).ToList();
         
            fquery = fquery.Where(c => c.FlightNumber.startCity.CityID == City1ID).ToList();

            City endcity = db.Cities.Find(City2ID);

            String endairport = endcity.Airport;
            fquery = fquery.Where(d => d.FlightNumber.endCityAirport == endairport).ToList();
            Reservation newReservation = new Reservation(db);
            newReservation.RoundTrip = model.RoundTrip;
            db.Reservations.Add(newReservation);
            db.SaveChanges();
            return View("SelectedFlights", fquery);
        }
        //
        // HELPER METHODS
        
        // MultiSelect version of get all cities
        public MultiSelectList GetAllCitiesMulti()
        {
            List<City> CityList = db.Cities.ToList();
            //City SelectNone = new Models.City() { CityID = 0, CityName = "All Cities" };
            //CityList.Add(SelectNone);

            MultiSelectList AllCities = new MultiSelectList(CityList.OrderBy(f => f.CityID), "CityID", "CityName");
            return AllCities;
        }

        //Helper method to get all routes
        public MultiSelectList GetAllRoutes()
        {
            List<Route> RouteList = db.Routes.ToList();
            //Route SelectNone = new Models.Route() { RouteID = 0, RouteName = "All Routes" };
            //RouteList.Add(SelectNone);

            MultiSelectList AllRoutes = new MultiSelectList(RouteList.OrderBy(f => f.RouteName), "RouteID", "RouteName");
            return AllRoutes;
        }

        //Helper method that selects all cities
        public SelectList GetAllCities()
        {
            List<City> CityList = db.Cities.ToList();
            SelectList AllCities = new SelectList(CityList.OrderBy(f => f.CityID), "CityID", "CityName");
            return AllCities;
        }

        //Helper method that selects all SeatTypes
        public MultiSelectList GetAllSeatTypes()
        {
            List<SeatType> SeatTypeList = db.SeatType.ToList();
            //SeatType SelectNone = new Models.SeatType() {SeatTypeID = 0, Name = "All Seats" };
            //SeatTypeList.Add(SelectNone);
            SelectList AllSeatTypes = new SelectList(SeatTypeList.OrderBy(f => f.SeatTypeID), "SeatTypeID", "Name");
            return AllSeatTypes;
        }

        //Helper method that returns all depart days
        public List<DateTime> GetAllDepartDays()
        {
            List<Flight> FlightList = db.Flights.Where(c => c.DepartDateTime > DateTime.Now).ToList();

            List<DateTime> AllDays = new List<DateTime>();
            foreach (Flight flight in FlightList)
            {
                if ((AllDays.Contains(flight.DepartDateTime.Date)) == false)
                {
                    AllDays.Add(flight.DepartDateTime);
                }
            }
            return AllDays;

        }

        //[Authorize]
        public ActionResult Reserve(int id)
        {

            List<Seat> availableseats = db.Seats.Where(d => d.Flight.FlightID == id&&d.IsAvailable).ToList();
          //  availableseats = availableseats.Where(d=>d.IsAvailable == true).ToList();
            List<Int32> chosenseatids = new List<Int32>();


            MultiSelectList SeatsChosen = new MultiSelectList(availableseats, "SeatID", "SeatName", chosenseatids);
            ViewBag.SeatsChosen = SeatsChosen;


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reserve(int[] SeatIDs)
        {

            Int32 maxresid = db.Reservations.Max(c => c.ReservationID);
            Reservation newReservation = db.Reservations.Find(maxresid);

            foreach (int Seat in SeatIDs)
            {
                Seat thisSeat = db.Seats.Find(Seat);
                Flight assignedFlight = thisSeat.Flight;
                Ticket newTicket = new Ticket(thisSeat,newReservation);
                if (thisSeat.SeatName == "1A" || thisSeat.SeatName == "1B" || thisSeat.SeatName == "2A" || thisSeat.SeatName == "2B")
                {
                    thisSeat.SeatType = db.SeatType.FirstOrDefault(s => s.Name == "FirstClass");
                }
                newTicket.Flight=(assignedFlight);
                thisSeat.IsAvailable = false;
                assignedFlight.SeatsAvailable -= 1;
                
                db.Tickets.Add(newTicket);


                //db.Seats.Attach(thisSeat);
                //db.Entry(thisSeat).Property(x => x.IsAvailable).IsModified = true;

                //db.Flights.Attach(assignedFlight);
                //db.Entry(assignedFlight).Property(x => x.SeatsAvailable).IsModified = true;

                db.SaveChanges();
                
            }
            
            return RedirectToAction("GetCustomer","FlightSearch");
        }

        [Authorize]
        public ActionResult GetCustomer()
        {
            Int32 maxID = db.Reservations.Max(x => x.ReservationID);
            Reservation newestReservation = db.Reservations.Find(maxID);
            List<Seat> seatsWithNewTicket=db.Seats.Where(x => x.IsAvailable == false && x.Ticket.Reservation.ReservationID == newestReservation.ReservationID&&x.Ticket.Customer==null).ToList();
            if (seatsWithNewTicket.Count == 0)
            {
                if (newestReservation.RoundTrip)
                {
                    return RedirectToAction("ReturnFlightSearch", "RoundTripFS");
                }
                checkoutviewmodel vm = new checkoutviewmodel();
                return RedirectToAction("DeterminePaymentType", "Checkout");
            }
            return View(seatsWithNewTicket);
        }

        public ActionResult SearchCustomer(int? seatid)
        {
            CustomerSearchViewModel vm = new CustomerSearchViewModel();
            vm.Customers = db.Users.Where(c => c.EmpType == "Customer" || c.EmpType == null).ToList();
            vm.Seat = db.Seats.Find(seatid);
            vm.SeatID = seatid;
            ViewBag.SeatInfo = "Seat " + vm.Seat.SeatName + " on Flight " + vm.Seat.Flight.FlightNumber.Number.ToString() + " on " + vm.Seat.Flight.DepartDateTime.Date.ToString();
            vm.Customers = vm.Customers.OrderBy(d => d.AdvantageNumber).ThenBy(d => d.LastName).ThenBy(d => d.FirstName).ToList();
            db.csvms.Add(vm);
            db.SaveChanges();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchCustomer(CustomerSearchViewModel csvm)
        {
            int maxid = db.csvms.Max(x => x.CustomerSearchViewModelID);
            CustomerSearchViewModel vm = db.csvms.Find(maxid);
            vm.FirstName = csvm.FirstName;
            vm.LastName = csvm.LastName;
            vm.AdvantageNumber = csvm.AdvantageNumber;
            db.SaveChanges();
            
            vm.Customers = db.Users.Where(c => c.EmpType == "Customer" || c.EmpType == null).ToList();
            if (vm.FirstName != null)
            {
                vm.Customers = vm.Customers.Where(c => c.FirstName.Contains(vm.FirstName)).ToList();
                db.SaveChanges();
            }
            if (vm.LastName != null)
            {
                vm.Customers = vm.Customers.Where(c => c.LastName.Contains(vm.LastName)).ToList();
                db.SaveChanges();
            }
            if (vm.AdvantageNumber != null)
            {
                vm.Customers = vm.Customers.Where(c => c.AdvantageNumber == vm.AdvantageNumber).ToList();
                db.SaveChanges();
            }
            ViewBag.SeatInfo = "Seat " + vm.Seat.SeatName + " on Flight " + vm.Seat.Flight.FlightNumber.Number.ToString() + " on " + vm.Seat.Flight.DepartDateTime.Date.ToString();
            vm.Customers = vm.Customers.OrderBy(d => d.AdvantageNumber).ThenBy(d => d.LastName).ThenBy(d => d.FirstName).ToList();

            db.SaveChanges();
            //Int32 a = 12;
            //Int32 b = 0;
            //Int32 r = a / b;
            return View(vm);
        }

     



        public ActionResult AttachChosen(int seatid, string id)
        {
            AppUser customer = db.Users.Find(id);
            Seat seat = db.Seats.Find(seatid);
            
            seat.Ticket.Customer = customer;
            db.SaveChanges();
            return RedirectToAction("GetCustomer");
        }

        public ActionResult CreateCustomer(int? id)
        {
            CreateCustomerViewModel ccvm = new CreateCustomerViewModel();
            ccvm.Seat = db.Seats.Find(id);
            //ViewBag.SeatInfo = "Seat " + vm.Seat.SeatName + " on Flight " + vm.Seat.Flight.FlightNumber.Number.ToString() + " on " + vm.Seat.Flight.DepartDateTime.Date.ToString();
            //vm.Customers = vm.Customers.OrderBy(d => d.AdvantageNumber).ThenBy(d => d.LastName).ThenBy(d => d.FirstName).ToList();
            return View(ccvm);
        }

        // POST: /Accounts/Register for customer
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCustomer(CreateCustomerViewModel model, int? seatid)
        {
            if (ModelState.IsValid)
            {
                Int32 NextAdvantageNumber = GetNextAdvantageNumber();
                //Add fields to user here so they will be saved to do the database
                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MI = model.MI,
                    DOB = model.DOB,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    Miles = model.Miles,
                    PhoneNumber = model.PhoneNumber,
                    AdvantageNumber = NextAdvantageNumber + 1,
                    EmpType = "Customer",
                };
                var result = await UserManager.CreateAsync(user, model.Password);

               // Once you get roles working, you may want to add users to roles upon creation
                await UserManager.AddToRoleAsync(user.Id, "Customer");

                db.SaveChanges();

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    //        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    //        // Send an email with this link
                    //        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    //        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    //        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    return RedirectToAction("GetCustomer", "FlightSearch");
                }
                //AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
 

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public AppUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public Int32 GetNextAdvantageNumber()
        {
            //find the highest advantage number and add one

            Int32 MaxAdvantageNumber = db.Users.Where(c => c.EmpType == "Customer").Max(x => x.AdvantageNumber);
            Int32 NextAdvantageNumber = MaxAdvantageNumber++;


            return NextAdvantageNumber;
        }

    }
}

