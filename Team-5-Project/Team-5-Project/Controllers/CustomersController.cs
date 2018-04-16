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
using Microsoft.AspNet.Identity.EntityFramework;

namespace Team_5_Project.Controllers
{
    public class CustomersController : Controller
    {
        private AppDbContext db = new AppDbContext();
        private ApplicationSignInManager _signInManager;
        private AppUserManager _userManager;
        [Authorize(Roles = "Manager,Agent")]
        public ActionResult Index(int? id)
        {
            CustomerSearchViewModel vm = new CustomerSearchViewModel();
            vm.Customers = db.Users.Where(c => c.EmpType == "Customer" || c.EmpType == null).ToList();
            //ViewBag.SeatInfo = "Seat " + vm.Seat.SeatName + " on Flight " + vm.Seat.Flight.FlightNumber.Number.ToString() + " on " + vm.Seat.Flight.DepartDateTime.Date.ToString();
            vm.Customers = vm.Customers.OrderBy(d => d.AdvantageNumber).ThenBy(d => d.LastName).ThenBy(d => d.FirstName).ToList();
            return View(vm);
        }

        //// GET: Customers
        //public ActionResult Index(String SearchString)
        //{
        //    var customers = db.Users.Where(c => c.AdvantageNumber > 0).OrderBy(c => c.AdvantageNumber);
        //    return View(customers);
        //    //var query = from d in customers select d;

        //    ////Selected Customer List
        //    //List<AppUser> SelectedCustomers = new List<AppUser>();



        //    ////check for entry in string input
        //    //if (SearchString != null && SearchString != "")
        //    //{
        //    //    query = query.Where(d => d.FirstName.Contains(SearchString) || d.LastName.Contains(SearchString) || d.AdvantageNumber.ToString().Contains(SearchString));
        //    //}
        //    //query = query.OrderBy(d => d.AdvantageNumber).ThenBy(d => d.LastName).ThenBy(d => d.FirstName);
        //    //SelectedCustomers = query.ToList();
        //    //return View(SelectedCustomers);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Manager,Agent")]
        public ActionResult Index([Bind(Include = "FirstName,LastName,AdvantageNumber,MI,DOB,Address,City,State,ZipCode,PhoneNumber,Email,Miles")] CustomerSearchViewModel vm)
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
            //ViewBag.SeatInfo = "Seat " + vm.Seat.SeatName + " on Flight " + vm.Seat.Flight.FlightNumber.Number.ToString() + " on " + vm.Seat.Flight.DepartDateTime.Date.ToString();
            vm.Customers = vm.Customers.OrderBy(d => d.AdvantageNumber).ThenBy(d => d.LastName).ThenBy(d => d.FirstName).ToList();
            return View(vm);
        }



        //public ActionResult SearchResults(String SearchString)
        //{
        //    var customers = db.Users.Where(c => c.AdvantageNumber > 0).OrderBy(c => c.AdvantageNumber);
        //    List<AppUser> SelectedCustomers = new List<AppUser>();
        //    var query = from d in customers select d;
        //    if(SearchString != null && SearchString != "")
        //    {
        //        query = query.Where(d => d.FirstName.Contains(SearchString) || d.LastName.Contains(SearchString) || d.AdvantageNumber.ToString().Contains(SearchString));
        //    }
        //    query = query.OrderBy(d => d.AdvantageNumber).ThenBy(d => d.LastName).ThenBy(d => d.FirstName);
        //    SelectedCustomers = query.ToList();
        //    return View("Index", SelectedCustomers);

        //}

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser customer = db.Users.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: /Accounts/Register for customer
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
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

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        public Int32 GetNextAdvantageNumber()
        {
            //find the highest advantage number and add one

            Int32 MaxAdvantageNumber = db.Users.Where(c => c.EmpType == "Customer").Max(x => x.AdvantageNumber);
            Int32 NextAdvantageNumber = MaxAdvantageNumber++;


            return NextAdvantageNumber;
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel model)
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
                    EmpType = "Customer"

                };
                var result = await UserManager.CreateAsync(user, model.Password);


                //Once you get roles working, you may want to add users to roles upon creation
                await UserManager.AddToRoleAsync(user.Id, "Customer");



                if (result.Succeeded)
                {
                    //    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    //    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    //    // Send an email with this link
                    //    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    //    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    //    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                //AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            if (User.IsInRole("Manager") == false && User.Identity.GetUserId() != id.ToString() && User.IsInRole("Agent") == false) //they are trying to edit someone else's profile
            {
                return View("Error", new string[] { "You can only edit your own profile" });
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser customer = db.Users.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,AdvantageNumber,DOB,Address,EmailAddress")] Customer customer)
        {
            if (User.IsInRole("Manager") == false && User.Identity.GetUserId() != customer.Id && User.IsInRole("Agent") == false) //they are trying to edit someone else's profile
            {
                return View("Error", new string[] { "You can only edit your own profile" });
            }
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser customer = db.Users.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppUser customer = db.Users.Find(id);
            db.Users.Remove(customer);
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
