using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using Team_5_Project.Models;
using System.Collections.Generic;
using Team_5_Project.DAL;



namespace Team_5_Project.Controllers
{

    //Gender and SortOrder enums


    public class HomeController : Controller
    {
        public AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return View();
        }



        ////detailed search
        //public ActionResult FlightSearch()
        //{
        //    ViewBag.AllCities = GetAllCities();
        //    ViewBag.AllDepartTimes = GetAllDepartTimes();
        //    ViewBag.AllDepartDays = GetAllDepartDays();
        //    return View();
        //}


        //public ActionResult SearchResults(int SelectedDepartureCity, int SelectedArrivalCity, int SelectedDate, int SelectedTime)
        //{
        //    //create new Flight list
        //    List<FlightNumber> SelectedFlightNumber = new List<FlightNumber>();
        //    var query = from c in db.FlightNumbers select c;
        //    //frequency code 
        //    if (SelectedDepartureCity != 0)
        //    {
        //        query = query.Where(c => c.Route.RouteID == SelectedDepartureCity);

        //    }
        //    if (SelectedArrivalCity != 0)
        //    {
        //        query = query.Where(c => c.Route.RouteID == SelectedArrivalCity);

        //    }
        //    if (SelectedDate != 0)
        //    {
        //        query = query.Where(c => c.FlightNumberID == SelectedDate);

        //    }
        //    if (SelectedTime != 0)
        //    {
        //        query = query.Where(c => c.FlightNumberID == SelectedTime);

        //    }
        //    query = query.OrderBy(c => c.DepartureDays);
        //    SelectedFlightNumber = query.ToList();
        //    return View("Index", SelectedFlightNumber);

        //}




        //public SelectList GetAllDepartTimes()
        //{

        //    List<Flight> DepartDateTimeList = db.Flights.ToList();


        //    Flight SelectNone = new Models.Flight() { FlightID = 0 };
        //    DepartDateTimeList.Add(SelectNone);

        //    SelectList AllDepartTimes = new SelectList(DepartDateTimeList.OrderBy(f => f.FlightID), "FlightID", "FlightNumber");

        //    return AllDepartTimes;
        //}

        //public SelectList GetAllDepartDays()
        //{

        //    List<FlightNumber> DepartureDaysList = db.FlightNumbers.ToList();


        //    FlightNumber SelectNone = new Models.FlightNumber() { FlightNumberID = 0};
        //    DepartureDaysList.Add(SelectNone);

        //    SelectList AllDepartDays = new SelectList(DepartureDaysList.OrderBy(f => f.FlightNumberID), "FlightNumberID", "Number");

        //    return AllDepartDays;
        //}
        ////Frequency Method
        //public SelectList GetAllCities()
        //{

        //    List<City> CityList = db.Cities.ToList();


        //    City SelectNone = new Models.City() { CityID = 0, CityName = "All Cities" };
        //    CityList.Add(SelectNone);

        //    SelectList AllCities = new SelectList(CityList.OrderBy(f => f.CityID), "CityID", "CityName");

        //    return AllCities;
    }
    }




