using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

//Change this namespace to match your project
namespace Team_5_Project.Models
{

    public class EmployeeLoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class EmployeeRegisterViewModel
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
        public Int32 AdvantageNumber { get; set; }

        [Required(ErrorMessage = "DOB is required")]
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
    }

    public class EmployeeIndexViewModel
    {
        public bool HasPassword { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String UserID { get; set; }
    }


    public class EmployeeChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

}