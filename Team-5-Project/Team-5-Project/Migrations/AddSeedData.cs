using Team_5_Project.Models;
using Team_5_Project.DAL;
using System.Data.Entity.Migrations;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Team_5_Project.Migrations
{
    public class AddSeedData
    {
        public static AppDbContext db = new AppDbContext();

        public void SeedCustomerData(AppDbContext db)
        {
            AppUserManager UserManager = new AppUserManager(new UserStore<AppUser>(db));
            AppRoleManager RoleManager = new AppRoleManager(new RoleStore<AppRole>(db));

            AppUser c1 = db.Users.FirstOrDefault(u => u.UserName == "cbaker@freserve.co.uk");
            if (c1 == null)
            {
                c1 = new AppUser();
                c1.AdvantageNumber = 5001;
                c1.LastName = "Baker";
                c1.FirstName = "Christopher";
                c1.MI = "L.";
                c1.DOB = Convert.ToDateTime("11/23/1949");
                c1.Address = "1245 Lake Anchorage Blvd.";
                c1.City = "Anchorage";
                c1.State = "AK";
                c1.ZipCode = "99501";
                c1.PhoneNumber = "9075571146";
                c1.Email = "cbaker@freserve.co.uk";
                c1.UserName = "cbaker@freserve.co.uk";
                c1.Miles = 5000;
                c1.EmpType = "Customer";
                var result = UserManager.Create(c1, "hello1");
                
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "cbaker@freserve.co.uk");
                
            }

            UserManager.AddToRole(c1.Id, "Customer");

            AppUser c2 = db.Users.FirstOrDefault(u => u.UserName == "banker@penguin.net");
            if (c2 == null)
            {
                c2 = new AppUser();
                c2.AdvantageNumber = 5002;
                c2.LastName = "Banks";
                c2.FirstName = "Michelle";
                c2.MI = "";
                c2.DOB = Convert.ToDateTime("11/27/1962");
                c2.Address = "1300 Tall Pine Lane";
                c2.City = "Anchorage";
                c2.State = "AK";
                c2.ZipCode = "99502";
                c2.PhoneNumber = "9042678873";
                c2.Email = "banker@penguin.net";
                c2.UserName = "banker@penguin.net";
                c2.Miles = 0;
                c2.EmpType = "Customer";
                var result = UserManager.Create(c2, "potato");
                db.SaveChanges();
                c2 = db.Users.First(u => u.UserName == "banker@penguin.net");
            }
            UserManager.AddToRole(c2.Id, "Customer");

            AppUser c3 = db.Users.FirstOrDefault(u => u.UserName == "franco@aoll.com");
            if (c3 == null)
            {
                c3 = new AppUser();
                c3.AdvantageNumber = 5003;
                c3.LastName = "Broccolo";
                c3.FirstName = "Franco";
                c3.MI = "V";
                c3.DOB = Convert.ToDateTime("10/11/1992");
                c3.Address = "62 Browning Road";
                c3.City = "Anchorage";
                c3.State = "AK";
                c3.ZipCode = "99501";
                c3.PhoneNumber = "4155659699";
                c3.Email = "franco@aoll.com";
                c3.UserName = "franco@aoll.com";
                c3.Miles = 10000;
                c3.EmpType = "Customer";
                var result = UserManager.Create(c3, "painting");
                db.SaveChanges();
                c3 = db.Users.First(u => u.UserName == "franco@aoll.com");
            }
            UserManager.AddToRole(c3.Id, "Customer");
            AppUser c4 = db.Users.FirstOrDefault(u => u.UserName == "wchang@gogle.com");
            if (c4 == null)
            {
                c4 = new AppUser();
                c4.AdvantageNumber = 5004;
                c4.LastName = "Chang";
                c4.FirstName = "Wendy";
                c4.MI = "L";
                c4.DOB = Convert.ToDateTime("5/16/1997");
                c4.Address = "202 Bellmont Hall";
                c4.City = "Juneau";
                c4.State = "AK";
                c4.ZipCode = "99801";
                c4.PhoneNumber = "9075943222";
                c4.Email = "wchang@gogle.com";
                c4.UserName = "wchang@gogle.com";
                c4.Miles = 5000;
                c4.EmpType = "Customer";
                var result = UserManager.Create(c4, "texas1");
                db.SaveChanges();
                c4 = db.Users.First(u => u.UserName == "wchang@gogle.com");
            }
            UserManager.AddToRole(c4.Id, "Customer");

            AppUser c5 = db.Users.FirstOrDefault(u => u.UserName == "limchou@yoho.com");
            if (c5 == null)
            {
                c5 = new AppUser();
                c5.AdvantageNumber = 5005;
                c5.LastName = "Chou";
                c5.FirstName = "Lim";
                c5.MI = "";
                c5.DOB = Convert.ToDateTime("4/6/1970");
                c5.Address = "1600 Teresa Lane";
                c5.City = "Fort Meyers";
                c5.State = "FL";
                c5.ZipCode = "33917";
                c5.PhoneNumber = "8137724599";
                c5.Email = "limchou@yoho.com";
                c5.UserName = "limchou@yoho.com";
                c5.Miles = 0;
                c5.EmpType = "Customer";
                var result = UserManager.Create(c5, "Anchorage");
                db.SaveChanges();
                c5 = db.Users.First(u => u.UserName == "limchou@yoho.com");
            }
            UserManager.AddToRole(c5.Id, "Customer");
            AppUser c6 = db.Users.FirstOrDefault(u => u.UserName == "shdixon@utx.edu");
            if (c6 == null)
            {
                c6 = new AppUser();
                c6.AdvantageNumber = 5006;
                c6.LastName = "Dixon";
                c6.FirstName = "Shan";
                c6.MI = "D";
                c6.DOB = Convert.ToDateTime("1/12/1984");
                c6.Address = "234 Holston Circle";
                c6.City = "Sheffield";
                c6.State = "AL";
                c6.ZipCode = "35662";
                c6.PhoneNumber = "2052643255";
                c6.Email = "shdixon@utx.edu";
                c6.UserName = "shdixon@utx.edu";
                c6.Miles = 0;
                c6.EmpType = "Customer";
                var result = UserManager.Create(c6, "pepperoni");
                db.SaveChanges();
                c6 = db.Users.First(u => u.UserName == "shdixon@utx.edu");
            }
            UserManager.AddToRole(c6.Id, "Customer");
            AppUser c7 = db.Users.FirstOrDefault(u => u.UserName == "j.b.evans@aheca.org");
            if (c7 == null)
            {
                c7 = new AppUser();
                c7.AdvantageNumber = 5007;
                c7.LastName = "Evans";
                c7.FirstName = "Jim Bob";
                c7.MI = "";
                c7.DOB = Convert.ToDateTime("9/9/1959");
                c7.Address = "506 Farrell Circle";
                c7.City = "Juneau";
                c7.State = "AK";
                c7.ZipCode = "99803";
                c7.PhoneNumber = "2102565834";
                c7.Email = "j.b.evans@aheca.org";
                c7.UserName = "j.b.evans@aheca.org";
                c7.Miles = 9000;
                c7.EmpType = "Customer";
                var result = UserManager.Create(c7, "longhorns");
                db.SaveChanges();
                c7 = db.Users.First(u => u.UserName == "j.b.evans@aheca.org");
            }
            UserManager.AddToRole(c7.Id, "Customer");

            AppUser c8 = db.Users.FirstOrDefault(u => u.UserName == "feeley@penguin.org");
            if (c8 == null)
            {
                c8 = new AppUser();
                c8.AdvantageNumber = 5008;
                c8.LastName = "Feeley";
                c8.FirstName = "Lou Ann";
                c8.MI = "K";
                c8.DOB = Convert.ToDateTime("1/12/2002");
                c8.Address = "600 S 8th Street W";
                c8.City = "Fairbanks";
                c8.State = "AK";
                c8.ZipCode = "99790";
                c8.PhoneNumber = "4062556749";
                c8.Email = "feeley@penguin.org";
                c8.UserName = "feeley@penguin.org";
                c8.Miles = 6000;
                c8.EmpType = "Customer";
                var result = UserManager.Create(c8, "aggies");
                db.SaveChanges();
                c8 = db.Users.First(u => u.UserName == "feeley@penguin.org");
            }

            UserManager.AddToRole(c8.Id, "Customer");
            AppUser c9 = db.Users.FirstOrDefault(u => u.UserName == "tfreeley@minnetonka.ci.us");
            if (c9 == null)
            {
                c9 = new AppUser();
                c9.AdvantageNumber = 5009;
                c9.LastName = "Freeley";
                c9.FirstName = "Tesa";
                c9.MI = "P";
                c9.DOB = Convert.ToDateTime("2/4/1991");
                c9.Address = "4448 Fairview Ave.";
                c9.City = "Minnetonka";
                c9.State = "MN";
                c9.ZipCode = "55343";
                c9.PhoneNumber = "6123255687";
                c9.Email = "tfreeley@minnetonka.ci.us";
                c9.UserName = "tfreeley@minnetonka.ci.us";
                c9.Miles = 0;
                c9.EmpType = "Customer";
                var result = UserManager.Create(c9, "raiders");
                db.SaveChanges();
                c9 = db.Users.First(u => u.UserName == "tfreeley@minnetonka.ci.us");
            }
            UserManager.AddToRole(c9.Id, "Customer");

            AppUser c10 = db.Users.FirstOrDefault(u => u.UserName == "mgarcia@gogle.com");
            if (c10 == null)
            {
                c10 = new AppUser();
                c10.AdvantageNumber = 5010;
                c10.LastName = "Garcia";
                c10.FirstName = "Margaret";
                c10.MI = "L";
                c10.DOB = Convert.ToDateTime("10/2/1991");
                c10.Address = "594 Longview";
                c10.City = "Fairbanks";
                c10.State = "AK";
                c10.ZipCode = "99790";
                c10.PhoneNumber = "4066593544";
                c10.Email = "mgarcia@gogle.com";
                c10.UserName = "mgarcia@gogle.com";
                c10.Miles = 4000;
                c10.EmpType = "Customer";
                var result = UserManager.Create(c10, "mustangs");
                db.SaveChanges();
                c10 = db.Users.First(u => u.UserName == "mgarcia@gogle.com");
            }
            UserManager.AddToRole(c10.Id, "Customer");
            AppUser c11 = db.Users.FirstOrDefault(u => u.UserName == "chaley@thug.com");
            if (c11 == null)
            {
                c11 = new AppUser();
                c11.AdvantageNumber = 5011;
                c11.LastName = "Haley";
                c11.FirstName = "Charles";
                c11.MI = "E";
                c11.DOB = Convert.ToDateTime("7/10/1974");
                c11.Address = "One Cowboy Pkwy";
                c11.City = "Juneau";
                c11.State = "AK";
                c11.ZipCode = "99801";
                c11.PhoneNumber = "2148475583";
                c11.Email = "chaley@thug.com";
                c11.UserName = "chaley@thug.com";
                c11.Miles = 7000;
                c11.EmpType = "Customer";
                var result = UserManager.Create(c11, "onetime");
                db.SaveChanges();
                c11 = db.Users.First(u => u.UserName == "chaley@thug.com");
            }
            UserManager.AddToRole(c11.Id, "Customer");
            AppUser c12 = db.Users.FirstOrDefault(u => u.UserName == "jeffh@sonic.com");
            if (c12 == null)
            {
                c12 = new AppUser();
                c12.AdvantageNumber = 5012;
                c12.LastName = "Hampton";
                c12.FirstName = "Jeffrey";
                c12.MI = "T.";
                c12.DOB = Convert.ToDateTime("3/10/2014");
                c12.Address = "337 38th St.";
                c12.City = "Juneau";
                c12.State = "AK";
                c12.ZipCode = "99802";
                c12.PhoneNumber = "9076978613";
                c12.Email = "jeffh@sonic.com";
                c12.UserName = "jeffh@sonic.com";
                c12.Miles = 5000;
                c12.EmpType = "Customer";
                var result = UserManager.Create(c12, "hampton1");
                db.SaveChanges();
                c12 = db.Users.First(u => u.UserName == "jeffh@sonic.com");
            }
            UserManager.AddToRole(c12.Id, "Customer");
            AppUser c13 = db.Users.FirstOrDefault(u => u.UserName == "wjhearniii@umich.org");
            if (c13 == null)
            {
                c13 = new AppUser();
                c13.AdvantageNumber = 5013;
                c13.LastName = "Hearn";
                c13.FirstName = "John";
                c13.MI = "B";
                c13.DOB = Convert.ToDateTime("8/5/1950");
                c13.Address = "4225 North First";
                c13.City = "Fairbanks";
                c13.State = "AK";
                c13.ZipCode = "99790";
                c13.PhoneNumber = "5208965621";
                c13.Email = "wjhearniii@umich.org";
                c13.UserName = "wjhearniii@umich.org";
                c13.Miles = 7000;
                c13.EmpType = "Customer";
                var result = UserManager.Create(c13, "jhearn22");
                db.SaveChanges();
                c13 = db.Users.First(u => u.UserName == "wjhearniii@umich.org");
            }
            UserManager.AddToRole(c13.Id, "Customer");
            AppUser c14 = db.Users.FirstOrDefault(u => u.UserName == "ahick@yaho.com");
            if (c14 == null)
            {
                c14 = new AppUser();
                c14.AdvantageNumber = 5014;
                c14.LastName = "Hicks";
                c14.FirstName = "Anthony";
                c14.MI = "J";
                c14.DOB = Convert.ToDateTime("12/8/2005");
                c14.Address = "32 NE Garden Ln., Ste 910";
                c14.City = "Fairbanks";
                c14.State = "AK";
                c14.ZipCode = "99790";
                c14.PhoneNumber = "7355788965";
                c14.Email = "ahick@yaho.com";
                c14.UserName = "ahick@yaho.com";
                c14.Miles = 6000;
                c14.EmpType = "Customer";
                var result = UserManager.Create(c14, "hickhickup");
                db.SaveChanges();
                c14 = db.Users.First(u => u.UserName == "ahick@yaho.com");
            }
            UserManager.AddToRole(c14.Id, "Customer");
            AppUser c15 = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com");
            if (c15 == null)
            {
                c15 = new AppUser();
                c15.AdvantageNumber = 5015;
                c15.LastName = "Ingram";
                c15.FirstName = "Brad";
                c15.MI = "S.";
                c15.DOB = Convert.ToDateTime("9/5/2016");
                c15.Address = "6548 La Posada Ct.";
                c15.City = "Juneau";
                c15.State = "AK";
                c15.ZipCode = "99802";
                c15.PhoneNumber = "9074678821";
                c15.Email = "ingram@jack.com";
                c15.UserName = "ingram@jack.com";
                c15.Miles = 8000;
                c15.EmpType = "Customer";
                var result = UserManager.Create(c15, "ingram2015");
                db.SaveChanges();
                c15 = db.Users.First(u => u.UserName == "ingram@jack.com");
            }
            UserManager.AddToRole(c15.Id, "Customer");
            AppUser c16 = db.Users.FirstOrDefault(u => u.UserName == "toddj@yourmom.com");
            if (c16 == null)
            {
                c16 = new AppUser();
                c16.AdvantageNumber = 5016;
                c16.LastName = "Jacobs";
                c16.FirstName = "Todd";
                c16.MI = "L.";
                c16.DOB = Convert.ToDateTime("1/20/1999");
                c16.Address = "4564 Elm St.";
                c16.City = "Juneau";
                c16.State = "AK";
                c16.ZipCode = "99811";
                c16.PhoneNumber = "9074653365";
                c16.Email = "toddj@yourmom.com";
                c16.UserName = "toddj@yourmom.com";
                c16.Miles = 5000;
                c16.EmpType = "Customer";
                var result = UserManager.Create(c16, "toddy25");
                db.SaveChanges();
                c16 = db.Users.First(u => u.UserName == "toddj@yourmom.com");
            }
            UserManager.AddToRole(c16.Id, "Customer");
            AppUser c17 = db.Users.FirstOrDefault(u => u.UserName == "thequeen@aska.net");
            if (c17 == null)
            {
                c17 = new AppUser();
                c17.AdvantageNumber = 5017;
                c17.LastName = "Lawrence";
                c17.FirstName = "Victoria";
                c17.MI = "M.";
                c17.DOB = Convert.ToDateTime("4/14/2000");
                c17.Address = "6639 Butterfly Ln.";
                c17.City = "Juneau";
                c17.State = "AK";
                c17.ZipCode = "99803";
                c17.PhoneNumber = "9079457399";
                c17.Email = "thequeen@aska.net";
                c17.UserName = "thequeen@aska.net";
                c17.Miles = 0;
                c17.EmpType = "Customer";
                var result = UserManager.Create(c17, "something");
                db.SaveChanges();
                c17 = db.Users.First(u => u.UserName == "thequeen@aska.net");
            }
            UserManager.AddToRole(c17.Id, "Customer");
            AppUser c18 = db.Users.FirstOrDefault(u => u.UserName == "linebacker@gogle.com");
            if (c18 == null)
            {
                c18 = new AppUser();
                c18.AdvantageNumber = 5018;
                c18.LastName = "Lineback";
                c18.FirstName = "Erik";
                c18.MI = "W";
                c18.DOB = Convert.ToDateTime("12/2/2013");
                c18.Address = "1300 Netherland St";
                c18.City = "Anchorage";
                c18.State = "AK";
                c18.ZipCode = "99503";
                c18.PhoneNumber = "3032449976";
                c18.Email = "linebacker@gogle.com";
                c18.UserName = "linebacker@gogle.com";
                c18.Miles = 6000;
                c18.EmpType = "Customer";
                var result = UserManager.Create(c18, "Password1");
                db.SaveChanges();
                c18 = db.Users.First(u => u.UserName == "linebacker@gogle.com");
            }
            UserManager.AddToRole(c18.Id, "Customer");
            AppUser c19 = db.Users.FirstOrDefault(u => u.UserName == "elowe@netscare.net");
            if (c19 == null)
            {
                c19 = new AppUser();
                c19.AdvantageNumber = 5019;
                c19.LastName = "Lowe";
                c19.FirstName = "Ernest";
                c19.MI = "S";
                c19.DOB = Convert.ToDateTime("12/7/1977");
                c19.Address = "3201 Pine Drive";
                c19.City = "Anchorage";
                c19.State = "AK";
                c19.ZipCode = "99504";
                c19.PhoneNumber = "7135344627";
                c19.Email = "elowe@netscare.net";
                c19.UserName = "elowe@netscare.net";
                c19.Miles = 2000;
                c19.EmpType = "Customer";
                var result = UserManager.Create(c19, "aclfest2017");
                db.SaveChanges();
                c19 = db.Users.First(u => u.UserName == "elowe@netscare.net");
            }
            UserManager.AddToRole(c19.Id, "Customer");
            AppUser c20 = db.Users.FirstOrDefault(u => u.UserName == "cluce@gogle.com");
            if (c20 == null)
            {
                c20 = new AppUser();
                c20.AdvantageNumber = 5020;
                c20.LastName = "Luce";
                c20.FirstName = "Chuck";
                c20.MI = "B";
                c20.DOB = Convert.ToDateTime("3/16/1949");
                c20.Address = "2345 Rolling Clouds";
                c20.City = "Anchorage";
                c20.State = "AK";
                c20.ZipCode = "99501";
                c20.PhoneNumber = "9546983548";
                c20.Email = "cluce@gogle.com";
                c20.UserName = "cluce@gogle.com";
                c20.Miles = 8000;
                c20.EmpType = "Customer";
                var result = UserManager.Create(c20, "nothinggood");
                db.SaveChanges();
                c20 = db.Users.First(u => u.UserName == "cluce@gogle.com");
            }
            UserManager.AddToRole(c20.Id, "Customer");
            AppUser c21 = db.Users.FirstOrDefault(u => u.UserName == "mackcloud@george.com");
            if (c21 == null)
            {
                c21 = new AppUser();
                c21.AdvantageNumber = 5021;
                c21.LastName = "MacLeod";
                c21.FirstName = "Jennifer";
                c21.MI = "D.";
                c21.DOB = Convert.ToDateTime("2/21/1947");
                c21.Address = "2504 Far West Blvd.";
                c21.City = "Anchorage";
                c21.State = "AK";
                c21.ZipCode = "99502";
                c21.PhoneNumber = "9074748138";
                c21.Email = "mackcloud@george.com";
                c21.UserName = "mackcloud@george.com";
                c21.Miles = 5000;
                c21.EmpType = "Customer";
                var result = UserManager.Create(c21, "whatever");
                db.SaveChanges();
                c21 = db.Users.First(u => u.UserName == "mackcloud@george.com");
            }
            UserManager.AddToRole(c21.Id, "Customer");
            AppUser c22 = db.Users.FirstOrDefault(u => u.UserName == "cmartin@beets.com");
            if (c22 == null)
            {
                c22 = new AppUser();
                c22.AdvantageNumber = 5022;
                c22.LastName = "Markham";
                c22.FirstName = "Elizabeth";
                c22.MI = "P.";
                c22.DOB = Convert.ToDateTime("3/20/1972");
                c22.Address = "7861 Chevy Chase";
                c22.City = "Anchorage";
                c22.State = "AK";
                c22.ZipCode = "99503";
                c22.PhoneNumber = "9074579845";
                c22.Email = "cmartin@beets.com";
                c22.UserName = "cmartin@beets.com";
                c22.Miles = 7000;
                c22.EmpType = "Customer";
                var result = UserManager.Create(c22, "whocares");
                db.SaveChanges();
                c22 = db.Users.First(u => u.UserName == "cmartin@beets.com");
            }
            UserManager.AddToRole(c22.Id, "Customer");
            AppUser c23 = db.Users.FirstOrDefault(u => u.UserName == "clarence@yoho.com");
            if (c23 == null)
            {
                c23 = new AppUser();
                c23.AdvantageNumber = 5023;
                c23.LastName = "Martin";
                c23.FirstName = "Clarence";
                c23.MI = "A";
                c23.DOB = Convert.ToDateTime("7/19/1992");
                c23.Address = "87 Alcedo St.";
                c23.City = "San Diego";
                c23.State = "CA";
                c23.ZipCode = "82448";
                c23.PhoneNumber = "9204955201";
                c23.Email = "clarence@yoho.com";
                c23.UserName = "clarence@yoho.com";
                c23.Miles = 2000;
                c23.EmpType = "Customer";
                var result = UserManager.Create(c23, "xcellent");
                db.SaveChanges();
                c23 = db.Users.First(u => u.UserName == "clarence@yoho.com");
            }
            UserManager.AddToRole(c23.Id, "Customer");
            AppUser c24 = db.Users.FirstOrDefault(u => u.UserName == "gregmartinez@drdre.com");
            if (c24 == null)
            {
                c24 = new AppUser();
                c24.AdvantageNumber = 5024;
                c24.LastName = "Martinez";
                c24.FirstName = "Gregory";
                c24.MI = "R.";
                c24.DOB = Convert.ToDateTime("5/28/1947");
                c24.Address = "8295 Sunset Blvd.";
                c24.City = "Anchorage";
                c24.State = "AK";
                c24.ZipCode = "99501";
                c24.PhoneNumber = "9078746718";
                c24.Email = "gregmartinez@drdre.com";
                c24.UserName = "gregmartinez@drdre.com";
                c24.Miles = 1000;
                c24.EmpType = "Customer";
                var result = UserManager.Create(c24, "snowsnow");
                db.SaveChanges();
                c24 = db.Users.First(u => u.UserName == "gregmartinez@drdre.com");
            }
            UserManager.AddToRole(c24.Id, "Customer");
            AppUser c25 = db.Users.FirstOrDefault(u => u.UserName == "cmiller@bob.com");
            if (c25 == null)
            {
                c25 = new AppUser();
                c25.AdvantageNumber = 5025;
                c25.LastName = "Miller";
                c25.FirstName = "Charles";
                c25.MI = "R.";
                c25.DOB = Convert.ToDateTime("10/15/1990");
                c25.Address = "8962 Main St.";
                c25.City = "Anchorage";
                c25.State = "AK";
                c25.ZipCode = "99501";
                c25.PhoneNumber = "9077458615";
                c25.Email = "cmiller@bob.com";
                c25.UserName = "cmiller@bob.com";
                c25.Miles = 2000;
                c25.EmpType = "Customer";
                var result = UserManager.Create(c25, "mydogspot");
                db.SaveChanges();
                c25 = db.Users.First(u => u.UserName == "cmiller@bob.com");
            }
            UserManager.AddToRole(c25.Id, "Customer");
            AppUser c26 = db.Users.FirstOrDefault(u => u.UserName == "knelson@aoll.com");
            if (c26 == null)
            {
                c26 = new AppUser();
                c26.AdvantageNumber = 5026;
                c26.LastName = "Nelson";
                c26.FirstName = "Kelly";
                c26.MI = "T";
                c26.DOB = Convert.ToDateTime("7/13/1971");
                c26.Address = "2601 Red River";
                c26.City = "Juneau";
                c26.State = "AK";
                c26.ZipCode = "99811";
                c26.PhoneNumber = "9072926966";
                c26.Email = "knelson@aoll.com";
                c26.UserName = "knelson@aoll.com";
                c26.Miles = 0;
                c26.EmpType = "Customer";
                var result = UserManager.Create(c26, "spotmydog");
                db.SaveChanges();
                c26 = db.Users.First(u => u.UserName == "knelson@aoll.com");
            }
            UserManager.AddToRole(c26.Id, "Customer");
            AppUser c27 = db.Users.FirstOrDefault(u => u.UserName == "joewin@xfactor.com");
            if (c27 == null)
            {
                c27 = new AppUser();
                c27.AdvantageNumber = 5027;
                c27.LastName = "Nguyen";
                c27.FirstName = "Joe";
                c27.MI = "C";
                c27.DOB = Convert.ToDateTime("3/17/2008");
                c27.Address = "1249 4th SW St.";
                c27.City = "Anchorage";
                c27.State = "AK";
                c27.ZipCode = "99503";
                c27.PhoneNumber = "2023125897";
                c27.Email = "joewin@xfactor.com";
                c27.UserName = "joewin@xfactor.com";
                c27.Miles = 9000;
                c27.EmpType = "Customer";
                var result = UserManager.Create(c27, "joejoejoe");
                db.SaveChanges();
                c27 = db.Users.First(u => u.UserName == "joewin@xfactor.com");
            }
            UserManager.AddToRole(c27.Id, "Customer");
            AppUser c28 = db.Users.FirstOrDefault(u => u.UserName == "orielly@foxnews.cnn");
            if (c28 == null)
            {
                c28 = new AppUser();
                c28.AdvantageNumber = 5028;
                c28.LastName = "O'Reilly";
                c28.FirstName = "Bill";
                c28.MI = "T";
                c28.DOB = Convert.ToDateTime("7/8/1959");
                c28.Address = "8800 Gringo Drive";
                c28.City = "Anchorage";
                c28.State = "AK";
                c28.ZipCode = "99504";
                c28.PhoneNumber = "3173450925";
                c28.Email = "orielly@foxnews.cnn";
                c28.UserName = "orielly@foxnews.cnn";
                c28.Miles = 5000;
                c28.EmpType = "Customer";
                var result = UserManager.Create(c28, "billyboy");
                db.SaveChanges();
                c28 = db.Users.First(u => u.UserName == "orielly@foxnews.cnn");
            }
            UserManager.AddToRole(c28.Id, "Customer");
            AppUser c29 = db.Users.FirstOrDefault(u => u.UserName == "ankaisrad@gogle.com");
            if (c29 == null)
            {
                c29 = new AppUser();
                c29.AdvantageNumber = 5029;
                c29.LastName = "Radkovich";
                c29.FirstName = "Anka";
                c29.MI = "L";
                c29.DOB = Convert.ToDateTime("5/19/1966");
                c29.Address = "1300 Elliott Pl";
                c29.City = "Anchorage";
                c29.State = "AK";
                c29.ZipCode = "99501";
                c29.PhoneNumber = "3022345566";
                c29.Email = "ankaisrad@gogle.com";
                c29.UserName = "ankaisrad@gogle.com";
                c29.Miles = 0;
                c29.EmpType = "Customer";
                var result = UserManager.Create(c29, "radgirl");
                db.SaveChanges();
                c29 = db.Users.First(u => u.UserName == "ankaisrad@gogle.com");
            }
            UserManager.AddToRole(c29.Id, "Customer");
            AppUser c30 = db.Users.FirstOrDefault(u => u.UserName == "megrhodes@freserve.co.uk");
            if (c30 == null)
            {
                c30 = new AppUser();
                c30.AdvantageNumber = 5030;
                c30.LastName = "Rhodes";
                c30.FirstName = "Megan";
                c30.MI = "C.";
                c30.DOB = Convert.ToDateTime("3/12/1965");
                c30.Address = "4587 Enfield Rd.";
                c30.City = "Barrow";
                c30.State = "AK";
                c30.ZipCode = "99723";
                c30.PhoneNumber = "9073744746";
                c30.Email = "megrhodes@freserve.co.uk";
                c30.UserName = "megrhodes@freserve.co.uk";
                c30.Miles = 6000;
                c30.EmpType = "Customer";
                var result = UserManager.Create(c30, "meganr34");
                db.SaveChanges();
                c30 = db.Users.First(u => u.UserName == "megrhodes@freserve.co.uk");
            }
            UserManager.AddToRole(c30.Id, "Customer");
            AppUser c31 = db.Users.FirstOrDefault(u => u.UserName == "erynrice@aoll.com");
            if (c31 == null)
            {
                c31 = new AppUser();
                c31.AdvantageNumber = 5031;
                c31.LastName = "Rice";
                c31.FirstName = "Eryn";
                c31.MI = "M.";
                c31.DOB = Convert.ToDateTime("4/28/1975");
                c31.Address = "3405 Rio Grande";
                c31.City = "Anchorage";
                c31.State = "AK";
                c31.ZipCode = "99504";
                c31.PhoneNumber = "9073876657";
                c31.Email = "erynrice@aoll.com";
                c31.UserName = "erynrice@aoll.com";
                c31.Miles = 3000;
                c31.EmpType = "Customer";
                var result = UserManager.Create(c31, "ricearoni");
                db.SaveChanges();
                c31 = db.Users.First(u => u.UserName == "erynrice@aoll.com");
            }
            UserManager.AddToRole(c31.Id, "Customer");
            AppUser c32 = db.Users.FirstOrDefault(u => u.UserName == "jorge@noclue.com");
            if (c32 == null)
            {
                c32 = new AppUser();
                c32.AdvantageNumber = 5032;
                c32.LastName = "Rodriguez";
                c32.FirstName = "Jorge";
                c32.MI = "";
                c32.DOB = Convert.ToDateTime("12/8/1953");
                c32.Address = "6788 Cotter Street";
                c32.City = "Anchorage";
                c32.State = "AK";
                c32.ZipCode = "99501";
                c32.PhoneNumber = "4158904374";
                c32.Email = "jorge@noclue.com";
                c32.UserName = "jorge@noclue.com";
                c32.Miles = 5000;
                c32.EmpType = "Customer";
                var result = UserManager.Create(c32, "jrod2017");
                db.SaveChanges();
                c32 = db.Users.First(u => u.UserName == "jorge@noclue.com");
            }
            UserManager.AddToRole(c32.Id, "Customer");
            AppUser c33 = db.Users.FirstOrDefault(u => u.UserName == "mrrogers@lovelyday.com");
            if (c33 == null)
            {
                c33 = new AppUser();
                c33.AdvantageNumber = 5033;
                c33.LastName = "Rogers";
                c33.FirstName = "Allen";
                c33.MI = "B.";
                c33.DOB = Convert.ToDateTime("4/22/1973");
                c33.Address = "4965 Oak Hill";
                c33.City = "Barrow";
                c33.State = "AK";
                c33.ZipCode = "99723";
                c33.PhoneNumber = "9078752943";
                c33.Email = "mrrogers@lovelyday.com";
                c33.UserName = "mrrogers@lovelyday.com";
                c33.Miles = 8000;
                c33.EmpType = "Customer";
                var result = UserManager.Create(c33, "rogerthat");
                db.SaveChanges();
                c33 = db.Users.First(u => u.UserName == "mrrogers@lovelyday.com");
            }
            UserManager.AddToRole(c33.Id, "Customer");
            AppUser c34 = db.Users.FirstOrDefault(u => u.UserName == "stjean@athome.com");
            if (c34 == null)
            {
                c34 = new AppUser();
                c34.AdvantageNumber = 5034;
                c34.LastName = "Saint-Jean";
                c34.FirstName = "Olivier";
                c34.MI = "M";
                c34.DOB = Convert.ToDateTime("2/19/1995");
                c34.Address = "255 Toncray Dr.";
                c34.City = "Blacksburg";
                c34.State = "VA";
                c34.ZipCode = "24060";
                c34.PhoneNumber = "3434145678";
                c34.Email = "stjean@athome.com";
                c34.UserName = "stjean@athome.com";
                c34.Miles = 0;
                c34.EmpType = "Customer";
                var result = UserManager.Create(c34, "bunnyhop");
                db.SaveChanges();
                c34 = db.Users.First(u => u.UserName == "stjean@athome.com");
            }
            UserManager.AddToRole(c34.Id, "Customer");
            AppUser c35 = db.Users.FirstOrDefault(u => u.UserName == "saunders@pen.com");
            if (c35 == null)
            {
                c35 = new AppUser();
                c35.AdvantageNumber = 5035;
                c35.LastName = "Saunders";
                c35.FirstName = "Sarah";
                c35.MI = "J.";
                c35.DOB = Convert.ToDateTime("2/19/1978");
                c35.Address = "332 Avenue C";
                c35.City = "Anchorage";
                c35.State = "AK";
                c35.ZipCode = "99503";
                c35.PhoneNumber = "9073497810";
                c35.Email = "saunders@pen.com";
                c35.UserName = "saunders@pen.com";
                c35.Miles = 8000;
                c35.EmpType = "Customer";
                var result = UserManager.Create(c35, "penguin12");
                db.SaveChanges();
                c35 = db.Users.First(u => u.UserName == "saunders@pen.com");
            }
            UserManager.AddToRole(c35.Id, "Customer");
            AppUser c36 = db.Users.FirstOrDefault(u => u.UserName == "willsheff@email.com");
            if (c36 == null)
            {
                c36 = new AppUser();
                c36.AdvantageNumber = 5036;
                c36.LastName = "Sewell";
                c36.FirstName = "William";
                c36.MI = "T.";
                c36.DOB = Convert.ToDateTime("12/23/2014");
                c36.Address = "2365 51st St.";
                c36.City = "Barrow";
                c36.State = "AK";
                c36.ZipCode = "99723";
                c36.PhoneNumber = "9074510084";
                c36.Email = "willsheff@email.com";
                c36.UserName = "willsheff@email.com";
                c36.Miles = 8000;
                c36.EmpType = "Customer";
                var result = UserManager.Create(c36, "alaskaboy");
                db.SaveChanges();
                c36 = db.Users.First(u => u.UserName == "willsheff@email.com");
            }
            UserManager.AddToRole(c36.Id, "Customer");
            AppUser c37 = db.Users.FirstOrDefault(u => u.UserName == "sheffiled@gogle.com");
            if (c37 == null)
            {
                c37 = new AppUser();
                c37.AdvantageNumber = 5037;
                c37.LastName = "Sheffield";
                c37.FirstName = "Martin";
                c37.MI = "J.";
                c37.DOB = Convert.ToDateTime("5/8/1960");
                c37.Address = "3886 Avenue A";
                c37.City = "Anchorage";
                c37.State = "AK";
                c37.ZipCode = "99503";
                c37.PhoneNumber = "9075479167";
                c37.Email = "sheffiled@gogle.com";
                c37.UserName = "sheffiled@gogle.com";
                c37.Miles = 0;
                c37.EmpType = "Customer";
                var result = UserManager.Create(c37, "martin1234");
                db.SaveChanges();
                c37 = db.Users.First(u => u.UserName == "sheffiled@gogle.com");
            }
            UserManager.AddToRole(c37.Id, "Customer");
            AppUser c38 = db.Users.FirstOrDefault(u => u.UserName == "johnsmith187@aoll.com");
            if (c38 == null)
            {
                c38 = new AppUser();
                c38.AdvantageNumber = 5038;
                c38.LastName = "Smith";
                c38.FirstName = "John";
                c38.MI = "A";
                c38.DOB = Convert.ToDateTime("6/25/1955");
                c38.Address = "23 Hidden Forge Dr.";
                c38.City = "Fayetteville";
                c38.State = "NC";
                c38.ZipCode = "28304";
                c38.PhoneNumber = "2838321888";
                c38.Email = "johnsmith187@aoll.com";
                c38.UserName = "johnsmith187@aoll.com";
                c38.Miles = 3000;
                c38.EmpType = "Customer";
                var result = UserManager.Create(c38, "smitty444");
                db.SaveChanges();
                c38 = db.Users.First(u => u.UserName == "johnsmith187@aoll.com");
            }
            UserManager.AddToRole(c38.Id, "Customer");
            AppUser c39 = db.Users.FirstOrDefault(u => u.UserName == "dustroud@mail.com");
            if (c39 == null)
            {
                c39 = new AppUser();
                c39.AdvantageNumber = 5039;
                c39.LastName = "Stroud";
                c39.FirstName = "Dustin";
                c39.MI = "P";
                c39.DOB = Convert.ToDateTime("7/26/1967");
                c39.Address = "1212 Rita Rd";
                c39.City = "Springfield";
                c39.State = "IL";
                c39.ZipCode = "62707";
                c39.PhoneNumber = "2172346667";
                c39.Email = "dustroud@mail.com";
                c39.UserName = "dustroud@mail.com";
                c39.Miles = 6000;
                c39.EmpType = "Customer";
                var result = UserManager.Create(c39, "dustydusty");
                db.SaveChanges();
                c39 = db.Users.First(u => u.UserName == "dustroud@mail.com");
            }
            UserManager.AddToRole(c39.Id, "Customer");
            AppUser c40 = db.Users.FirstOrDefault(u => u.UserName == "estuart@anchor.net");
            if (c40 == null)
            {
                c40 = new AppUser();
                c40.AdvantageNumber = 5040;
                c40.LastName = "Stuart";
                c40.FirstName = "Eric";
                c40.MI = "D.";
                c40.DOB = Convert.ToDateTime("12/4/1947");
                c40.Address = "5576 Toro Ring";
                c40.City = "Anchorage";
                c40.State = "AK";
                c40.ZipCode = "99502";
                c40.PhoneNumber = "9078178335";
                c40.Email = "estuart@anchor.net";
                c40.UserName = "estuart@anchor.net";
                c40.Miles = 0;
                c40.EmpType = "Customer";
                var result = UserManager.Create(c40, "stewball");
                db.SaveChanges();
                c40 = db.Users.First(u => u.UserName == "estuart@anchor.net");
            }
            UserManager.AddToRole(c40.Id, "Customer");
            AppUser c41 = db.Users.FirstOrDefault(u => u.UserName == "peterstump@noclue.com");
            if (c41 == null)
            {
                c41 = new AppUser();
                c41.AdvantageNumber = 5041;
                c41.LastName = "Stump";
                c41.FirstName = "Peter";
                c41.MI = "L";
                c41.DOB = Convert.ToDateTime("7/10/1974");
                c41.Address = "1300 Kellen Circle";
                c41.City = "Anchorage";
                c41.State = "AK";
                c41.ZipCode = "99503";
                c41.PhoneNumber = "2084560903";
                c41.Email = "peterstump@noclue.com";
                c41.UserName = "peterstump@noclue.com";
                c41.Miles = 2000;
                c41.EmpType = "Customer";
                var result = UserManager.Create(c41, "slowwind");
                db.SaveChanges();
                c41 = db.Users.First(u => u.UserName == "peterstump@noclue.com");
            }
            UserManager.AddToRole(c41.Id, "Customer");
            AppUser c42 = db.Users.FirstOrDefault(u => u.UserName == "jtanner@mustang.net");
            if (c42 == null)
            {
                c42 = new AppUser();
                c42.AdvantageNumber = 5042;
                c42.LastName = "Tanner";
                c42.FirstName = "Jeremy";
                c42.MI = "S.";
                c42.DOB = Convert.ToDateTime("1/11/1944");
                c42.Address = "4347 Almstead";
                c42.City = "Anchorage";
                c42.State = "AK";
                c42.ZipCode = "99504";
                c42.PhoneNumber = "9074590929";
                c42.Email = "jtanner@mustang.net";
                c42.UserName = "jtanner@mustang.net";
                c42.Miles = 5000;
                c42.EmpType = "Customer";
                var result = UserManager.Create(c42, "tanner5454");
                db.SaveChanges();
                c42 = db.Users.First(u => u.UserName == "jtanner@mustang.net");
            }
            UserManager.AddToRole(c42.Id, "Customer");
            AppUser c43 = db.Users.FirstOrDefault(u => u.UserName == "taylordjay@aoll.com");
            if (c43 == null)
            {
                c43 = new AppUser();
                c43.AdvantageNumber = 5043;
                c43.LastName = "Taylor";
                c43.FirstName = "Allison";
                c43.MI = "R.";
                c43.DOB = Convert.ToDateTime("11/14/1990");
                c43.Address = "467 Nueces St.";
                c43.City = "Anchorage";
                c43.State = "AK";
                c43.ZipCode = "99501";
                c43.PhoneNumber = "9074748452";
                c43.Email = "taylordjay@aoll.com";
                c43.UserName = "taylordjay@aoll.com";
                c43.Miles = 0;
                c43.EmpType = "Customer";
                var result = UserManager.Create(c43, "allyrally");
                db.SaveChanges();
                c43 = db.Users.First(u => u.UserName == "taylordjay@aoll.com");
            }
            UserManager.AddToRole(c43.Id, "Customer");
            AppUser c44 = db.Users.FirstOrDefault(u => u.UserName == "rtaylor@gogle.com");
            if (c44 == null)
            {
                c44 = new AppUser();
                c44.AdvantageNumber = 5044;
                c44.LastName = "Taylor";
                c44.FirstName = "Rachel";
                c44.MI = "K.";
                c44.DOB = Convert.ToDateTime("1/18/1976");
                c44.Address = "345 Longview Dr.";
                c44.City = "Anchorage";
                c44.State = "AK";
                c44.ZipCode = "99501";
                c44.PhoneNumber = "9074907631";
                c44.Email = "rtaylor@gogle.com";
                c44.UserName = "rtaylor@gogle.com";
                c44.Miles = 10000;
                c44.EmpType = "Customer";
                var result = UserManager.Create(c44, "taylorbaylor");
                db.SaveChanges();
                c44 = db.Users.First(u => u.UserName == "rtaylor@gogle.com");
            }
            UserManager.AddToRole(c44.Id, "Customer");
            AppUser c45 = db.Users.FirstOrDefault(u => u.UserName == "teefrank@noclue.com");
            if (c45 == null)
            {
                c45 = new AppUser();
                c45.AdvantageNumber = 5045;
                c45.LastName = "Tee";
                c45.FirstName = "Frank";
                c45.MI = "J";
                c45.DOB = Convert.ToDateTime("9/6/1998");
                c45.Address = "5590 Lavell Dr";
                c45.City = "Anchorage";
                c45.State = "AK";
                c45.ZipCode = "99502";
                c45.PhoneNumber = "2138765543";
                c45.Email = "teefrank@noclue.com";
                c45.UserName = "teefrank@noclue.com";
                c45.Miles = 0;
                c45.EmpType = "Customer";
                var result = UserManager.Create(c45, "teeoff22");
                db.SaveChanges();
                c45 = db.Users.First(u => u.UserName == "teefrank@noclue.com");
            }
            UserManager.AddToRole(c45.Id, "Customer");
            AppUser c46 = db.Users.FirstOrDefault(u => u.UserName == "ctucker@alphabet.co.uk");
            if (c46 == null)
            {
                c46 = new AppUser();
                c46.AdvantageNumber = 5046;
                c46.LastName = "Tucker";
                c46.FirstName = "Clent";
                c46.MI = "J";
                c46.DOB = Convert.ToDateTime("2/25/1943");
                c46.Address = "312 Main St.";
                c46.City = "Anchorage";
                c46.State = "AK";
                c46.ZipCode = "99503";
                c46.PhoneNumber = "9038471154";
                c46.Email = "ctucker@alphabet.co.uk";
                c46.UserName = "ctucker@alphabet.co.uk";
                c46.Miles = 7000;
                c46.EmpType = "Customer";
                var result = UserManager.Create(c46, "tucksack1");
                db.SaveChanges();
                c46 = db.Users.First(u => u.UserName == "ctucker@alphabet.co.uk");
            }
            UserManager.AddToRole(c46.Id, "Customer");
            AppUser c47 = db.Users.FirstOrDefault(u => u.UserName == "avelasco@yoho.com");
            if (c47 == null)
            {
                c47 = new AppUser();
                c47.AdvantageNumber = 5047;
                c47.LastName = "Velasco";
                c47.FirstName = "Allen";
                c47.MI = "G";
                c47.DOB = Convert.ToDateTime("9/10/1985");
                c47.Address = "679 W. 4th";
                c47.City = "Juneau";
                c47.State = "AK";
                c47.ZipCode = "99801";
                c47.PhoneNumber = "3103985638";
                c47.Email = "avelasco@yoho.com";
                c47.UserName = "avelasco@yoho.com";
                c47.Miles = 8000;
                c47.EmpType = "Customer";
                var result = UserManager.Create(c47, "meow88");
                db.SaveChanges();
                c47 = db.Users.First(u => u.UserName == "avelasco@yoho.com");
            }
            UserManager.AddToRole(c47.Id, "Customer");
            AppUser c48 = db.Users.FirstOrDefault(u => u.UserName == "vinovino@grapes.com");
            if (c48 == null)
            {
                c48 = new AppUser();
                c48.AdvantageNumber = 5048;
                c48.LastName = "Vino";
                c48.FirstName = "Janet";
                c48.MI = "E";
                c48.DOB = Convert.ToDateTime("2/7/1985");
                c48.Address = "189 Grape Road";
                c48.City = "Juneau";
                c48.State = "AK";
                c48.ZipCode = "99802";
                c48.PhoneNumber = "8175643832";
                c48.Email = "vinovino@grapes.com";
                c48.UserName = "vinovino@grapes.com";
                c48.Miles = 0;
                c48.EmpType = "Customer";
                var result = UserManager.Create(c48, "vinovino");
                db.SaveChanges();
                c48 = db.Users.First(u => u.UserName == "vinovino@grapes.com");
            }
            UserManager.AddToRole(c48.Id, "Customer");
            AppUser c49 = db.Users.FirstOrDefault(u => u.UserName == "westj@pioneer.net");
            if (c49 == null)
            {
                c49 = new AppUser();
                c49.AdvantageNumber = 5049;
                c49.LastName = "West";
                c49.FirstName = "Jake";
                c49.MI = "T";
                c49.DOB = Convert.ToDateTime("1/9/1976");
                c49.Address = "RR 3287";
                c49.City = "Juneau";
                c49.State = "AK";
                c49.ZipCode = "99811";
                c49.PhoneNumber = "5938475244";
                c49.Email = "westj@pioneer.net";
                c49.UserName = "westj@pioneer.net";
                c49.Miles = 8000;
                c49.EmpType = "Customer";
                var result = UserManager.Create(c49, "gowest");
                db.SaveChanges();
                c49 = db.Users.First(u => u.UserName == "westj@pioneer.net");
            }
            UserManager.AddToRole(c49.Id, "Customer");
            AppUser c50 = db.Users.FirstOrDefault(u => u.UserName == "winner@hootmail.com");
            if (c50 == null)
            {
                c50 = new AppUser();
                c50.AdvantageNumber = 5050;
                c50.LastName = "Winthorpe";
                c50.FirstName = "Louis";
                c50.MI = "L";
                c50.DOB = Convert.ToDateTime("4/19/1953");
                c50.Address = "2500 Padre Blvd";
                c50.City = "Juneau";
                c50.State = "AK";
                c50.ZipCode = "99803";
                c50.PhoneNumber = "2105650098";
                c50.Email = "winner@hootmail.com";
                c50.UserName = "winner@hootmail.com";
                c50.Miles = 6000;
                c50.EmpType = "Customer";
                var result = UserManager.Create(c50, "louielouie");
                db.SaveChanges();
                c50 = db.Users.First(u => u.UserName == "winner@hootmail.com");
            }
            UserManager.AddToRole(c50.Id, "Customer");
            AppUser c51 = db.Users.FirstOrDefault(u => u.UserName == "rwood@voyager.net");
            if (c51 == null)
            {
                c51 = new AppUser();
                c51.AdvantageNumber = 5051;
                c51.LastName = "Wood";
                c51.FirstName = "Reagan";
                c51.MI = "B.";
                c51.DOB = Convert.ToDateTime("12/28/2002");
                c51.Address = "447 Westlake Dr.";
                c51.City = "Fairbanks";
                c51.State = "AK";
                c51.ZipCode = "99790";
                c51.PhoneNumber = "9074545242";
                c51.Email = "rwood@voyager.net";
                c51.UserName = "rwood@voyager.net";
                c51.Miles = 0;
                c51.EmpType = "Customer";
                var result = UserManager.Create(c51, "woodyman1");
                db.SaveChanges();
                c51 = db.Users.First(u => u.UserName == "rwood@voyager.net");
            }
            UserManager.AddToRole(c51.Id, "Customer");

            AppUser c52 = db.Users.FirstOrDefault(u => u.UserName == "t.jacobs@penguinairlines.neet");
            if (c52 == null)
            {
                c52 = new AppUser();
                c52.AdvantageNumber = 0;
                c52.LastName = "Jacobs";
                c52.FirstName = "Todd";
                c52.MI = "L";
                c52.DOB = Convert.ToDateTime("1/1/1900");
                c52.SSN = "341553365";
                c52.Miles = 0;
                c52.EmpType = "Agent";
                c52.Address = "4564 Elm St.";
                c52.City = "Anchorage";
                c52.State = "AK";
                c52.ZipCode = "99501";
                c52.PhoneNumber = "9074653365";
                c52.Email = "t.jacobs@penguinairlines.neet";
                c52.UserName = "t.jacobs@penguinairlines.neet";

                var result = UserManager.Create(c52, "society");
                db.SaveChanges();
                c52 = db.Users.First(u => u.UserName == "t.jacobs@penguinairlines.neet");
            }
            UserManager.AddToRole(c52.Id, "Agent");
            AppUser c53 = db.Users.FirstOrDefault(u => u.UserName == "e.rice@penguinairlines.neet");
            if (c53 == null)
            {
                c53 = new AppUser();
                c53.AdvantageNumber = 0;
                c53.LastName = "Rice";
                c53.FirstName = "Eryn";
                c53.MI = "M";
                c53.DOB = Convert.ToDateTime("1/1/1900");
                c53.SSN = "454776657";
                c53.Miles = 0;
                c53.EmpType = "Manager";
                c53.Address = "3405 Rio Grande";
                c53.City = "Anchorage";
                c53.State = "AK";
                c53.ZipCode = "99502";
                c53.PhoneNumber = "9073876657";
                c53.Email = "e.rice@penguinairlines.neet";
                c53.UserName = "e.rice@penguinairlines.neet";

                var result = UserManager.Create(c53, "ricearoni");
                db.SaveChanges();
                c53 = db.Users.First(u => u.UserName == "e.rice@penguinairlines.neet");
            }
            UserManager.AddToRole(c53.Id, "Manager");
            AppUser c54 = db.Users.FirstOrDefault(u => u.UserName == "b.ingram@penguinairlines.neet");
            if (c54 == null)
            {
                c54 = new AppUser();
                c54.AdvantageNumber = 0;
                c54.LastName = "Ingram";
                c54.FirstName = "Brad";
                c54.MI = "S";
                c54.DOB = Convert.ToDateTime("1/1/1900");
                c54.SSN = "797348821";
                c54.Miles = 0;
                c54.EmpType = "Pilot";
                c54.Address = "6548 La Posada Ct.";
                c54.City = "Anchorage";
                c54.State = "AK";
                c54.ZipCode = "99501";
                c54.PhoneNumber = "9074678821";
                c54.Email = "b.ingram@penguinairlines.neet";
                c54.UserName = "b.ingram@penguinairlines.neet";

                var result = UserManager.Create(c54, "ingram45");
                db.SaveChanges();
                c54 = db.Users.First(u => u.UserName == "b.ingram@penguinairlines.neet");
            }
            UserManager.AddToRole(c54.Id, "Pilot");
            AppUser c55 = db.Users.FirstOrDefault(u => u.UserName == "a.taylor@penguinairlines.neet");
            if (c55 == null)
            {
                c55 = new AppUser();
                c55.AdvantageNumber = 0;
                c55.LastName = "Taylor";
                c55.FirstName = "Allison";
                c55.MI = "R";
                c55.DOB = Convert.ToDateTime("1/1/1900");
                c55.SSN = "934778452";
                c55.Miles = 0;
                c55.EmpType = "Agent";
                c55.Address = "467 Nueces St.";
                c55.City = "Anchorage";
                c55.State = "AK";
                c55.ZipCode = "99504";
                c55.PhoneNumber = "9074748452";
                c55.Email = "a.taylor@penguinairlines.neet";
                c55.UserName = "a.taylor@penguinairlines.neet";

                var result = UserManager.Create(c55, "nostalgic");
                db.SaveChanges();
                c55 = db.Users.First(u => u.UserName == "a.taylor@penguinairlines.neet");
            }
            UserManager.AddToRole(c55.Id, "Agent");
            AppUser c56 = db.Users.FirstOrDefault(u => u.UserName == "g.martinez@penguinairlines.neet");
            if (c56 == null)
            {
                c56 = new AppUser();
                c56.AdvantageNumber = 0;
                c56.LastName = "Martinez";
                c56.FirstName = "Gregory";
                c56.MI = "R";
                c56.DOB = Convert.ToDateTime("1/1/1900");
                c56.SSN = "463566718";
                c56.Miles = 0;
                c56.EmpType = "Co-Pilot";
                c56.Address = "8295 Sunset Blvd.";
                c56.City = "Barrow";
                c56.State = "AK";
                c56.ZipCode = "99723";
                c56.PhoneNumber = "9078746718";
                c56.Email = "g.martinez@penguinairlines.neet";
                c56.UserName = "g.martinez@penguinairlines.neet";

                var result = UserManager.Create(c56, "fungus");
                db.SaveChanges();
                c56 = db.Users.First(u => u.UserName == "g.martinez@penguinairlines.neet");
            }
            UserManager.AddToRole(c56.Id, "Co Pilot");
            AppUser c57 = db.Users.FirstOrDefault(u => u.UserName == "m.sheffield@penguinairlines.neet");
            if (c57 == null)
            {
                c57 = new AppUser();
                c57.AdvantageNumber = 0;
                c57.LastName = "Sheffield";
                c57.FirstName = "Martin";
                c57.MI = "J";
                c57.DOB = Convert.ToDateTime("1/1/1900");
                c57.SSN = "223449167";
                c57.Miles = 0;
                c57.EmpType = "Agent";
                c57.Address = "3886 Avenue A";
                c57.City = "Anchorage";
                c57.State = "AK";
                c57.ZipCode = "99502";
                c57.PhoneNumber = "9075479167";
                c57.Email = "m.sheffield@penguinairlines.neet";
                c57.UserName = "m.sheffield@penguinairlines.neet";

                var result = UserManager.Create(c57, "longhorns");
                db.SaveChanges();
                c57 = db.Users.First(u => u.UserName == "m.sheffield@penguinairlines.neet");
            }
            UserManager.AddToRole(c57.Id, "Agent");
            AppUser c58 = db.Users.FirstOrDefault(u => u.UserName == "j.macleod@penguinairlines.neet");
            if (c58 == null)
            {
                c58 = new AppUser();
                c58.AdvantageNumber = 0;
                c58.LastName = "MacLeod";
                c58.FirstName = "Jennifer";
                c58.MI = "D";
                c58.DOB = Convert.ToDateTime("1/1/1900");
                c58.SSN = "775908138";
                c58.Miles = 0;
                c58.EmpType = "Agent";
                c58.Address = "2504 Far West Blvd.";
                c58.City = "Anchorage";
                c58.State = "AK";
                c58.ZipCode = "99503";
                c58.PhoneNumber = "9074748138";
                c58.Email = "j.macleod@penguinairlines.neet";
                c58.UserName = "j.macleod@penguinairlines.neet";

                var result = UserManager.Create(c58, "smitty");
                db.SaveChanges();
                c58 = db.Users.First(u => u.UserName == "j.macleod@penguinairlines.neet");
            }
            UserManager.AddToRole(c58.Id, "Agent");
            AppUser c59 = db.Users.FirstOrDefault(u => u.UserName == "j.tanner@penguinairlines.neet");
            if (c59 == null)
            {
                c59 = new AppUser();
                c59.AdvantageNumber = 0;
                c59.LastName = "Tanner";
                c59.FirstName = "Jeremy";
                c59.MI = "S";
                c59.DOB = Convert.ToDateTime("1/1/1900");
                c59.SSN = "904440929";
                c59.Miles = 0;
                c59.EmpType = "Agent";
                c59.Address = "4347 Almstead";
                c59.City = "Barrow";
                c59.State = "AK";
                c59.ZipCode = "99723";
                c59.PhoneNumber = "9074590929";
                c59.Email = "j.tanner@penguinairlines.neet";
                c59.UserName = "j.tanner@penguinairlines.neet";

                var result = UserManager.Create(c59, "tanman");
                db.SaveChanges();
                c59 = db.Users.First(u => u.UserName == "j.tanner@penguinairlines.neet");
            }
            UserManager.AddToRole(c59.Id, "Agent");
            AppUser c60 = db.Users.FirstOrDefault(u => u.UserName == "m.rhodes@penguinairlines.neet");
            if (c60 == null)
            {
                c60 = new AppUser();
                c60.AdvantageNumber = 0;
                c60.LastName = "Rhodes";
                c60.FirstName = "Megan";
                c60.MI = "C";
                c60.DOB = Convert.ToDateTime("1/1/1900");
                c60.SSN = "353904746";
                c60.Miles = 0;
                c60.EmpType = "Cabin Crew";
                c60.Address = "4587 Enfield Rd.";
                c60.City = "Anchorage";
                c60.State = "AK";
                c60.ZipCode = "99503";
                c60.PhoneNumber = "9073744746";
                c60.Email = "m.rhodes@penguinairlines.neet";
                c60.UserName = "m.rhodes@penguinairlines.neet";

                var result = UserManager.Create(c60, "countryrhodes");
                db.SaveChanges();
                c60 = db.Users.First(u => u.UserName == "m.rhodes@penguinairlines.neet");
            }
             UserManager.AddToRole(c60.Id, "Cabin Crew");
            AppUser c61 = db.Users.FirstOrDefault(u => u.UserName == "e.stuart@penguinairlines.neet");
            if (c61 == null)
            {
                c61 = new AppUser();
                c61.AdvantageNumber = 0;
                c61.LastName = "Stuart";
                c61.FirstName = "Eric";
                c61.MI = "F";
                c61.DOB = Convert.ToDateTime("1/1/1900");
                c61.SSN = "363998335";
                c61.Miles = 0;
                c61.EmpType = "Agent";
                c61.Address = "5576 Toro Ring";
                c61.City = "Anchorage";
                c61.State = "AK";
                c61.ZipCode = "99501";
                c61.PhoneNumber = "9078178335";
                c61.Email = "e.stuart@penguinairlines.neet";
                c61.UserName = "e.stuart@penguinairlines.neet";

                var result = UserManager.Create(c61, "stewboy");
                db.SaveChanges();
                c61 = db.Users.First(u => u.UserName == "e.stuart@penguinairlines.neet");
            }
            UserManager.AddToRole(c61.Id, "Agent");
            AppUser c62 = db.Users.FirstOrDefault(u => u.UserName == "c.miller@penguinairlines.neet");
            if (c62 == null)
            {
                c62 = new AppUser();
                c62.AdvantageNumber = 0;
                c62.LastName = "Miller";
                c62.FirstName = "Charles";
                c62.MI = "R";
                c62.DOB = Convert.ToDateTime("1/1/1900");
                c62.SSN = "353308615";
                c62.Miles = 0;
                c62.EmpType = "Agent";
                c62.Address = "8962 Main St.";
                c62.City = "Barrow";
                c62.State = "AK";
                c62.ZipCode = "99723";
                c62.PhoneNumber = "9077458615";
                c62.Email = "c.miller@penguinairlines.neet";
                c62.UserName = "c.miller@penguinairlines.neet";

                var result = UserManager.Create(c62, "squirrel");
                db.SaveChanges();
                c62 = db.Users.First(u => u.UserName == "c.miller@penguinairlines.neet");
            }
            UserManager.AddToRole(c62.Id, "Agent");
            AppUser c63 = db.Users.FirstOrDefault(u => u.UserName == "r.taylor@penguinairlines.neet");
            if (c63 == null)
            {
                c63 = new AppUser();
                c63.AdvantageNumber = 0;
                c63.LastName = "Taylor";
                c63.FirstName = "Rachel";
                c63.MI = "O";
                c63.DOB = Convert.ToDateTime("1/1/1900");
                c63.SSN = "393412631";
                c63.Miles = 0;
                c63.EmpType = "Manager";
                c63.Address = "345 Longview Dr.";
                c63.City = "Anchorage";
                c63.State = "AK";
                c63.ZipCode = "99501";
                c63.PhoneNumber = "9074512631";
                c63.Email = "r.taylor@penguinairlines.neet";
                c63.UserName = "r.taylor@penguinairlines.neet";

                var result = UserManager.Create(c63, "swansong");
                db.SaveChanges();
                c63 = db.Users.First(u => u.UserName == "r.taylor@penguinairlines.neet");
            }
            UserManager.AddToRole(c63.Id, "Manager");
            AppUser c64 = db.Users.FirstOrDefault(u => u.UserName == "v.lawrence@penguinairlines.neet");
            if (c64 == null)
            {
                c64 = new AppUser();
                c64.AdvantageNumber = 0;
                c64.LastName = "Lawrence";
                c64.FirstName = "Victoria";
                c64.MI = "Y";
                c64.DOB = Convert.ToDateTime("1/1/1900");
                c64.SSN = "770097399";
                c64.Miles = 0;
                c64.EmpType = "Agent";
                c64.Address = "6639 Butterfly Ln.";
                c64.City = "Anchorage";
                c64.State = "AK";
                c64.ZipCode = "99501";
                c64.PhoneNumber = "9079457399";
                c64.Email = "v.lawrence@penguinairlines.neet";
                c64.UserName = "v.lawrence@penguinairlines.neet";

                var result = UserManager.Create(c64, "lottery");
                db.SaveChanges();
                c64 = db.Users.First(u => u.UserName == "v.lawrence@penguinairlines.neet");
            }
            UserManager.AddToRole(c64.Id, "Agent");
            AppUser c65 = db.Users.FirstOrDefault(u => u.UserName == "a.rogers@penguinairlines.neet");
            if (c65 == null)
            {
                c65 = new AppUser();
                c65.AdvantageNumber = 0;
                c65.LastName = "Rogers";
                c65.FirstName = "Allen";
                c65.MI = "H";
                c65.DOB = Convert.ToDateTime("1/1/1900");
                c65.SSN = "700002943";
                c65.Miles = 0;
                c65.EmpType = "Manager";
                c65.Address = "4965 Oak Hill";
                c65.City = "Anchorage";
                c65.State = "AK";
                c65.ZipCode = "99502";
                c65.PhoneNumber = "9078752943";
                c65.Email = "a.rogers@penguinairlines.neet";
                c65.UserName = "a.rogers@penguinairlines.neet";

                var result = UserManager.Create(c65, "evanescent");
                db.SaveChanges();
                c65 = db.Users.First(u => u.UserName == "a.rogers@penguinairlines.neet");
            }
            UserManager.AddToRole(c65.Id, "Manager");
            AppUser c66 = db.Users.FirstOrDefault(u => u.UserName == "e.markham@penguinairlines.neet");
            if (c66 == null)
            {
                c66 = new AppUser();
                c66.AdvantageNumber = 0;
                c66.LastName = "Markham";
                c66.FirstName = "Elizabeth";
                c66.MI = "K";
                c66.DOB = Convert.ToDateTime("1/1/1900");
                c66.SSN = "101529845";
                c66.Miles = 0;
                c66.EmpType = "Agent";
                c66.Address = "7861 Chevy Chase";
                c66.City = "Anchorage";
                c66.State = "AK";
                c66.ZipCode = "99502";
                c66.PhoneNumber = "9074579845";
                c66.Email = "e.markham@penguinairlines.neet";
                c66.UserName = "e.markham@penguinairlines.neet";

                var result = UserManager.Create(c66, "monty3");
                db.SaveChanges();
                c66 = db.Users.First(u => u.UserName == "e.markham@penguinairlines.neet");
            }
            UserManager.AddToRole(c66.Id, "Agent");
            AppUser c67 = db.Users.FirstOrDefault(u => u.UserName == "c.baker@penguinairlines.neet");
            if (c67 == null)
            {
                c67 = new AppUser();
                c67.AdvantageNumber = 0;
                c67.LastName = "Baker";
                c67.FirstName = "Christopher";
                c67.MI = "E";
                c67.DOB = Convert.ToDateTime("1/1/1900");
                c67.SSN = "401661146";
                c67.Miles = 0;
                c67.EmpType = "Cabin Crew";
                c67.Address = "1245 Lake Anchorage Blvd.";
                c67.City = "Anchorage";
                c67.State = "AK";
                c67.ZipCode = "99501";
                c67.PhoneNumber = "9075571146";
                c67.Email = "c.baker@penguinairlines.neet";
                c67.UserName = "c.baker@penguinairlines.neet";

                var result = UserManager.Create(c67, "hecktour");
                db.SaveChanges();
                c67 = db.Users.First(u => u.UserName == "c.baker@penguinairlines.neet");
            }
            UserManager.AddToRole(c67.Id, "Cabin Crew");
            AppUser c68 = db.Users.FirstOrDefault(u => u.UserName == "s.saunders@penguinairlines.neet");
            if (c68 == null)
            {
                c68 = new AppUser();
                c68.AdvantageNumber = 0;
                c68.LastName = "Saunders";
                c68.FirstName = "Sarah";
                c68.MI = "M";
                c68.DOB = Convert.ToDateTime("1/1/1900");
                c68.SSN = "500987810";
                c68.Miles = 0;
                c68.EmpType = "Agent";
                c68.Address = "332 Avenue C";
                c68.City = "Anchorage";
                c68.State = "AK";
                c68.ZipCode = "99504";
                c68.PhoneNumber = "9073497810";
                c68.Email = "s.saunders@penguinairlines.neet";
                c68.UserName = "s.saunders@penguinairlines.neet";

                var result = UserManager.Create(c68, "rankmary");
                db.SaveChanges();
                c68 = db.Users.First(u => u.UserName == "s.saunders@penguinairlines.neet");
            }
            UserManager.AddToRole(c68.Id, "Agent");
            AppUser c69 = db.Users.FirstOrDefault(u => u.UserName == "w.sewell@penguinairlines.neet");
            if (c69 == null)
            {
                c69 = new AppUser();
                c69.AdvantageNumber = 0;
                c69.LastName = "Sewell";
                c69.FirstName = "William";
                c69.MI = "G";
                c69.DOB = Convert.ToDateTime("1/1/1900");
                c69.SSN = "500830084";
                c69.Miles = 0;
                c69.EmpType = "Manager";
                c69.Address = "2365 51st St.";
                c69.City = "Anchorage";
                c69.State = "AK";
                c69.ZipCode = "99504";
                c69.PhoneNumber = "9074510084";
                c69.Email = "w.sewell@penguinairlines.neet";
                c69.UserName = "w.sewell@penguinairlines.neet";

                var result = UserManager.Create(c69, "walkamile");
                db.SaveChanges();
                c69 = db.Users.First(u => u.UserName == "w.sewell@penguinairlines.neet");
            }
            UserManager.AddToRole(c69.Id, "Manager");
            AppUser c70 = db.Users.FirstOrDefault(u => u.UserName == "j.mason@penguinairlines.neet");
            if (c70 == null)
            {
                c70 = new AppUser();
                c70.AdvantageNumber = 0;
                c70.LastName = "Mason";
                c70.FirstName = "Jack";
                c70.MI = "L";
                c70.DOB = Convert.ToDateTime("1/1/1900");
                c70.SSN = "1112223232";
                c70.Miles = 0;
                c70.EmpType = "Cabin Crew";
                c70.Address = "444 45th St";
                c70.City = "Barrow";
                c70.State = "AK";
                c70.ZipCode = "99723";
                c70.PhoneNumber = "9018833432";
                c70.Email = "j.mason@penguinairlines.neet";
                c70.UserName = "j.mason@penguinairlines.neet";

                var result = UserManager.Create(c70, "changalang");
                db.SaveChanges();
                c70 = db.Users.First(u => u.UserName == "j.mason@penguinairlines.neet");
            }
            UserManager.AddToRole(c70.Id, "Cabin Crew");
            AppUser c71 = db.Users.FirstOrDefault(u => u.UserName == "j.jackson@penguinairlines.neet");
            if (c71 == null)
            {
                c71 = new AppUser();
                c71.AdvantageNumber = 0;
                c71.LastName = "Jackson";
                c71.FirstName = "Jack";
                c71.MI = "J";
                c71.DOB = Convert.ToDateTime("1/1/1900");
                c71.SSN = "8889993434";
                c71.Miles = 0;
                c71.EmpType = "Co-Pilot";
                c71.Address = "222 Main";
                c71.City = "Barrow";
                c71.State = "AK";
                c71.ZipCode = "99723";
                c71.PhoneNumber = "9075554545";
                c71.Email = "j.jackson@penguinairlines.neet";
                c71.UserName = "j.jackson@penguinairlines.neet";

                var result = UserManager.Create(c71, "offbeat");
                db.SaveChanges();
                c71 = db.Users.First(u => u.UserName == "j.jackson@penguinairlines.neet");
            }
            UserManager.AddToRole(c71.Id, "Co Pilot");
            AppUser c72 = db.Users.FirstOrDefault(u => u.UserName == "m.nguyen@penguinairlines.neet");
            if (c72 == null)
            {
                c72 = new AppUser();
                c72.AdvantageNumber = 0;
                c72.LastName = "Nguyen";
                c72.FirstName = "Mary";
                c72.MI = "J";
                c72.DOB = Convert.ToDateTime("1/1/1900");
                c72.SSN = "7776665555";
                c72.Miles = 0;
                c72.EmpType = "Pilot";
                c72.Address = "465 N. Bear Cub";
                c72.City = "Anchorage";
                c72.State = "AK";
                c72.ZipCode = "99503";
                c72.PhoneNumber = "9075524141";
                c72.Email = "m.nguyen@penguinairlines.neet";
                c72.UserName = "m.nguyen@penguinairlines.neet";

                var result = UserManager.Create(c72, "landus");
                db.SaveChanges();
                c72 = db.Users.First(u => u.UserName == "m.nguyen@penguinairlines.neet");
            }
            UserManager.AddToRole(c72.Id, "Pilot");
            AppUser c73 = db.Users.FirstOrDefault(u => u.UserName == "s.barnes@penguinairlines.neet");
            if (c73 == null)
            {
                c73 = new AppUser();
                c73.AdvantageNumber = 0;
                c73.LastName = "Barnes";
                c73.FirstName = "Susan";
                c73.MI = "M";
                c73.DOB = Convert.ToDateTime("1/1/1900");
                c73.SSN = "1112221212";
                c73.Miles = 0;
                c73.EmpType = "Cabin Crew";
                c73.Address = "888 S. Main";
                c73.City = "Barrow";
                c73.State = "AK";
                c73.ZipCode = "99723";
                c73.PhoneNumber = "9556662323";
                c73.Email = "s.barnes@penguinairlines.neet";
                c73.UserName = "s.barnes@penguinairlines.neet";

                var result = UserManager.Create(c73, "rhythm");
                db.SaveChanges();
                c73 = db.Users.First(u => u.UserName == "s.barnes@penguinairlines.neet");
            }
            UserManager.AddToRole(c73.Id, "Cabin Crew");
            AppUser c74 = db.Users.FirstOrDefault(u => u.UserName == "l.jones@penguinairlines.neet");
            if (c74 == null)
            {
                c74 = new AppUser();
                c74.AdvantageNumber = 0;
                c74.LastName = "Jones";
                c74.FirstName = "Lester";
                c74.MI = "L";
                c74.DOB = Convert.ToDateTime("1/1/1900");
                c74.SSN = "9099099999";
                c74.Miles = 0;
                c74.EmpType = "Co-Pilot";
                c74.Address = "999 LeBlat";
                c74.City = "Barrow";
                c74.State = "AK";
                c74.ZipCode = "99723";
                c74.PhoneNumber = "9886662222";
                c74.Email = "l.jones@penguinairlines.neet";
                c74.UserName = "l.jones@penguinairlines.neet";

                var result = UserManager.Create(c74, "kindly");
                db.SaveChanges();
                c74 = db.Users.First(u => u.UserName == "l.jones@penguinairlines.neet");
            }
            UserManager.AddToRole(c74.Id, "Co Pilot");
            AppUser c75 = db.Users.FirstOrDefault(u => u.UserName == "h.garcia@penguinairlines.neet");
            if (c75 == null)
            {
                c75 = new AppUser();
                c75.AdvantageNumber = 0;
                c75.LastName = "Garcia";
                c75.FirstName = "Hector";
                c75.MI = "W";
                c75.DOB = Convert.ToDateTime("1/1/1900");
                c75.SSN = "4445554343";
                c75.Miles = 0;
                c75.EmpType = "Pilot";
                c75.Address = "777 PBR Drive";
                c75.City = "Barrow";
                c75.State = "AK";
                c75.ZipCode = "99723";
                c75.PhoneNumber = "9221114444";
                c75.Email = "h.garcia@penguinairlines.neet";
                c75.UserName = "h.garcia@penguinairlines.neet";

                var result = UserManager.Create(c75, "instrument");
                db.SaveChanges();
                c75 = db.Users.First(u => u.UserName == "h.garcia@penguinairlines.neet");
            }
            UserManager.AddToRole(c75.Id, "Pilot");
            AppUser c76 = db.Users.FirstOrDefault(u => u.UserName == "c.silva@penguinairlines.neet");
            if (c76 == null)
            {
                c76 = new AppUser();
                c76.AdvantageNumber = 0;
                c76.LastName = "Silva";
                c76.FirstName = "Cindy";
                c76.MI = "S";
                c76.DOB = Convert.ToDateTime("1/1/1900");
                c76.SSN = "7776661111";
                c76.Miles = 0;
                c76.EmpType = "Cabin Crew";
                c76.Address = "900 4th St";
                c76.City = "Anchorage";
                c76.State = "AK";
                c76.ZipCode = "99504";
                c76.PhoneNumber = "9221113333";
                c76.Email = "c.silva@penguinairlines.neet";
                c76.UserName = "c.silva@penguinairlines.neet";

                var result = UserManager.Create(c76, "arched");
                db.SaveChanges();
                c76 = db.Users.First(u => u.UserName == "c.silva@penguinairlines.neet");
            }
            UserManager.AddToRole(c76.Id, "Cabin Crew");
            AppUser c77 = db.Users.FirstOrDefault(u => u.UserName == "m.lopez@penguinairlines.neet");
            if (c77 == null)
            {
                c77 = new AppUser();
                c77.AdvantageNumber = 0;
                c77.LastName = "Lopez";
                c77.FirstName = "Marshall";
                c77.MI = "T";
                c77.DOB = Convert.ToDateTime("1/1/1900");
                c77.SSN = "2223332222";
                c77.Miles = 0;
                c77.EmpType = "Co-Pilot";
                c77.Address = "90 SW North St";
                c77.City = "Anchorage";
                c77.State = "AK";
                c77.ZipCode = "99504";
                c77.PhoneNumber = "9234442222";
                c77.Email = "m.lopez@penguinairlines.neet";
                c77.UserName = "m.lopez@penguinairlines.neet";

                var result = UserManager.Create(c77, "median");
                db.SaveChanges();
                c77 = db.Users.First(u => u.UserName == "m.lopez@penguinairlines.neet");
            }
            UserManager.AddToRole(c77.Id, "Co Pilot");
            AppUser c78 = db.Users.FirstOrDefault(u => u.UserName == "b.larson@penguinairlines.neet");
            if (c78 == null)
            {
                c78 = new AppUser();
                c78.AdvantageNumber = 0;
                c78.LastName = "Larson";
                c78.FirstName = "Bill";
                c78.MI = "B";
                c78.DOB = Convert.ToDateTime("1/1/1900");
                c78.SSN = "5554443333";
                c78.Miles = 0;
                c78.EmpType = "Pilot";
                c78.Address = "1212 N. First Ave";
                c78.City = "Anchorage";
                c78.State = "AK";
                c78.ZipCode = "99504";
                c78.PhoneNumber = "9795554444";
                c78.Email = "b.larson@penguinairlines.neet";
                c78.UserName = "b.larson@penguinairlines.neet";

                var result = UserManager.Create(c78, "approval");
                db.SaveChanges();
                c78 = db.Users.First(u => u.UserName == "b.larson@penguinairlines.neet");
            }
            UserManager.AddToRole(c78.Id, "Pilot");
            AppUser c79 = db.Users.FirstOrDefault(u => u.UserName == "s.rankin@penguinairlines.neet");
            if (c79 == null)
            {
                c79 = new AppUser();
                c79.AdvantageNumber = 0;
                c79.LastName = "Rankin";
                c79.FirstName = "Suzie";
                c79.MI = "R";
                c79.DOB = Convert.ToDateTime("1/1/1900");
                c79.SSN = "1911919111";
                c79.Miles = 0;
                c79.EmpType = "Cabin Crew";
                c79.Address = "23 Polar Bear Road";
                c79.City = "Anchorage";
                c79.State = "AK";
                c79.ZipCode = "99504";
                c79.PhoneNumber = "9893336666";
                c79.Email = "s.rankin@penguinairlines.neet";
                c79.UserName = "s.rankin@penguinairlines.neet";

                var result = UserManager.Create(c79, "decorate");
                db.SaveChanges();
                c79 = db.Users.First(u => u.UserName == "s.rankin@penguinairlines.neet");
            }

            UserManager.AddToRole(c79.Id, "Cabin Crew");

            Day Sunday = db.Days.FirstOrDefault(m => m.Name == "Sunday");
            if (Sunday == null)
            {
                Sunday = new Day();
                Sunday.Name = "Sunday";
                db.Days.AddOrUpdate(Sunday);
                db.SaveChanges();
            }

            Day Monday = db.Days.FirstOrDefault(m => m.Name == "Monday");
            if (Monday == null)
            {
                Monday = new Day();
                Monday.Name = "Monday";
                db.Days.AddOrUpdate(Monday);
                db.SaveChanges();
            }

            Day Tuesday = db.Days.FirstOrDefault(m => m.Name == "Tuesday");
            if (Tuesday == null)
            {
                Tuesday = new Day();
                Tuesday.Name = "Tuesday";
                db.Days.AddOrUpdate(Tuesday);
                db.SaveChanges();
            }

            Day Wednesday = db.Days.FirstOrDefault(m => m.Name == "Wednesday");
            if (Wednesday == null)
            {
                Wednesday = new Day();
                Wednesday.Name = "Wednesday";
                db.Days.AddOrUpdate(Wednesday);
                db.SaveChanges();
            }

            Day Thursday = db.Days.FirstOrDefault(m => m.Name == "Thursday");
            if (Thursday == null)
            {
                Thursday = new Day();
                Thursday.Name = "Thursday";
                db.Days.AddOrUpdate(Thursday);
                db.SaveChanges();
            }

            Day Friday = db.Days.FirstOrDefault(m => m.Name == "Friday");
            if (Friday == null)
            {
                Friday = new Day();
                Friday.Name = "Friday";
                db.Days.AddOrUpdate(Friday);
                db.SaveChanges();
            }

            Day Saturday = db.Days.FirstOrDefault(m => m.Name == "Saturday");
            if (Saturday == null)
            {
                Saturday = new Day();
                Saturday.Name = "Saturday";
                db.Days.AddOrUpdate(Saturday);
                db.SaveChanges();
            }

            SeatType Economy = db.SeatType.FirstOrDefault(m => m.Name == "Economy");
            if (Economy == null)
            {
                Economy = new SeatType();
                Economy.Name = "Economy";
                db.SeatType.AddOrUpdate(Economy);
                db.SaveChanges();
            }

            SeatType FirstClass = db.SeatType.FirstOrDefault(m => m.Name == "FirstClass");
            if (FirstClass == null)
            {
                FirstClass = new SeatType();
                FirstClass.Name = "FirstClass";
                db.SeatType.AddOrUpdate(FirstClass);
                db.SaveChanges();
            }


            
            City Anchorage = db.Cities.FirstOrDefault(c => c.Airport == "ANC");
            if (Anchorage == null)
            {
                Anchorage = new City();
                Anchorage.Airport = "ANC";
                Anchorage.CityName = "Anchorage";
                Anchorage.State = "AK";
                db.Cities.Add(Anchorage);
                db.SaveChanges();
            }

            City Fairbanks = db.Cities.FirstOrDefault(c => c.Airport == "FAI");
            if (Fairbanks == null)
            {
                Fairbanks = new City();
                Fairbanks.Airport = "FAI";
                Fairbanks.CityName = "Fairbanks";
                Fairbanks.State = "AK";
                db.Cities.Add(Fairbanks);
                db.SaveChanges();
            }

            City Barrow = db.Cities.FirstOrDefault(c => c.Airport == "BRW");
            if (Barrow == null)
            {
                Barrow = new City();
                Barrow.Airport = "BRW";
                Barrow.CityName = "Barrow";
                Barrow.State = "AK";
                db.Cities.Add(Barrow);
                db.SaveChanges();
            }

            City Juneau = db.Cities.FirstOrDefault(c => c.Airport == "JNU");
            if (Juneau == null)
            {
                Juneau = new City();
                Juneau.Airport = "JNU";
                Juneau.CityName = "Juneau";
                Juneau.State = "AK";
                db.Cities.Add(Juneau);
                db.SaveChanges();
            }



            Route r1 = db.Routes.FirstOrDefault(c => c.Cities.FirstOrDefault(d => d.CityName == "Anchorage").CityName == "Anchorage" && c.Cities.FirstOrDefault(d => d.CityName == "Fairbanks").CityName == "Fairbanks");
            if (r1 == null)
            {
                r1 = new Route();
                r1.Cities = new List<City>();
                r1.Cities.Add(Anchorage);
                r1.Cities.Add(Fairbanks);
                r1.Hours = new TimeSpan(1, 3, 0);
                r1.Miles = 261;
                db.Routes.Add(r1);
                db.SaveChanges();
            }

            Route r2 = db.Routes.FirstOrDefault(c => c.Cities.FirstOrDefault(d => d.CityName == "Anchorage").CityName == "Anchorage" && c.Cities.FirstOrDefault(d => d.CityName == "Barrow").CityName == "Barrow");
            if (r2 == null)
            {
                r2 = new Route();
                r2.Cities = new List<City>();
                r2.Cities.Add(Anchorage);
                r2.Cities.Add(Barrow);
                r2.Hours = new TimeSpan(2, 56, 0);
                r2.Miles = 725;
                db.Routes.Add(r2);
                db.SaveChanges();
            }

            Route r3 = db.Routes.FirstOrDefault(c => c.Cities.FirstOrDefault(d => d.CityName == "Anchorage").CityName == "Anchorage" && c.Cities.FirstOrDefault(d => d.CityName == "Juneau").CityName == "Juneau");
            if (r3 == null)
            {
                r3 = new Route();
                r3.Cities = new List<City>();
                r3.Cities.Add(Anchorage);
                r3.Cities.Add(Juneau);
                r3.Hours = new TimeSpan(2, 23, 0);
                r3.Miles = 571;
                db.Routes.Add(r3);
                db.SaveChanges();
            }

            Route r4 = db.Routes.FirstOrDefault(c => c.Cities.FirstOrDefault(d => d.CityName == "Fairbanks").CityName == "Fairbanks" && c.Cities.FirstOrDefault(d => d.CityName == "Barrow").CityName == "Barrow");
            if (r4 == null)
            {
                r4 = new Route();
                r4.Cities = new List<City>();
                r4.Cities.Add(Fairbanks);
                r4.Cities.Add(Barrow);
                r4.Hours = new TimeSpan(2, 8, 0);
                r4.Miles = 503;
                db.Routes.Add(r4);
                db.SaveChanges();
            }

            Route r5 = db.Routes.FirstOrDefault(c => c.Cities.FirstOrDefault(d => d.CityName == "Fairbanks").CityName == "Fairbanks" && c.Cities.FirstOrDefault(d => d.CityName == "Juneau").CityName == "Juneau");
            if (r5 == null)
            {
                r5 = new Route();
                r5.Cities = new List<City>();
                r5.Cities.Add(Fairbanks);
                r5.Cities.Add(Juneau);
                r5.Hours = new TimeSpan(2, 42, 0);
                r5.Miles = 624;
                db.Routes.Add(r5);
                db.SaveChanges();
            }

            Route r6 = db.Routes.FirstOrDefault(c => c.Cities.FirstOrDefault(d => d.CityName == "Barrow").CityName == "Barrow" && c.Cities.FirstOrDefault(d => d.CityName == "Juneau").CityName == "Juneau");
            if (r6 == null)
            {
                r6 = new Route();
                r6.Cities = new List<City>();
                r6.Cities.Add(Barrow);
                r6.Cities.Add(Juneau);
                r6.Hours = new TimeSpan(5, 23, 0);
                r6.Miles = 1243;
                db.Routes.Add(r6);
                db.SaveChanges();
            }







            FlightNumber fn1 = db.FlightNumbers.FirstOrDefault(u => u.Number == 100);
            if (fn1 == null)
            {
                fn1 = new FlightNumber();
                fn1.Number = 100;
                fn1.startCity = db.Cities.Where(c => c.Airport == "ANC").ToList().First();
                fn1.endCityAirport = "FAI";
                fn1.Route = db.Routes.FirstOrDefault(c => c.Miles == 261);
                fn1.BeenDisabled = false;
                fn1.BaseFare = 105.00m;
                fn1.DepartTime = new TimeSpan(8, 0, 0);
                fn1.DepartureDays = new List<Day>();
                fn1.DepartureDays.Add(db.Days.Where(d => d.Name == "Monday").ToList().First());
                fn1.DepartureDays.Add(db.Days.Where(d => d.Name == "Tuesday").ToList().First());
                fn1.DepartureDays.Add(db.Days.Where(d => d.Name == "Wednesday").ToList().First());
                fn1.DepartureDays.Add(db.Days.Where(d => d.Name == "Thursday").ToList().First());
                fn1.DepartureDays.Add(db.Days.Where(d => d.Name == "Friday").ToList().First());
                db.FlightNumbers.AddOrUpdate(fn1);
                db.SaveChanges();
            }

            FlightNumber fn2 = db.FlightNumbers.FirstOrDefault(u => u.Number == 101);
            if (fn2 == null)
            {
                fn2 = new FlightNumber();
                fn2.Number = 101;
                fn2.startCity = db.Cities.Where(c => c.Airport == "FAI").ToList().First();
                fn2.endCityAirport = "ANC";
                fn2.Route = db.Routes.FirstOrDefault(c => c.Miles == 261);
                fn2.BeenDisabled = false;
                fn2.BaseFare = 105.00m;
                fn2.DepartTime = new TimeSpan(9, 0, 0);
                fn2.DepartureDays = new List<Day>();
                fn2.DepartureDays.Add(db.Days.Where(d => d.Name == "Monday").ToList().First());
                fn2.DepartureDays.Add(db.Days.Where(d => d.Name == "Tuesday").ToList().First());
                fn2.DepartureDays.Add(db.Days.Where(d => d.Name == "Wednesday").ToList().First());
                fn2.DepartureDays.Add(db.Days.Where(d => d.Name == "Thursday").ToList().First());
                fn2.DepartureDays.Add(db.Days.Where(d => d.Name == "Friday").ToList().First());
                db.FlightNumbers.AddOrUpdate(fn2);
                db.SaveChanges();
            }

            FlightNumber fn3 = db.FlightNumbers.FirstOrDefault(u => u.Number == 102);
            if (fn3 == null)
            {
                fn3 = new FlightNumber();
                fn3.Number = 102;
                fn3.startCity = db.Cities.Where(c => c.Airport == "ANC").ToList().First();
                fn3.endCityAirport = "FAI";
                fn3.Route = db.Routes.FirstOrDefault(c => c.Miles == 261);
                fn3.BeenDisabled = false;
                fn3.BaseFare = 130.00m;
                fn3.DepartTime = new TimeSpan(11, 0, 0);
                fn3.DepartureDays = new List<Day>();
                fn3.DepartureDays.Add(db.Days.Where(d => d.Name == "Monday").ToList().First());
                fn3.DepartureDays.Add(db.Days.Where(d => d.Name == "Tuesday").ToList().First());
                fn3.DepartureDays.Add(db.Days.Where(d => d.Name == "Wednesday").ToList().First());
                fn3.DepartureDays.Add(db.Days.Where(d => d.Name == "Thursday").ToList().First());
                fn3.DepartureDays.Add(db.Days.Where(d => d.Name == "Friday").ToList().First());
                fn3.DepartureDays.Add(db.Days.Where(d => d.Name == "Saturday").ToList().First());
                fn3.DepartureDays.Add(db.Days.Where(d => d.Name == "Sunday").ToList().First());
                db.FlightNumbers.AddOrUpdate(fn3);
                db.SaveChanges();
            }

            FlightNumber fn4 = db.FlightNumbers.FirstOrDefault(u => u.Number == 103);
            if (fn4 == null)
            {
                fn4 = new FlightNumber();
                fn4.Number = 103;
                fn4.startCity = db.Cities.Where(c => c.Airport == "FAI").ToList().First();
                fn4.endCityAirport = "ANC";
                fn4.Route = db.Routes.FirstOrDefault(c => c.Miles == 261);
                fn4.BeenDisabled = false;
                fn4.BaseFare = 130.00m;
                fn4.DepartTime = new TimeSpan(12, 0, 0);
                fn4.DepartureDays = new List<Day>();
                fn4.DepartureDays.Add(db.Days.Where(d => d.Name == "Monday").ToList().First());
                fn4.DepartureDays.Add(db.Days.Where(d => d.Name == "Tuesday").ToList().First());
                fn4.DepartureDays.Add(db.Days.Where(d => d.Name == "Wednesday").ToList().First());
                fn4.DepartureDays.Add(db.Days.Where(d => d.Name == "Thursday").ToList().First());
                fn4.DepartureDays.Add(db.Days.Where(d => d.Name == "Friday").ToList().First());
                fn4.DepartureDays.Add(db.Days.Where(d => d.Name == "Saturday").ToList().First());
                fn4.DepartureDays.Add(db.Days.Where(d => d.Name == "Sunday").ToList().First());
                db.FlightNumbers.AddOrUpdate(fn4);
                db.SaveChanges();
            }

            FlightNumber fn5 = db.FlightNumbers.FirstOrDefault(u => u.Number == 104);
            if (fn5 == null)
            {
                fn5 = new FlightNumber();
                fn5.Number = 104;
                fn5.startCity = db.Cities.Where(c => c.Airport == "FAI").ToList().First();
                fn5.endCityAirport = "BRW";
                fn5.Route = db.Routes.FirstOrDefault(c => c.Miles == 503);
                fn5.BeenDisabled = false;
                fn5.BaseFare = 140.00m;
                fn5.DepartTime = new TimeSpan(13, 0, 0);
                fn5.DepartureDays = new List<Day>();
                fn5.DepartureDays.Add(db.Days.Where(d => d.Name == "Monday").ToList().First());
                fn5.DepartureDays.Add(db.Days.Where(d => d.Name == "Tuesday").ToList().First());
                fn5.DepartureDays.Add(db.Days.Where(d => d.Name == "Wednesday").ToList().First());
                fn5.DepartureDays.Add(db.Days.Where(d => d.Name == "Thursday").ToList().First());
                fn5.DepartureDays.Add(db.Days.Where(d => d.Name == "Friday").ToList().First());
                fn5.DepartureDays.Add(db.Days.Where(d => d.Name == "Saturday").ToList().First());
                fn5.DepartureDays.Add(db.Days.Where(d => d.Name == "Sunday").ToList().First());
                db.FlightNumbers.AddOrUpdate(fn5);
                db.SaveChanges();
            }

            FlightNumber fn6 = db.FlightNumbers.FirstOrDefault(u => u.Number == 105);
            if (fn6 == null)
            {
                fn6 = new FlightNumber();
                fn6.Number = 105;
                fn6.startCity = db.Cities.Where(c => c.Airport == "BRW").ToList().First();
                fn6.endCityAirport = "FAI";
                fn6.Route = db.Routes.FirstOrDefault(c => c.Miles == 503);
                fn6.BeenDisabled = false;
                fn6.BaseFare = 140.00m;
                fn6.DepartTime = new TimeSpan(15, 0, 0);
                fn6.DepartureDays = new List<Day>();
                fn6.DepartureDays.Add(db.Days.Where(d => d.Name == "Monday").ToList().First());
                fn6.DepartureDays.Add(db.Days.Where(d => d.Name == "Tuesday").ToList().First());
                fn6.DepartureDays.Add(db.Days.Where(d => d.Name == "Wednesday").ToList().First());
                fn6.DepartureDays.Add(db.Days.Where(d => d.Name == "Thursday").ToList().First());
                fn6.DepartureDays.Add(db.Days.Where(d => d.Name == "Friday").ToList().First());
                fn6.DepartureDays.Add(db.Days.Where(d => d.Name == "Saturday").ToList().First());
                fn6.DepartureDays.Add(db.Days.Where(d => d.Name == "Sunday").ToList().First());
                db.FlightNumbers.AddOrUpdate(fn6);
                db.SaveChanges();
            }

            FlightNumber fn7 = db.FlightNumbers.FirstOrDefault(u => u.Number == 106);
            if (fn7 == null)
            {
                fn7 = new FlightNumber();
                fn7.Number = 106;
                fn7.startCity = db.Cities.Where(c => c.Airport == "ANC").ToList().First();
                fn7.endCityAirport = "JNU";
                fn7.Route = db.Routes.FirstOrDefault(c => c.Miles == 571);
                fn7.BeenDisabled = false;
                fn7.BaseFare = 98.00m;
                fn7.DepartTime = new TimeSpan(9, 0, 0);
                fn7.DepartureDays = new List<Day>();
                fn7.DepartureDays.Add(db.Days.Where(d => d.Name == "Monday").ToList().First());
                fn7.DepartureDays.Add(db.Days.Where(d => d.Name == "Tuesday").ToList().First());
                fn7.DepartureDays.Add(db.Days.Where(d => d.Name == "Wednesday").ToList().First());
                fn7.DepartureDays.Add(db.Days.Where(d => d.Name == "Thursday").ToList().First());
                fn7.DepartureDays.Add(db.Days.Where(d => d.Name == "Friday").ToList().First());
                db.FlightNumbers.AddOrUpdate(fn7);
                db.SaveChanges();
            }

            FlightNumber fn8 = db.FlightNumbers.FirstOrDefault(u => u.Number == 107);
            if (fn8 == null)
            {
                fn8 = new FlightNumber();
                fn8.Number = 107;
                fn8.startCity = db.Cities.Where(c => c.Airport == "JNU").ToList().First();
                fn8.endCityAirport = "ANC";
                fn8.Route = db.Routes.FirstOrDefault(c => c.Miles == 571);
                fn8.BeenDisabled = false;
                fn8.BaseFare = 100.00m;
                fn8.DepartTime = new TimeSpan(10, 0, 0);
                fn8.DepartureDays = new List<Day>();
                fn8.DepartureDays.Add(db.Days.Where(d => d.Name == "Monday").ToList().First());
                fn8.DepartureDays.Add(db.Days.Where(d => d.Name == "Tuesday").ToList().First());
                fn8.DepartureDays.Add(db.Days.Where(d => d.Name == "Wednesday").ToList().First());
                fn8.DepartureDays.Add(db.Days.Where(d => d.Name == "Thursday").ToList().First());
                fn8.DepartureDays.Add(db.Days.Where(d => d.Name == "Friday").ToList().First());
                db.FlightNumbers.AddOrUpdate(fn8);
                db.SaveChanges();
            }

            FlightNumber fn9 = db.FlightNumbers.FirstOrDefault(u => u.Number == 108);
            if (fn9 == null)
            {
                fn9 = new FlightNumber();
                fn9.Number = 108;
                fn9.startCity = db.Cities.Where(c => c.Airport == "ANC").ToList().First();
                fn9.endCityAirport = "JNU";
                fn9.Route = db.Routes.FirstOrDefault(c => c.Miles == 571);
                fn9.BeenDisabled = false;
                fn9.BaseFare = 115.00m;
                fn9.DepartTime = new TimeSpan(13, 0, 0);
                fn9.DepartureDays = new List<Day>();
                fn9.DepartureDays.Add(db.Days.Where(d => d.Name == "Monday").ToList().First());
                fn9.DepartureDays.Add(db.Days.Where(d => d.Name == "Tuesday").ToList().First());
                fn9.DepartureDays.Add(db.Days.Where(d => d.Name == "Wednesday").ToList().First());
                fn9.DepartureDays.Add(db.Days.Where(d => d.Name == "Thursday").ToList().First());
                fn9.DepartureDays.Add(db.Days.Where(d => d.Name == "Friday").ToList().First());
                fn9.DepartureDays.Add(db.Days.Where(d => d.Name == "Saturday").ToList().First());
                fn9.DepartureDays.Add(db.Days.Where(d => d.Name == "Sunday").ToList().First());
                db.FlightNumbers.AddOrUpdate(fn9);
                db.SaveChanges();
            }

            FlightNumber fn10 = db.FlightNumbers.FirstOrDefault(u => u.Number == 109);
            if (fn10 == null)
            {
                fn10 = new FlightNumber();
                fn10.Number = 109;
                fn10.startCity = db.Cities.Where(c => c.Airport == "JNU").ToList().First();
                fn10.endCityAirport = "ANC";
                fn10.Route = db.Routes.FirstOrDefault(c => c.Miles == 571);
                fn10.BeenDisabled = false;
                fn10.BaseFare = 115.00m;
                fn10.DepartTime = new TimeSpan(14, 0, 0);
                fn10.DepartureDays = new List<Day>();
                fn10.DepartureDays.Add(db.Days.Where(d => d.Name == "Monday").ToList().First());
                fn10.DepartureDays.Add(db.Days.Where(d => d.Name == "Tuesday").ToList().First());
                fn10.DepartureDays.Add(db.Days.Where(d => d.Name == "Wednesday").ToList().First());
                fn10.DepartureDays.Add(db.Days.Where(d => d.Name == "Thursday").ToList().First());
                fn10.DepartureDays.Add(db.Days.Where(d => d.Name == "Friday").ToList().First());
                fn10.DepartureDays.Add(db.Days.Where(d => d.Name == "Saturday").ToList().First());
                fn10.DepartureDays.Add(db.Days.Where(d => d.Name == "Sunday").ToList().First());
                db.FlightNumbers.AddOrUpdate(fn10);
                db.SaveChanges();
            }

            FlightNumber fn11 = db.FlightNumbers.FirstOrDefault(u => u.Number == 110);
            if (fn11 == null)
            {
                fn11 = new FlightNumber();
                fn11.Number = 110;
                fn11.startCity = db.Cities.Where(c => c.Airport == "FAI").ToList().First();
                fn11.endCityAirport = "JNU";
                fn11.Route = db.Routes.FirstOrDefault(c => c.Miles == 624);
                fn11.BeenDisabled = false;
                fn11.BaseFare = 110.00m;
                fn11.DepartTime = new TimeSpan(14, 0, 0);
                fn11.DepartureDays = new List<Day>();
                fn11.DepartureDays.Add(db.Days.Where(d => d.Name == "Monday").ToList().First());
                fn11.DepartureDays.Add(db.Days.Where(d => d.Name == "Tuesday").ToList().First());
                fn11.DepartureDays.Add(db.Days.Where(d => d.Name == "Wednesday").ToList().First());
                fn11.DepartureDays.Add(db.Days.Where(d => d.Name == "Thursday").ToList().First());
                fn11.DepartureDays.Add(db.Days.Where(d => d.Name == "Friday").ToList().First());
                db.FlightNumbers.AddOrUpdate(fn11);
                db.SaveChanges();
            }

            FlightNumber fn12 = db.FlightNumbers.FirstOrDefault(u => u.Number == 111);
            if (fn12 == null)
            {
                fn12 = new FlightNumber();
                fn12.Number = 111;
                fn12.startCity = db.Cities.Where(c => c.Airport == "JNU").ToList().First();
                fn12.endCityAirport = "FAI";
                fn12.Route = db.Routes.FirstOrDefault(c => c.Miles == 624);
                fn12.BeenDisabled = false;
                fn12.BaseFare = 110.00m;
                fn12.DepartTime = new TimeSpan(14, 0, 0);
                fn12.DepartureDays = new List<Day>();
                fn12.DepartureDays.Add(db.Days.Where(d => d.Name == "Monday").ToList().First());
                fn12.DepartureDays.Add(db.Days.Where(d => d.Name == "Tuesday").ToList().First());
                fn12.DepartureDays.Add(db.Days.Where(d => d.Name == "Wednesday").ToList().First());
                fn12.DepartureDays.Add(db.Days.Where(d => d.Name == "Thursday").ToList().First());
                fn12.DepartureDays.Add(db.Days.Where(d => d.Name == "Friday").ToList().First());
                db.FlightNumbers.AddOrUpdate(fn12);
                db.SaveChanges();
            }

            FlightNumber fn13 = db.FlightNumbers.FirstOrDefault(u => u.Number == 112);
            if (fn13 == null)
            {
                fn13 = new FlightNumber();
                fn13.Number = 112;
                fn13.startCity = db.Cities.Where(c => c.Airport == "FAI").ToList().First();
                fn13.endCityAirport = "JNU";
                fn13.Route = db.Routes.FirstOrDefault(c => c.Miles == 624);
                fn13.BeenDisabled = false;
                fn13.BaseFare = 105.00m;
                fn13.DepartTime = new TimeSpan(18, 0, 0);
                fn13.DepartureDays = new List<Day>();
                fn13.DepartureDays.Add(db.Days.Where(d => d.Name == "Monday").ToList().First());
                fn13.DepartureDays.Add(db.Days.Where(d => d.Name == "Tuesday").ToList().First());
                fn13.DepartureDays.Add(db.Days.Where(d => d.Name == "Wednesday").ToList().First());
                fn13.DepartureDays.Add(db.Days.Where(d => d.Name == "Thursday").ToList().First());
                fn13.DepartureDays.Add(db.Days.Where(d => d.Name == "Friday").ToList().First());
                fn13.DepartureDays.Add(db.Days.Where(d => d.Name == "Saturday").ToList().First());
                fn13.DepartureDays.Add(db.Days.Where(d => d.Name == "Sunday").ToList().First());
                db.FlightNumbers.AddOrUpdate(fn13);
                db.SaveChanges();
            }

            FlightNumber fn14 = db.FlightNumbers.FirstOrDefault(u => u.Number == 113);
            if (fn14 == null)
            {
                fn14 = new FlightNumber();
                fn14.Number = 113;
                fn14.startCity = db.Cities.Where(c => c.Airport == "JNU").ToList().First();
                fn14.endCityAirport = "FAI";
                fn14.Route = db.Routes.FirstOrDefault(c => c.Miles == 624);
                fn14.BeenDisabled = false;
                fn14.BaseFare = 105.00m;
                fn14.DepartTime = new TimeSpan(19, 0, 0);
                fn14.DepartureDays = new List<Day>();
                fn14.DepartureDays.Add(db.Days.Where(d => d.Name == "Monday").ToList().First());
                fn14.DepartureDays.Add(db.Days.Where(d => d.Name == "Tuesday").ToList().First());
                fn14.DepartureDays.Add(db.Days.Where(d => d.Name == "Wednesday").ToList().First());
                fn14.DepartureDays.Add(db.Days.Where(d => d.Name == "Thursday").ToList().First());
                fn14.DepartureDays.Add(db.Days.Where(d => d.Name == "Friday").ToList().First());
                fn14.DepartureDays.Add(db.Days.Where(d => d.Name == "Saturday").ToList().First());
                fn14.DepartureDays.Add(db.Days.Where(d => d.Name == "Sunday").ToList().First());
                db.FlightNumbers.AddOrUpdate(fn14);
                db.SaveChanges();
            }

            FlightNumber fn15 = db.FlightNumbers.FirstOrDefault(u => u.Number == 114);
            if (fn15 == null)
            {
                fn15 = new FlightNumber();
                fn15.Number = 114;
                fn15.startCity = db.Cities.Where(c => c.Airport == "BRW").ToList().First();
                fn15.endCityAirport = "JNU";
                fn15.Route = db.Routes.FirstOrDefault(c => c.Miles == 1243);
                fn15.BeenDisabled = false;
                fn15.BaseFare = 225.00m;
                fn15.DepartTime = new TimeSpan(10, 0, 0);
                fn15.DepartureDays = new List<Day>();
                fn15.DepartureDays.Add(db.Days.Where(d => d.Name == "Saturday").ToList().First());
                db.FlightNumbers.AddOrUpdate(fn15);
                db.SaveChanges();
            }

        }
    }


}









