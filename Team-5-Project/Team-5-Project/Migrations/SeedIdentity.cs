using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

//Change these using statements to match your project
using Team_5_Project.DAL;
using Team_5_Project.Models;

//TChange this namespace to match your project
namespace Team_5_Project.Migrations
{
    //add identity data
    public class SeedIdentity
    {
        public void AddAdmin(AppDbContext db)
        {
            //create a user manager and a role manager to use for this method
            AppUserManager UserManager = new AppUserManager(new UserStore<AppUser>(db));

            //create a role manager
            AppRoleManager RoleManager = new AppRoleManager(new RoleStore<AppRole>(db));



            //check to see if the admin has been added
            AppUser Manager = db.Users.FirstOrDefault(u => u.UserName == "admin@example.com");

            //if admin hasn't been created, then add them
            if (Manager == null)
            {
                Manager = new Manager();
                //Manager.MI = "A";
                Manager.UserName = "admin@example.com";
                Manager.Email = "admin@example.com";
                Manager.FirstName = "Manager";
                Manager.PhoneNumber = "(512)555-5555";
                Manager.LastName = "Manager";
                Manager.DOB = new System.DateTime(1990,01,01);
                Manager.MI = "N";
                Manager.City = "Keller";
                Manager.Address = "1901 Rio Grande";
                Manager.ZipCode = "78705";
                Manager.State = "TX";
                Manager.Miles = 12345;
                Manager.SSN = "1236788";
                Manager.EmpType = "Manager";



                var result = UserManager.Create(Manager, "Abc123!");
                db.SaveChanges();
                Manager = db.Users.First(u => u.UserName == "admin@example.com");
            }

            // Add the needed roles
            //if role doesn't exist, add it
            if (RoleManager.RoleExists("Manager") == false)
            {
                RoleManager.Create(new AppRole("Manager"));
            }

            if (RoleManager.RoleExists("Customer") == false)
            {
                RoleManager.Create(new AppRole("Customer"));
            }

            if (RoleManager.RoleExists("Cabin Crew") == false)
            {
                RoleManager.Create(new AppRole("Cabin Crew"));
            }

            if (RoleManager.RoleExists("Pilot") == false)
            {
                RoleManager.Create(new AppRole("Pilot"));
            }

            if (RoleManager.RoleExists("Co Pilot") == false)
            {
                RoleManager.Create(new AppRole("Co Pilot"));
            }

            if (RoleManager.RoleExists("Agent") == false)
            {
                RoleManager.Create(new AppRole("Agent"));
            }
            //make sure user is in role
            if (UserManager.IsInRole(Manager.Id, "Manager") == false)
            {
                UserManager.AddToRole(Manager.Id, "Manager");
            }

            //save changes
            db.SaveChanges();
        }

    }
}