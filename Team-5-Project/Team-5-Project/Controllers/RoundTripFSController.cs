using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Team_5_Project.DAL;
using Team_5_Project.Models;

namespace Team_5_Project.Controllers
{
    public class RoundTripFSController : FlightSearchController
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult ReturnFlightSearch()
        {
            ViewBag.AllCities = GetAllCities();


            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReturnFlightSearch([Bind(Include = "ReturnBeginDepartureTimeRange,ReturnEndDepartureTimeRange,Nonstop,SeatsNeeded")] ReturnFSVM model)
        {
            //datetime objects have a (yyyy,mm,dd,hh,mm,ss) so to get (yyyy,mm,dd,0,0,0) you subtract time of day
            //then to get the day after, you add 24 hrs
            DateTime enddate = model.ReturnEndDepartureTimeRange - model.ReturnEndDepartureTimeRange.TimeOfDay + new TimeSpan(24, 0, 0);
            DateTime startdate = model.ReturnBeginDepartureTimeRange - model.ReturnBeginDepartureTimeRange.TimeOfDay;
            List<Flight> fquery = db.Flights.Where(d => d.DepartDateTime >= startdate
            && d.DepartDateTime <= enddate)
                .Where(d => d.Departed == false && d.Cancelled == false)
                .Where(c => c.SeatsAvailable >= model.SeatsNeeded).ToList();

            Int32 maxresid = db.Reservations.Max(x => x.ReservationID);
            Reservation newestReservation = db.Reservations.Find(maxresid);

            List<Ticket> alltickets= newestReservation.Tickets.ToList();
            DateTime ArrivalTime = new DateTime(2017, 12, 1);
            DateTime departingtime = new DateTime(2019, 12, 31);
            String ArrivalCityAirport = "";
            City DepartureCity = new City();
            foreach (Ticket ticket in alltickets)
            {
                if (ticket.Flight.DepartDateTime > ArrivalTime)
                {
                    ArrivalTime = ticket.Flight.DepartDateTime;
                    ArrivalCityAirport = ticket.Flight.FlightNumber.endCityAirport;
                }
                if (ticket.Flight.DepartDateTime < departingtime)
                {
                    departingtime = ticket.Flight.DepartDateTime;
                    DepartureCity = ticket.Flight.FlightNumber.startCity;
                }
            }

            City returnCity = db.Cities.First(x => x.Airport == DepartureCity.Airport);

            String endairport = returnCity.Airport;
            fquery = fquery.Where(d => d.FlightNumber.endCityAirport == endairport).ToList();


            fquery = fquery.Where(c => c.FlightNumber.startCity.Airport == ArrivalCityAirport).ToList();


            return View("ReturnSelectedFlights", fquery);
        }



        public ActionResult ReserveReturn(int id)
        {

            List<Seat> availableseats = db.Seats.Where(d => d.Flight.FlightID == id && d.IsAvailable).ToList();
            //  availableseats = availableseats.Where(d=>d.IsAvailable == true).ToList();
            List<Int32> chosenseatids = new List<Int32>();


            MultiSelectList SeatsChosen = new MultiSelectList(availableseats, "SeatID", "SeatName", chosenseatids);
            ViewBag.SeatsChosen = SeatsChosen;


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReserveReturn(int[] SeatIDs)
        {

            Int32 maxresid = db.Reservations.Max(c => c.ReservationID);
            Reservation newReservation = db.Reservations.Find(maxresid);

            foreach (int Seat in SeatIDs)
            {
                Seat thisSeat = db.Seats.Find(Seat);
                Flight assignedFlight = thisSeat.Flight;
                Ticket newTicket = new Ticket(thisSeat, newReservation);
                if (thisSeat.SeatName=="1A" || thisSeat.SeatName=="1B" || thisSeat.SeatName=="2A"|| thisSeat.SeatName=="2B")
                {
                    thisSeat.SeatType = db.SeatType.FirstOrDefault(s => s.Name == "FirstClass");


                }
                newTicket.Flight = (assignedFlight);
                thisSeat.IsAvailable = false;
                assignedFlight.SeatsAvailable -= 1;

                db.Tickets.Add(newTicket);


                //db.Seats.Attach(thisSeat);
                //db.Entry(thisSeat).Property(x => x.IsAvailable).IsModified = true;

                //db.Flights.Attach(assignedFlight);
                //db.Entry(assignedFlight).Property(x => x.SeatsAvailable).IsModified = true;

                db.SaveChanges();

            }

            return RedirectToAction("ReturnGetCustomer");
        }

        public ActionResult ReturnGetCustomer()
        {
            Int32 maxID = db.Reservations.Max(x => x.ReservationID);
            Reservation newestReservation = db.Reservations.Find(maxID);
            List<Seat> seatsWithNewTicket = db.Seats.Where(x => x.IsAvailable == false && x.Ticket.Reservation.ReservationID == newestReservation.ReservationID && x.Ticket.Customer == null).ToList();
            if (seatsWithNewTicket.Count == 0)
            {
                
                checkoutviewmodel vm = new checkoutviewmodel();
                return RedirectToAction("DeterminePaymentType", "Checkout");
            }
            return View(seatsWithNewTicket);

        }


        public ActionResult ReturnSearchCustomer(int? id)
        {
            CustomerSearchViewModel vm = new CustomerSearchViewModel();
            vm.Customers = db.Users.Where(c => c.EmpType == "Customer" || c.EmpType == null).ToList();
            vm.Seat = db.Seats.Find(id);
            ViewBag.SeatInfo = "Seat " + vm.Seat.SeatName + " on Flight " + vm.Seat.Flight.FlightNumber.Number.ToString() + " on " + vm.Seat.Flight.DepartDateTime.Date.ToString();
            vm.Customers = vm.Customers.OrderBy(d => d.AdvantageNumber).ThenBy(d => d.LastName).ThenBy(d => d.FirstName).ToList();
            db.csvms.Add(vm);
            db.SaveChanges();
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReturnSearchCustomer(CustomerSearchViewModel csvm)
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
            return View(vm);
        }
        public ActionResult ReturnAttachChosen(int seatid, string id)
        {
            AppUser customer = db.Users.Find(id);
            Seat seat = db.Seats.Find(seatid);

            seat.Ticket.Customer = customer;
            db.SaveChanges();
            return RedirectToAction("ReturnGetCustomer");
        }

        public ActionResult ReturnCreateCustomer(int? id)
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
        public async Task<ActionResult> ReturnCreateCustomer(CreateCustomerViewModel model, int? seatid)
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
                    return RedirectToAction("ReturnGetCustomer");
                }
                //AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }



        // GET: RoundTripFS


        //public ActionResult RTFlightSearch()
        //{
        //    ViewBag.AllCities = GetAllCities();

        //    return View();

        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult RTFlightSearch([Bind(Include = "BeginDepartureTimeRange,EndDepartureTimeRange,ReturnBeginDepartureTimeRange,ReturnEndDepartureTimeRange,SeatsNeeded,Nonstop")] RoundTripFSVM model, int City1ID, int City2ID)
        //{
        //    //datetime objects have a (yyyy,mm,dd,hh,mm,ss) so to get (yyyy,mm,dd,0,0,0) you subtract time of day
        //    //then to get the day after, you add 24 hrs
        //    DateTime enddate = model.EndDepartureTimeRange - model.EndDepartureTimeRange.TimeOfDay + new TimeSpan(24, 0, 0);
        //    DateTime startdate = model.BeginDepartureTimeRange - model.BeginDepartureTimeRange.TimeOfDay;
        //    DateTime returnstartdate= model.ReturnBeginDepartureTimeRange - model.ReturnBeginDepartureTimeRange.TimeOfDay;
        //    DateTime returnenddate= model.ReturnEndDepartureTimeRange - model.ReturnEndDepartureTimeRange.TimeOfDay + new TimeSpan(24, 0, 0);
        //    List<Flight> departurequery = db.Flights.Where(d => d.DepartDateTime >= startdate
        //    && d.DepartDateTime <= enddate)
        //        .Where(d => d.Departed == false && d.Cancelled == false)
        //        .Where(c => c.SeatsAvailable >= model.SeatsNeeded).ToList();

        //    departurequery = departurequery.Where(c => c.FlightNumber.startCity.CityID == City1ID).ToList();

        //    City endcity = db.Cities.Find(City2ID);

        //    String endairport = endcity.Airport;
        //    departurequery = departurequery.Where(d => d.FlightNumber.endCityAirport == endairport).ToList();
        //    model.DepartureCityID = City1ID;
        //    model.ArrivalCityID = City2ID;
        //    model.ReturnArrivalCityID = City1ID;
        //    model.ReturnDepartureCityID = City2ID;
        //    List<Flight> returnquery = db.Flights.Where(d => d.DepartDateTime >= returnstartdate
        //    && d.DepartDateTime <= returnenddate)
        //        .Where(d => d.Departed == false && d.Cancelled == false)
        //        .Where(c => c.SeatsAvailable >= model.SeatsNeeded).ToList();

        //    City ReturnArrivalCity = db.Cities.Find(City1ID);
        //    String ReturnEndAirport = ReturnArrivalCity.Airport;
        //    returnquery = departurequery.Where(c => c.FlightNumber.startCity.CityID == City2ID).ToList();
        //    returnquery = departurequery.Where(d => d.FlightNumber.endCityAirport == ReturnEndAirport).ToList();

        //    model.availableflights = departurequery;
        //    model.availableReturnFlights = returnquery;
        //    return View("RTSelectedFlights", model);
        //}


        //public ActionResult ReserveDepartureFlight(int id, RoundTripFSVM vm)
        //{
        //    vm.departureflight = db.Flights.Find(id);
        //    List<Seat> availableseats = db.Seats.Where(d => d.Flight.FlightID == id && d.IsAvailable).ToList();
        //    //  availableseats = availableseats.Where(d=>d.IsAvailable == true).ToList();
        //    List<Int32> chosenseatids = new List<Int32>();


        //    MultiSelectList SeatsChosen = new MultiSelectList(availableseats, "SeatID", "SeatName", chosenseatids);
        //    ViewBag.SeatsChosen = SeatsChosen;


        //    return View();
        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ReserveDepartureFlight(int[] SeatIDs, RoundTripFSVM vm)
        //{
        //    vm.reservation = new Reservation();
        //    vm.reservation.RoundTrip = true;
        //    db.Reservations.Add(vm.reservation);
        //    foreach (int Seat in SeatIDs)
        //    {
        //        Seat thisSeat = db.Seats.Find(Seat);
        //        Flight assignedFlight = thisSeat.Flight;
        //        Ticket newTicket = new Ticket(thisSeat, vm.reservation);
        //        newTicket.Flight = (assignedFlight);
        //        thisSeat.IsAvailable = false;
        //        assignedFlight.SeatsAvailable -= 1;

        //        db.Tickets.Add(newTicket);


        //        //db.Seats.Attach(thisSeat);
        //        //db.Entry(thisSeat).Property(x => x.IsAvailable).IsModified = true;

        //        //db.Flights.Attach(assignedFlight);
        //        //db.Entry(assignedFlight).Property(x => x.SeatsAvailable).IsModified = true;

        //        db.SaveChanges();

        //    }

        //    return RedirectToAction("ReturnSelectedFights", vm);
        //}

        //public ActionResult ReturnSelectedFights (RoundTripFSVM vm)
        //{
        //    return View(vm);
        //}

        //public ActionResult ReserveReturnFlight(int id, RoundTripFSVM vm)
        //{
        //    vm.departureflight = db.Flights.Find(id);
        //    List<Seat> availableseats = db.Seats.Where(d => d.Flight.FlightID == id && d.IsAvailable).ToList();
        //    //  availableseats = availableseats.Where(d=>d.IsAvailable == true).ToList();
        //    List<Int32> chosenseatids = new List<Int32>();


        //    MultiSelectList SeatsChosen = new MultiSelectList(availableseats, "SeatID", "SeatName", chosenseatids);
        //    ViewBag.SeatsChosen = SeatsChosen;


        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ReserveReturnFlight(int[] SeatIDs, RoundTripFSVM vm)
        //{

        //    foreach (int Seat in SeatIDs)
        //    {
        //        Seat thisSeat = db.Seats.Find(Seat);
        //        Flight assignedFlight = thisSeat.Flight;
        //        Ticket newTicket = new Ticket(thisSeat, vm.reservation);
        //        newTicket.Flight = (assignedFlight);
        //        thisSeat.IsAvailable = false;
        //        assignedFlight.SeatsAvailable -= 1;

        //        db.Tickets.Add(newTicket);


        //        //db.Seats.Attach(thisSeat);
        //        //db.Entry(thisSeat).Property(x => x.IsAvailable).IsModified = true;

        //        //db.Flights.Attach(assignedFlight);
        //        //db.Entry(assignedFlight).Property(x => x.SeatsAvailable).IsModified = true;

        //        db.SaveChanges();

        //    }

        //    return View("GetSeats", vm);
        //}

        //public ActionResult GetSeats(RoundTripFSVM vm)
        //{
        //    List<Ticket> alltickets= vm.reservation.Tickets.ToList();
        //    List<Seat> allseats = new List<Seat>();
        //    foreach (Ticket ticket in alltickets)
        //    {
        //        allseats.Add(ticket.Seat);
        //    }

        //    if (allseats.Count == 0)
        //    {
        //        return RedirectToAction("checkout", "checkout");
        //    }
        //    vm.Seats = allseats;
        //    return View(vm);
        //}
        ////just started

    }
}