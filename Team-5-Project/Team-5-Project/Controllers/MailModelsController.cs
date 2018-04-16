using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Team_5_Project.Models;

namespace Team_5_Project.Controllers
{
    public class MailModelsController : Controller
    {
        //  
        // GET: /SendMailer/   
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegistrationConfirmed(RegisterViewModel model)
        {
                MailMessage mail = new MailMessage();
                mail.To.Add(model.Email);
                mail.From = new MailAddress("team5penguinairlines@gmail.com");
                mail.Subject = "Registration Confirmed";
                mail.Body = "Your registration has been confirmed";
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("team5penguinairlines", "ihatepenguinairlines"); // Enter seders User name and password   
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("Index", "Home");
        }

        public ActionResult FlightCancelled(checkoutviewmodel vm)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(vm.Email);
            mail.From = new MailAddress("team5penguinairlines@gmail.com");
            mail.Subject = "Team 5: Flight Cancelled";
            mail.Body = "Your flight (" + vm.Flightnumber + 
                "departing at" + vm.DepartDateTime +
                "has been cancelled.";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("team5penguinairlines", "ihatepenguinairlines"); // Enter seders User name and password   
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return View("Index", "Home");
        }

        public ActionResult ReservationConfirmed(checkoutviewmodel vm)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(vm.Email);
            mail.From = new MailAddress("team5penguinairlines@gmail.com");
            mail.Subject = "Team 5: Reservation Complete";
            mail.Body = "Your reservation has been confirmed. " +
                "Name: " + vm.FirstName + " " +  vm.LastName +
                "Flight: " + vm.Flightnumber +
                "Seat: " + vm.SeatName +
                "AdvantageNumber: " + vm.AdvantageNumber + 
                "Depart Date: " + vm.DepartDateTime +
                "Total Paid w/o tax: " + vm.PreTotal+
            "Total Paid: " + vm.PreTotal*1.0775m;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("team5penguinairlines", "ihatepenguinairlines"); // Enter seders User name and password   
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return View(vm);
        }
    }

        //public ViewResult Index(Team_5_Project.Models.MailModel _objModelMail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        MailMessage mail = new MailMessage();
        //        mail.To.Add(_objModelMail.To);
        //        mail.From = new MailAddress(_objModelMail.From);
        //        mail.Subject = _objModelMail.Subject;
        //        string Body = _objModelMail.Body;
        //        mail.Body = Body;
        //        mail.IsBodyHtml = true;
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = "smtp.gmail.com";
        //        smtp.Port = 587;
        //        smtp.UseDefaultCredentials = false;
        //        smtp.Credentials = new System.Net.NetworkCredential("team5penguinairlines", "ihatepenguinairlines"); // Enter seders User name and password   
        //        smtp.EnableSsl = true;
        //        smtp.Send(mail);
        //        return View("Index", _objModelMail);
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}






    }
