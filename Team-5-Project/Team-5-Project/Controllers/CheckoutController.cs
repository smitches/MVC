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
using System.Web.Mvc.Html;



namespace Team_5_Project.Controllers
{
    

    public class CheckoutController : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: Checkout


        public ActionResult CalculateCost()
        {
            Int32 maxID = db.Reservations.Max(x => x.ReservationID);
            Reservation newestReservation = db.Reservations.Find(maxID);
            List<Ticket> ReservationWithNewTicket = db.Tickets.Where(x => x.Reservation.ReservationID == newestReservation.ReservationID).ToList();

            foreach (Ticket ThisTicket in ReservationWithNewTicket)
            {   
                ThisTicket.ActualFare = ThisTicket.Flight.ActualFare;

                if (ThisTicket.Seat.SeatType.Name == "FirstClass")

                    {
                        ThisTicket.ActualFare = ThisTicket.ActualFare * 1.2m;
                    db.SaveChanges();

                }
                if (ThisTicket.Customer.DOB < new DateTime(1952, 12, 8, 0, 0, 0))
                {
                    if (ThisTicket.Seat.SeatType.Name == "Economy")
                    {
                        ThisTicket.SeniorDiscount = ThisTicket.ActualFare * -.1m;
                        db.SaveChanges();
                    }

                }
                if (ThisTicket.Customer.DOB > new DateTime(2005, 12, 8, 0, 0, 0) && ThisTicket.Customer.DOB < new DateTime(2014, 12, 8, 0, 0, 0))
                {
                    if (ThisTicket.Seat.SeatType.Name == "Economy")
                    {

                        ThisTicket.ChildDiscount = ThisTicket.ActualFare * -.15m;
                        db.SaveChanges();
                    }


                }
                if (ThisTicket.Flight.DepartDateTime - DateTime.Now >= new TimeSpan(14, 0, 0, 0))
                {
                    ThisTicket.EarlyDiscount = ThisTicket.ActualFare * -.1m;
                    db.SaveChanges();

                }
                if (ThisTicket.Internetyes== true)
                {
                    ThisTicket.InternetDiscount = ThisTicket.ActualFare * -.05m;
                    db.SaveChanges();
                 
                }
                db.SaveChanges();
            }
            return RedirectToAction("ShowTotal");
        }


