//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using Team_5_Project.DAL;
//using Team_5_Project.Models;

//namespace Team_5_Project.Controllers
//{
//    public class CostCalculatorController : Controller
//    {

//        public class Booking
//        {
//            private const int LIMIT = 6;

//            // TODO: This class should include the following:
//            // instance variable show which is a reference to a Show object

//            public Show show;
//            private int bookingID;
//            public List<ITicket> tickets;

//            public int BookingID
//            {
//                get { return bookingID; }
//                set { bookingID = value; }
//            }
//            public ViewResult Details(int id)
//            {
//                Reservation reservations = db.Reservations.Find(id);
//                ViewBag.Price = reservations.ActualFare * 1.0775
//            return View(reservations);
//            }

//            public Totalfare(Reservation reservation)
//            {
//                this.reservationID = reservationIDSequence.Instance.NextID;
//                this.show = reservation;
//                show.reservation(this);
//                this.tickets = new List<Reservation>();
//            }

//            private AppDbContext db = new AppDbContext();
//            public ViewResult Details(int id)
//            {
//                Reservation reservations = db.Reservations.Find(id);
//                ViewBag.Price = reservations.ActualFare * 1.0775
//            return View(reservations);
//            }

//            public void AddTickets(int number, TicketType type, decimal ActualFare)
//            {
//                // TODO:this method should instantiate the specified number of tickets of the
//                // specified type and add these to the list of tickets in this booking
//                if (type == TicketType.Adult)
//                {
//                    for (int i = 0; i < number; i++)
//                    {
//                        tickets.Add(new AdultTicket(Reservation.ReservationID, ActualFare));
//                    }
//                }
//                else if (type == TicketType.Child)
//                {
//                    for (int i = 0; i < number; i++)
//                    {
//                        tickets.Add(new ChildTicket(Reservation.ReservationID, ActualFare));
//                    }
//                }
//                else if (type == TicketType.Senior)
//                {
//                    for (int i = 0; i < number; i++)
//                    {
//                        tickets.Add(new SeniorTicket(Reservation.ReservationID, ActualFare));
//                    }
//                }
//            }



//            public decimal TotalCost()
//            {
//                // TODO: this method should return the total cost of the tickets in this booking
//            }

//            public override string ToString()
//            {
//                return string.Format("{0}: Total Cost={1:c}", ReservationID, TotalCost());
//            }

//        }
//    }
//}
//}