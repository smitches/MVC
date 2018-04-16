using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Team_5_Project.Models
{
    
    public enum Payment { Dollars, Miles }
    public class CustomerSearchViewModel
    {
        public Int32 CustomerSearchViewModelID { get; set; }
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public int? AdvantageNumber { get; set; }

        public String MI { get; set; }
        //public DateTime DOB { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String ZipCode { get; set; }
        public String PhoneNumber { get; set; }
        public string Email { get; set; }
        public Int32 Miles { get; set; }
        public Int32 PrimaryID { get; set; }
        public virtual List<AppUser> Customers { get; set; }

        public virtual Seat Seat { get; set; }
        public int? SeatID { get; internal set; }
    }

    public class CreateCustomerViewModel
    {
        //Add any fields that you need for creating a new user

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        //Additional fields go here

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Middle Initial")]
        public String MI { get; set; }

        [Display(Name = "Advantage Number")]
        public int? AdvantageNumber { get; set; }

        //[Required(ErrorMessage = "DOB is required")]
        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public String Address { get; set; }


        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "City")]
        public String City { get; set; }

        [Display(Name = "State")]
        public String State { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public String PhoneNumber { get; set; }

        [Display(Name = "Zip Code")]
        public String ZipCode { get; set; }

        [Display(Name = "Miles")]
        public Int32 Miles { get; set; }

        [Display(Name = "SSN")]
        public String SSN { get; set; }

        [Display(Name = "EmpType")]

        public String EmpType { get; set; }


        //NOTE: Here is the property for email
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //NOTE: Here is the logic for putting in a password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public virtual Seat Seat { get; set; }
    }

    public class checkoutviewmodel
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public Decimal PreTotal { get; set; }

        public Decimal DiscountedFare { get; set; }

        public Decimal ActualFare { get; set; }

        public Decimal Total { get; set; }

        public Decimal ChildDiscount { get; set; }

        public Decimal SeniorDiscount { get; set; }

        public Boolean Internetyes { get; set; }

        public Decimal InternetDiscount { get; set; }

        public Decimal FirstClass { get; set; }

        public Decimal EarlyDiscount { get; set; }

        public int? AdvantageNumber { get; set; }

        public String PaymentType { get; set; }

        public String Email { get; set; }

        public DateTime DepartDateTime { get; set; }
        public Int32 Flightnumber { get; set; }
        public String SeatName { get; set; }
        public decimal total { get; set; }

        

        public virtual List<Flight> Flights { get; set; }

        public virtual List<AppUser> Customers { get; set; }

        public virtual List<Seat> Seat { get; set; }

        public virtual List<Ticket> Tickets { get; set; }

        public checkoutviewmodel()
        {
            Flights = new List<Flight>();
            Customers = new List<AppUser>();
            Seat = new List<Seat>();
            Tickets = new List<Ticket>();
        }

        public List<Payment> paymentlist { get; set; }
 
    }
}