        public ActionResult UseMiles (int? id)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket.Seat.SeatName == "1A" || ticket.Seat.SeatName=="2A"|| ticket.Seat.SeatName == "1B" || ticket.Seat.SeatName == "2B") 
            {
                if (ticket.Customer.Miles>2000)
                {
                    ticket.Customer.Miles -= 2000;
                    ticket.PayWithMiles = true;
                    
                    db.SaveChanges();
                    return RedirectToAction("DeterminePaymentType");
                }
            }
            else
            {
                if (ticket.Customer.Miles > 1000)
                {
                    ticket.Customer.Miles -= 1000;
                    ticket.PayWithMiles = true;
                   
                    db.SaveChanges();
                    return RedirectToAction("DeterminePaymentType");
                }
            }
            ViewBag.Error = "Customer does not have enough mile points";

            return RedirectToAction("DeterminePaymentType");
        }
        public ActionResult ShowTotal()
        {
            checkoutviewmodel vm = new checkoutviewmodel();
            decimal total = vm.Total;
            Int32 maxID = db.Reservations.Max(x => x.ReservationID);
            Reservation newestReservation = db.Reservations.Find(maxID);
            List<Ticket> ReservationWithNewTickets = db.Tickets.Where(x => x.Reservation.ReservationID == newestReservation.ReservationID).ToList();
            string UserId = User.Identity.GetUserId();
            AppUser LoggedIn = db.Users.Find(UserId);

            if (LoggedIn.EmpType == "Customer")
            {
                newestReservation.PrimaryTravelerID = LoggedIn;
                db.SaveChanges();
            }
            else if (newestReservation.PrimaryTravelerID == null && (LoggedIn.EmpType == "Agent" || LoggedIn.EmpType == "Manager"))
            {
                return RedirectToAction("ChoosePrimaryTraveler");
            }


            foreach (Ticket ThisTicket in ReservationWithNewTickets)
            {
                total += ThisTicket.ActualFare + ThisTicket.EarlyDiscount + ThisTicket.ChildDiscount + ThisTicket.SeniorDiscount + ThisTicket.InternetDiscount;
                ThisTicket.DiscountedFare = ThisTicket.ActualFare + ThisTicket.EarlyDiscount + ThisTicket.ChildDiscount + ThisTicket.SeniorDiscount + ThisTicket.InternetDiscount;
                db.SaveChanges();

                vm.Email = ThisTicket.Customer.Email;
                vm.FirstName = ThisTicket.Customer.FirstName;
                vm.LastName = ThisTicket.Customer.LastName;
                vm.Flightnumber = ThisTicket.Flight.FlightNumber.Number;
                vm.SeatName = ThisTicket.Seat.SeatName;
                vm.AdvantageNumber = ThisTicket.Customer.AdvantageNumber;
                vm.DepartDateTime = ThisTicket.Flight.DepartDateTime;
                vm.DiscountedFare = ThisTicket.DiscountedFare;
                vm.PreTotal += total;

                MailModelsController c = new MailModelsController();
                ActionResult newresult = c.ReservationConfirmed(vm);

            }
            vm.Tickets = ReservationWithNewTickets;
            vm.PreTotal = total;

            vm.Total = total * 1.0775m;
            return View(vm);

        }


        public ActionResult AttachChosen(string id)
        {
            Int32 maxID = db.Reservations.Max(x => x.ReservationID);
            Reservation newestReservation = db.Reservations.Find(maxID);
            List<Ticket> ReservationWithNewTickets = db.Tickets.Where(x => x.Reservation.ReservationID == newestReservation.ReservationID).ToList();
            
            AppUser PrimaryTraveler = db.Users.Find(id);

            newestReservation.PrimaryTravelerID = PrimaryTraveler;
            db.SaveChanges();

            return RedirectToAction("ShowTotal");
        }

        public ActionResult OfferLapChild()
        {
            Int32 maxid = db.Reservations.Max(x => x.ReservationID);
            Reservation newestres = db.Reservations.Find(maxid);
            List<AppUser> customers = new List<AppUser>();
            foreach (Ticket ticket in newestres.Tickets)
            {
                if (ticket.Customer.DOB<new DateTime(2002, 12, 8))
                {
                    customers.Add(ticket.Customer);
                }
            }
            return View(customers);
        }

        public ActionResult AttachChosenLapChildTo(string id)
        {
            Int32 maxID = db.Reservations.Max(x => x.ReservationID);
            Reservation newestReservation = db.Reservations.Find(maxID);
            List<Ticket> ReservationWithNewTickets = db.Tickets.Where(x => x.Reservation.ReservationID == newestReservation.ReservationID).ToList();
            AppUser customer = db.Users.Find(id);

            List<AppUser> children = db.Users.Where(c => c.DOB >= new DateTime(2014, 12, 8)).ToList();
            children.Add(customer);
            //ReservationWithNewTickets.Ticket.LapChild = true;

            db.SaveChanges();
            return View("GetChildName", customer);


        }

        public ActionResult NameChild(string id, string name)
        {
            AppUser Customer = db.Users.Find(id);
            Int32 maxid = db.Reservations.Max(x => x.ReservationID);
            Reservation reservation = db.Reservations.Find(maxid);
            foreach (Ticket ticket in reservation.Tickets)
            {
                if (ticket.Customer.Id == id)
                {
                    ticket.LapChild = name;
                }
            }
            return RedirectToAction("OfferLapChild");
        }

        //public ActionResult AttachChosenLapChild(string id, string customerid)
        //{
        //    AppUser customer = db.Users.Find(customerid);
        //    AppUser child = db.Users.Find(id);
        //    Int32 maxid = db.Reservations.Max(x => x.ReservationID);
        //    Reservation newestreservation = db.Reservations.Find(maxid);
        //    List<Ticket> tickets = db.Tickets.Where(c=>c.Customer.Id==customerid && c.Reservation.ReservationID==maxid).ToList();
        //    foreach (Ticket ticket in tickets)
        //    {
        //        ticket.LapChild = child;
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("ShowTotal");
        //}

        public ActionResult ChoosePrimaryTraveler()
        {
            return RedirectToAction("SearchCustomer");
        }

        public ActionResult SearchCustomer(int? id)
        {
            CustomerSearchViewModel vm = new CustomerSearchViewModel();
            vm.Customers = db.Users.Where(c => c.EmpType == "Customer" || c.EmpType == null).ToList();
            vm.Customers = vm.Customers.OrderBy(d => d.AdvantageNumber).ThenBy(d => d.LastName).ThenBy(d => d.FirstName).ToList();
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchCustomer([Bind(Include = "FirstName,LastName,AdvantageNumber")] CustomerSearchViewModel vm)
        {

            vm.Customers = db.Users.Where(c => c.EmpType == "Customer" || c.EmpType == null).ToList();
            if (vm.FirstName != null)
            {
                vm.Customers = vm.Customers.Where(c => c.FirstName.Contains(vm.FirstName)).ToList();
            }
            if (vm.LastName != null)
            {
                vm.Customers = vm.Customers.Where(c => c.LastName.Contains(vm.LastName)).ToList();
            }
            if (vm.AdvantageNumber != null)
            {
                vm.Customers = vm.Customers.Where(c => c.AdvantageNumber == vm.AdvantageNumber).ToList();
            }

            vm.Customers = vm.Customers.OrderBy(d => d.AdvantageNumber).ThenBy(d => d.LastName).ThenBy(d => d.FirstName).ToList();
            return View(vm);
        }

        public ActionResult DeterminePaymentType(string error)
        {
            Int32 maxid = db.Reservations.Max(x => x.ReservationID);
            Reservation newreservation = db.Reservations.Find(maxid);
            
            return View(newreservation.Tickets.Where(x=>x.PayWithMiles==false).ToList());
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeterminePaymentType()
        {
        
            return RedirectToAction("CalculateCost");

        }

        public ActionResult InternetReservation()
        {
            Int32 maxid = db.Reservations.Max(c => c.ReservationID);
            Reservation newestRes = db.Reservations.Find(maxid);
            foreach (Ticket ticket in newestRes.Tickets)
            {
                ticket.Internetyes = true;
                db.SaveChanges();
            }
            return RedirectToAction("CalculateCost");
        }




    } 

}






    //    public ActionResult ShowTotal(checkoutviewmodel cvm, int[] SelectedPayment)
    //    {
    //        public decimal total;
    //    Int32 maxID = db.Reservations.Max(x => x.ReservationID);
    //    Reservation newestReservation = db.Reservations.Find(maxID);
    //    List<Ticket> ReservationWithNewTickets = db.Tickets.Where(x => x.Reservation.ReservationID == newestReservation.ReservationID).ToList();
           
    //            foreach (Ticket ThisTicket in ReservationWithNewTickets)
    //            {
    //                 total = total + ThisTicket.ActualFare;
    //            }
    //model.PreTotal=Total;
    //            model.Total=total*1.0775
    //            return RedirectToAction("ShowTotal","Checkout", cvm); 


    

  

        
