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
    public class RoutesController : Controller
    {

        //public City cityAdded = new City();
        //public City cityDestination = new City();
        private AppDbContext db = new AppDbContext();

        // GET: Routes
        public ActionResult Index()
        {
            return View(db.Routes.ToList());
        }

        // GET: Routes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        //public ActionResult CreateCityPairofRoute(City city)
        //{
        //    cityAdded = city;
        //    ViewBag.StartCity = city.Airport;

        //    List<City> allCities = db.Cities.ToList();
        //    List<Route> allRoutes = db.Routes.ToList();
        //    List<City> citiesInRouteAlreadyWithNew = new List<City>();
        //    //List<City> listnewcityonly = new List<City>();
        //    //listnewcityonly.Add(city);

        //    foreach (var route in allRoutes)
        //    {
        //        if (route.Cities.ToList().First() == (city))
        //        {
        //            citiesInRouteAlreadyWithNew.Add(route.Cities.ToList().Last());

        //        }
        //        else if (route.Cities.ToList().Last() == (city))
        //        {
        //            citiesInRouteAlreadyWithNew.Add(route.Cities.ToList().First());

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
        //    //Route thisroute = new Route();
        //    //thisroute.Cities.Add(city);
        //    //thisroute.Cities.Add(citiesINeed.First());
        //    //thisroute.Hours = new TimeSpan(0);
        //    //thisroute.Miles = 0;
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateCityPairofRoute([Bind(Include = "RouteID,Miles,Hours")] Route route)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Routes.Add(route);
        //        db.SaveChanges();
        //        City firstCity=route.Cities.ToList().First();
        //        return RedirectToAction("Create","Routes",firstCity);
        //    }

        //    return View(route);
        //}



        // GET: Routes/Create
        /*public ActionResult Create(int? cityID)
        {
            City city = db.Cities.Find(cityID);
            if (city == null)
            {
                return RedirectToAction("Index", "Cities");
            }
            
            ViewBag.StartCity = city.Airport;

            List<City> allCities = db.Cities.ToList();
            List<Route> allRoutes = db.Routes.ToList();
            List<City> citiesInRouteAlreadyWithNew = new List<City>();
            
            foreach (var route in allRoutes)
            {
                if (route.Cities.ToList().First() == (city))
                {
                    citiesInRouteAlreadyWithNew.Add(route.Cities.ToList().Last());

                }
                else if (route.Cities.ToList().Last() == (city))
                {
                    citiesInRouteAlreadyWithNew.Add(route.Cities.ToList().First());

                }
            
            }

            
            List<City> citiesINeed = allCities.Except(citiesInRouteAlreadyWithNew).ToList();
            ViewBag.EndCity = citiesINeed.First().Airport;
            if (citiesINeed==new List<City>()|| citiesINeed == null)
            {
                return RedirectToAction("Index", "Cities");
            }
            Route newroute = new Route();
            //route.RouteID = biggestRouteID + 1;
            
            newroute.Cities.Add(city);
            newroute.Cities.Add(citiesINeed.First());

            db.Routes.Add(newroute);
            
            
            db.SaveChanges();
            return RedirectToAction("FindRouteID", "Routes",newroute);
        }

        public ActionResult FindRouteID(Route route)
        {
            //return RedirectToAction("Index", "Routes");
            
            //Route routemade = db.Routes.Where(c => c.Hours == route.Hours).ToList().First();

            //query = query.Where(c => c.Miles == route.Miles);

            //Route dbRouteFound = query.ToList().First();

            Int32 MaxRouteID = db.Routes.Max(x => x.RouteID);
            Route routeToDelete = db.Routes.Find(MaxRouteID - 1);
            
            //db.Routes.Remove(routeToDelete);
            //db.SaveChanges();

            return RedirectToAction("Edit", MaxRouteID);
        }
        */
        public ActionResult Create()
        {
            City newestCity = db.Cities.Find(db.Cities.Max(x => x.CityID));
            List<City> allcities = db.Cities.ToList();
            List<Route> allRoutes = db.Routes.ToList();
            List<City> citiesAlreadyConnected = new List<City>();
            foreach (Route thisroute in allRoutes)
            {
                if (thisroute.Cities.Contains(newestCity))
                {
                    foreach(City nonnewcity in thisroute.Cities)
                    {
                        citiesAlreadyConnected.Add(nonnewcity);
                    }
                }
            }

            List<City> citiesNotConnected = allcities.Except(citiesAlreadyConnected).ToList();


            if ((citiesNotConnected.Count == 0))
            {
                return RedirectToAction("Index", "Cities");
            }

            City cityIChoose = citiesNotConnected.First();
            

            Route newRoute = new Route();
            newRoute.Cities.Add(newestCity);
            newRoute.Cities.Add(cityIChoose);
            db.Routes.Add(newRoute);
            db.SaveChanges();

            return RedirectToAction("Edit", "Routes", newRoute.RouteID);
        }


        // POST: Routes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RouteID,Miles,Hours")] Route route)
        {
            if (ModelState.IsValid)
            {
                db.Routes.Add(route);
                //route.Cities.Add();
                //route.Cities.Add(cityDestination);
                db.SaveChanges();
                return RedirectToAction("Create","Routes");
            }

            return View(route);
        }*/

        /*
        public ActionResult MakeAnotherRoute(Route route)
        {
            
            return RedirectToAction("Create", "Routes");
        }*/

        // GET: Routes/Edit/5
        public ActionResult Edit(int? id)
        {
            Route route = new Route();
            if (id == null)
            {
                id = db.Routes.Max(x => x.RouteID);
                id = id - 1;
                route = db.Routes.FirstOrDefault(c => c.Miles == 0.00m);
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                route = db.Routes.Find(id);
            }
            

            if (route == null)
            {
                return HttpNotFound();
            }
            ViewBag.StartCity = route.Cities.First().Airport;
            ViewBag.EndCity = route.Cities.Last().Airport;
            return View(route);
        }


        

        // POST: Routes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RouteID,Miles,Hours")] Route route)
        {
            if (ModelState.IsValid)
            {
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create","Routes");
            }

            ViewBag.StartCity = route.Cities.First().Airport;
            ViewBag.EndCity = route.Cities.Last().Airport;
            return View(route);
        }

        // GET: Routes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Route route = db.Routes.Find(id);
            db.Routes.Remove(route);
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
