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
{
    public class EmployeesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employees
        [Authorize(Roles = "Manager,Agent")]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser employee = db.Users.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Create([Bind(Include = "EmployeeID")] Employee employee)
        {
            
            if (ModelState.IsValid)
            {
                db.Users.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        
        public ActionResult Edit(string id)
        {
            if (User.IsInRole("Manager") == false && User.Identity.GetUserId() != id && User.IsInRole("Agent") == false) //they are trying to edit someone else's profile
            {
                return View("Error", new string[] { "You can only edit your own profile" });
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser employee = db.Users.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID")] Employee employee)
        {
            if (User.IsInRole("Manager") == false && User.Identity.GetUserId() != employee.Id && User.IsInRole("Agent") == false) //they are trying to edit someone else's profile
            {
                return View("Error", new string[] { "You can only edit your own profile" });
            }
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser employee = db.Users.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AppUser employee = db.Users.Find(id);
            db.Users.Remove(employee);
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
