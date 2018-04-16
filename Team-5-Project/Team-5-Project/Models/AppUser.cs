using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// Change this namespace to match your project
namespace Team_5_Project.Models
{
   
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    //NOTE: This is the class for users
    public class AppUser : IdentityUser
    {
        // Put any additional fields that you need for your user here
        //For instance
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        //[StringLength(1, MinimumLength = 1, ErrorMessage = "Middle Initial must be at least 1 letter")]
        [Display(Name = "Middle Initial")]
        public String MI { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        public String FullName { get; set; }

        [Display(Name = "Advantage Number")]
        public Int32 AdvantageNumber { get; set; }

        //[Required(ErrorMessage = "DOB is required")]
        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Display(Name = "City")]
        public String City { get; set; }

        [Display(Name = "Address")]
        public String Address { get; set; }

        //[StringLength(5, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [Display(Name = "Zip Code")]
        public String ZipCode { get; set; }

       
        [Display(Name = "State")]
        public String State { get; set; }

        [Display(Name = "Miles")]
        public Decimal Miles { get; set; }

        [Display(Name = "SSN")]
        public String SSN { get; set; }

        [Display(Name = "EmpType")]
        public String EmpType { get; set; }

        


        public virtual List<Reservation> Reservations { get; set; }

        //[Required(ErrorMessage = "Email is required")] 
        //[DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid email address.")]
        //[Display(Name = "Email Address")]
        //[EmailAddress(ErrorMessage = "Please enter a valid email address")]
        //public String EmailAddress { get; set; }


        //This method allows you to create a new user 
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // NOTE: The authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}