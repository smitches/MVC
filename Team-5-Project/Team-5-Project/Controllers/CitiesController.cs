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
    public class CitiesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Cities
        public ActionResult Index()
        {
            return View(db.Cities.ToList());
        }

        // GET: Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: Cities/Create
        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Create([Bind(Include = "CityID,CityName,State,Airport")] City city)
        {
            if (ModelState.IsValid)
            {
                List<City> cityduplicate = db.Cities.Where(c => c.CityName == city.CityName || city.Airport == c.Airport).ToList();
                if (cityduplicate.Count > 0)
                {
                    ViewBag.Error = "Error: You cannot duplicate the city name or the airport";
                    return View(city);
                }
                db.Cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Create", "Routes");
                //return RedirectToAction("Index");
            }

            return View(city);
        }

        //public ActionResult CreateCityPairofRoute(City city)
        //{
        //    ViewBag.StartCity = city.Airport;

        //    List<City> allCities=db.Cities.ToList();
        //    List<Route> allRoutes = db.Routes.ToList();
        //    List<City> citiesInRouteAlreadyWithNew = new List<City>();
        //    //List<City> listnewcityonly = new List<City>();
        //    //listnewcityonly.Add(city);

        //    foreach (var route in allRoutes)
        //    {
        //        if (route.Cities.ToList().First()==(city))
        //        {
        //            citiesInRouteAlreadyWithNew.Add(route.Cities.ToList().Last());

        //        }
        //        /*
        //        foreach (var mycity in route.Cities)
        //        {
        //            if (citiesInRoutes.Contains(mycity) == false)
        //            {
        //                citiesInRoutes.Add(mycity);
        //            }
        //        }*/

        //    }



        //    //List<City> citiesToPair = allCities.Except(citiesInRoutes);
        //    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /*
        //    List<Route> routesWithNewCity = db.Routes.Where(c => c.Cities.Contains(city)).ToList();
        //    foreach (var route in routesWithNewCity)
        //    {
        //        foreach(var cityinexitingroute in route.Cities.ToList())
        //            if (cityinexitingroute != city)
        //            {
        //                if (citiesInRouteAlreadyWithNew.Contains(cityinexitingroute) == false)
        //                {
        //                    citiesInRouteAlreadyWithNew.Add(cityinexitingroute);
        //                }

        //            }
        //    }*/

        //    List<City> citiesINeed = allCities.Except(citiesInRouteAlreadyWithNew).ToList();
        //    ViewBag.EndCity = citiesINeed.First().Airport;
        //    Route thisroute = new Route();
        //    thisroute.Cities.Add(city);
        //    thisroute.Cities.Add(citiesINeed.First());
        //    thisroute.Hours = new TimeSpan(0);
        //    thisroute.Miles = 0;
        //    return View();
        //}

        // GET: Cities/Edit/5
        [Authorize(Roles = "Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Edit([Bind(Include = "CityID,CityName,State,Airport")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(city);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            City city = db.Cities.Find(id);
            db.Cities.Remove(city);
            db.SaveChanges();

            List<Route> RoutesWithCity = db.Routes.Where(c => c.Cities.Contains(city)).ToList();
            foreach (Route thisroute in RoutesWithCity)
            {
                db.Routes.Remove(thisroute);
                db.SaveChanges();
            }

            
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
