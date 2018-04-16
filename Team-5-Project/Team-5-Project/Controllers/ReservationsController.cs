using Microsoft.AspNet.Identity;
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
{   public enum TripType { OneWay,RoundTrip, MultiCity, All};
    public class ReservationsController : Controller
    {
        private AppDbContext db = new AppDbContext();


        public ActionResult StartReservation(int id)
        {
            ViewBag.FlightID = id;
            return View();
        }


        //[HttpPost]
        //public ActionResult StartReservation(Bint id)
        //{
        //    ViewBag.FlightID = id;
        //    return View();
        //}

        // GET: Reservations
        public ActionResult Index()
        {
            return View(db.Reservations.ToList());
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                //MailModelsController c = new MailModelsController();
                //ActionResult newresult = c.ReservationConfirmed(reservation);
                return RedirectToAction("Index");
            }

            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {      
            //String Id = User.Identity.GetUserId();
            //AppUser customer = db.Users.Find(Id);
            //Reservation CustomerReservation = new Reservation();
            //List<Ticket> custtickets = db.Tickets.Where(c => c.Customer.Id == customer.Id).ToList();
            ////if (User.IsInRole("Manager") == false && User.Identity.GetUserId() != Customer.Id && User.IsInRole("Agent") == false) //they are trying to edit someone else's profile
            ////{
            ////    return View("Error", new string[] { "You can only edit your own profile" });
            ////}
            //if (User.IsInRole("Manager"))
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // get all tickets to connect to flights
        public SelectList GetAllTickets(Reservation Reservations)
        {
            var query = from m in db.Tickets
                        orderby m.TicketID
                        select m;
            List<Ticket> allTickets = query.ToList();

            List<Int32> SelectedTickets = new List<Int32>();


            foreach (Ticket m in Reservations.Tickets)
            {
                SelectedTickets.Add(m.TicketID);
            }

            SelectList allTicketsList = new SelectList(allTickets, "TicketID", "Title", SelectedTickets);

            return allTicketsList;
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
