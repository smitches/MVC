﻿using System;
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

//Change this using statement to match your project
using Team_5_Project.Controllers;
using Team_5_Project.Models;
using Team_5_Project.DAL;
using System.Collections.Generic;

// Change this namespace to match your project
namespace Team_5_Project.Controllers

{


    [Authorize]
    public class AccountsController : Controller
    {
        //create instance of appdbcontext 
        private AppDbContext db = new AppDbContext();

        private ApplicationSignInManager _signInManager;
        private AppUserManager _userManager;

        public AccountsController()
        {
        }

        public AccountsController(AppUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
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

        //
        // GET: /Accounts/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated) //user has been redirected here from a page they're not authorized to see
            {
                return View("Error", new string[] { "Access Denied" });
            }
            AuthenticationManager.SignOut(); //this removes any old cookies hanging around
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Accounts/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }


        //
        // GET: /Accounts/Register for customer
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Accounts/Register for customer
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
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
                    EmpType = model.EmpType,

                };
                var result = await UserManager.CreateAsync(user, model.Password);


                //Once you get roles working, you may want to add users to roles upon creation
                await UserManager.AddToRoleAsync(user.Id, "Customer");



                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    MailModelsController c = new MailModelsController();
                    ActionResult newresult = c.RegistrationConfirmed(model);

                    //return View();
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

       
        //Logic for change password
        // GET: /Accounts/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Accounts/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", "Home");
            }
            AddErrors(result);
            return View(model);
        }

        //

        // POST: /Accounts/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: /Manage/Index
        public ActionResult Index(ManageMessageId? message)
        {
            var userId = User.Identity.GetUserId();
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                UserName = userId,
                Email = UserManager.GetEmail(userId),
                UserID = userId
            };
            return View(model);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region 

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            Error
        }
        //
        // GET: /Accounts/Register for employee


        //Frequency Method
        public SelectList GetAllRoles()
        {

            List<AppRole> approlelist = db.AppRoles.Distinct().ToList();
            
           
            SelectList allroles = new SelectList(approlelist, "Id", "Name");

            return allroles;
        }

        //GET method for registering employee
        [AllowAnonymous]
        public ActionResult EmployeeRegister()
        {

            ViewBag.RoleOptions = GetAllRoles();
            return View();
        }

        //
        // POST: /Accounts/Register for employee
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EmployeeRegister(EmployeeRegisterViewModel model, string SelectedRole)
        {
            
            if (ModelState.IsValid)
            {
                String rolename = db.AppRoles.Find(SelectedRole).Name;

                model.EmpType = rolename;
                //Add fields to user here so they will be saved to do the database
                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MI = model.MI,
                    SSN = model.SSN,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    PhoneNumber = model.PhoneNumber,
                    DOB = model.DOB,
                    EmpType = rolename,
                    //EmpType = model.EmpType,

                };
                var result = await UserManager.CreateAsync(user, model.Password);
                db.SaveChanges();
                //String rolename = db.AppRoles.Find(SelectedRole).Name;

                //model.EmpType = rolename;

                //Once you get roles working, you may want to add users to roles upon creation
                await UserManager.AddToRoleAsync(user.Id, rolename);


                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            ViewBag.RoleOptions = GetAllRoles();
            return View(model);
        }

        #endregion

        public Int32 GetNextAdvantageNumber()
        {
            //find the highest advantage number and add one

            Int32 MaxAdvantageNumber = db.Users.Where(c=>c.EmpType=="Customer").Max(x => x.AdvantageNumber);
            Int32 NextAdvantageNumber = MaxAdvantageNumber++; 


            return NextAdvantageNumber;
        }
  
    }
}