using Team_5_Project.Models;
using Team_5_Project.DAL;
using System.Data.Entity.Migrations;
using System.Linq;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

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
                c1 = new Customer();
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
                var result = UserManager.Create(c1, "hellos");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "cbaker@freserve.co.uk");
            }

            AppUser c2 = db.Users.FirstOrDefault(u => u.UserName == "banker@penguin.net");
            if (c2 == null)
            {
                c2 = new Customer();
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
                var result = UserManager.Create(c2, "potato");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "banker@penguin.net");
            }

            AppUser c3 = db.Users.FirstOrDefault(u => u.UserName == "franco@aoll.com");
            if (c3 == null)
            {
                c3 = new Customer();
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
                var result = UserManager.Create(c3, "painting");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "franco@aoll.com");
            }

            AppUser c4 = db.Users.FirstOrDefault(u => u.UserName == "wchang@gogle.com");
            if (c4 == null)
            {
                c4 = new Customer();
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
                var result = UserManager.Create(c4, "texass");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "wchang@gogle.com");
            }

            AppUser c5 = db.Users.FirstOrDefault(u => u.UserName == "limchou@yoho.com");
            if (c5 == null)
            {
                c5 = new Customer();
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
                var result = UserManager.Create(c5, "Anchorage");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "limchou@yoho.com");
            }

            AppUser c6 = db.Users.FirstOrDefault(u => u.UserName == "shdixon@utx.edu");
            if (c6 == null)
            {
                c6 = new Customer();
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
                var result = UserManager.Create(c6, "pepperoni");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "shdixon@utx.edu");
            }

            AppUser c7 = db.Users.FirstOrDefault(u => u.UserName == "j.b.evans@aheca.org");
            if (c7 == null)
            {
                c7 = new Customer();
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
                var result = UserManager.Create(c7, "longhorns");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "j.b.evans@aheca.org");
            }

            AppUser c8 = db.Users.FirstOrDefault(u => u.UserName == "feeley@penguin.org");
            if (c8 == null)
            {
                c8 = new Customer();
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
                var result = UserManager.Create(c8, "aggies");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "feeley@penguin.org");
            }

            AppUser c9 = db.Users.FirstOrDefault(u => u.UserName == "tfreeley@minnetonka.ci.us");
            if (c9 == null)
            {
                c9 = new Customer();
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
                var result = UserManager.Create(c9, "raiders");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "tfreeley@minnetonka.ci.us");
            }

            AppUser c10 = db.Users.FirstOrDefault(u => u.UserName == "mgarcia@gogle.com");
            if (c10 == null)
            {
                c10 = new Customer();
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
                var result = UserManager.Create(c10, "mustangs");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "mgarcia@gogle.com");
            }

            AppUser c11 = db.Users.FirstOrDefault(u => u.UserName == "chaley@thug.com");
            if (c11 == null)
            {
                c11 = new Customer();
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
                var result = UserManager.Create(c11, "onetime");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "chaley@thug.com");
            }

            AppUser c12 = db.Users.FirstOrDefault(u => u.UserName == "jeffh@sonic.com");
            if (c12 == null)
            {
                c12 = new Customer();
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
                var result = UserManager.Create(c12, "hampton1");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "jeffh@sonic.com");
            }

            AppUser c13 = db.Users.FirstOrDefault(u => u.UserName == "wjhearniii@umich.org");
            if (c13 == null)
            {
                c13 = new Customer();
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
                var result = UserManager.Create(c13, "jhearn22");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "wjhearniii@umich.org");
            }

            AppUser c14 = db.Users.FirstOrDefault(u => u.UserName == "ahick@yaho.com");
            if (c14 == null)
            {
                c14 = new Customer();
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
                var result = UserManager.Create(c14, "hickhickup");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "ahick@yaho.com");
            }

            AppUser c15 = db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com");
            if (c15 == null)
            {
                c15 = new Customer();
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
                var result = UserManager.Create(c15, "ingram2015");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "ingram@jack.com");
            }

            AppUser c16 = db.Users.FirstOrDefault(u => u.UserName == "toddj@yourmom.com");
            if (c16 == null)
            {
                c16 = new Customer();
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
                var result = UserManager.Create(c16, "toddy25");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "toddj@yourmom.com");
            }

            AppUser c17 = db.Users.FirstOrDefault(u => u.UserName == "thequeen@aska.net");
            if (c17 == null)
            {
                c17 = new Customer();
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
                var result = UserManager.Create(c17, "something");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "thequeen@aska.net");
            }

            AppUser c18 = db.Users.FirstOrDefault(u => u.UserName == "linebacker@gogle.com");
            if (c18 == null)
            {
                c18 = new Customer();
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
                var result = UserManager.Create(c18, "Password1");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "linebacker@gogle.com");
            }

            AppUser c19 = db.Users.FirstOrDefault(u => u.UserName == "elowe@netscare.net");
            if (c19 == null)
            {
                c19 = new Customer();
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
                var result = UserManager.Create(c19, "aclfest2017");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "elowe@netscare.net");
            }

            AppUser c20 = db.Users.FirstOrDefault(u => u.UserName == "cluce@gogle.com");
            if (c20 == null)
            {
                c20 = new Customer();
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
                var result = UserManager.Create(c20, "nothinggood");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "cluce@gogle.com");
            }

            AppUser c21 = db.Users.FirstOrDefault(u => u.UserName == "mackcloud@george.com");
            if (c21 == null)
            {
                c21 = new Customer();
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
                var result = UserManager.Create(c21, "whatever");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "mackcloud@george.com");
            }

            AppUser c22 = db.Users.FirstOrDefault(u => u.UserName == "cmartin@beets.com");
            if (c22 == null)
            {
                c22 = new Customer();
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
                var result = UserManager.Create(c22, "whocares");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "cmartin@beets.com");
            }

            AppUser c23 = db.Users.FirstOrDefault(u => u.UserName == "clarence@yoho.com");
            if (c23 == null)
            {
                c23 = new Customer();
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
                var result = UserManager.Create(c23, "xcellent");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "clarence@yoho.com");
            }

            AppUser c24 = db.Users.FirstOrDefault(u => u.UserName == "gregmartinez@drdre.com");
            if (c24 == null)
            {
                c24 = new Customer();
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
                var result = UserManager.Create(c24, "snowsnow");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "gregmartinez@drdre.com");
            }

            AppUser c25 = db.Users.FirstOrDefault(u => u.UserName == "cmiller@bob.com");
            if (c25 == null)
            {
                c25 = new Customer();
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
                var result = UserManager.Create(c25, "mydogspot");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "cmiller@bob.com");
            }

            AppUser c26 = db.Users.FirstOrDefault(u => u.UserName == "knelson@aoll.com");
            if (c26 == null)
            {
                c26 = new Customer();
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
                var result = UserManager.Create(c26, "spotmydog");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "knelson@aoll.com");
            }

            AppUser c27 = db.Users.FirstOrDefault(u => u.UserName == "joewin@xfactor.com");
            if (c27 == null)
            {
                c27 = new Customer();
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
                var result = UserManager.Create(c27, "joejoejoe");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "joewin@xfactor.com");
            }

            AppUser c28 = db.Users.FirstOrDefault(u => u.UserName == "orielly@foxnews.cnn");
            if (c28 == null)
            {
                c28 = new Customer();
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
                var result = UserManager.Create(c28, "billyboy");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "orielly@foxnews.cnn");
            }

            AppUser c29 = db.Users.FirstOrDefault(u => u.UserName == "ankaisrad@gogle.com");
            if (c29 == null)
            {
                c29 = new Customer();
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
                var result = UserManager.Create(c29, "radgirl");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "ankaisrad@gogle.com");
            }

            AppUser c30 = db.Users.FirstOrDefault(u => u.UserName == "megrhodes@freserve.co.uk");
            if (c30 == null)
            {
                c30 = new Customer();
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
                var result = UserManager.Create(c30, "meganr34");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "megrhodes@freserve.co.uk");
            }

            AppUser c31 = db.Users.FirstOrDefault(u => u.UserName == "erynrice@aoll.com");
            if (c31 == null)
            {
                c31 = new Customer();
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
                var result = UserManager.Create(c31, "ricearoni");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "erynrice@aoll.com");
            }

            AppUser c32 = db.Users.FirstOrDefault(u => u.UserName == "jorge@noclue.com");
            if (c32 == null)
            {
                c32 = new Customer();
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
                var result = UserManager.Create(c32, "jrod2017");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "jorge@noclue.com");
            }

            AppUser c33 = db.Users.FirstOrDefault(u => u.UserName == "mrrogers@lovelyday.com");
            if (c33 == null)
            {
                c33 = new Customer();
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
                var result = UserManager.Create(c33, "rogerthat");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "mrrogers@lovelyday.com");
            }

            AppUser c34 = db.Users.FirstOrDefault(u => u.UserName == "stjean@athome.com");
            if (c34 == null)
            {
                c34 = new Customer();
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
                var result = UserManager.Create(c34, "bunnyhop");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "stjean@athome.com");
            }

            AppUser c35 = db.Users.FirstOrDefault(u => u.UserName == "saunders@pen.com");
            if (c35 == null)
            {
                c35 = new Customer();
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
                var result = UserManager.Create(c35, "penguin12");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "saunders@pen.com");
            }

            AppUser c36 = db.Users.FirstOrDefault(u => u.UserName == "willsheff@email.com");
            if (c36 == null)
            {
                c36 = new Customer();
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
                var result = UserManager.Create(c36, "alaskaboy");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "willsheff@email.com");
            }

            AppUser c37 = db.Users.FirstOrDefault(u => u.UserName == "sheffiled@gogle.com");
            if (c37 == null)
            {
                c37 = new Customer();
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
                var result = UserManager.Create(c37, "martin1234");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "sheffiled@gogle.com");
            }

            AppUser c38 = db.Users.FirstOrDefault(u => u.UserName == "johnsmith187@aoll.com");
            if (c38 == null)
            {
                c38 = new Customer();
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
                var result = UserManager.Create(c38, "smitty444");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "johnsmith187@aoll.com");
            }

            AppUser c39 = db.Users.FirstOrDefault(u => u.UserName == "dustroud@mail.com");
            if (c39 == null)
            {
                c39 = new Customer();
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
                var result = UserManager.Create(c39, "dustydusty");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "dustroud@mail.com");
            }

            AppUser c40 = db.Users.FirstOrDefault(u => u.UserName == "estuart@anchor.net");
            if (c40 == null)
            {
                c40 = new Customer();
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
                var result = UserManager.Create(c40, "stewball");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "estuart@anchor.net");
            }

            AppUser c41 = db.Users.FirstOrDefault(u => u.UserName == "peterstump@noclue.com");
            if (c41 == null)
            {
                c41 = new Customer();
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
                var result = UserManager.Create(c41, "slowwind");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "peterstump@noclue.com");
            }

            AppUser c42 = db.Users.FirstOrDefault(u => u.UserName == "jtanner@mustang.net");
            if (c42 == null)
            {
                c42 = new Customer();
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
                var result = UserManager.Create(c42, "tanner5454");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "jtanner@mustang.net");
            }

            AppUser c43 = db.Users.FirstOrDefault(u => u.UserName == "taylordjay@aoll.com");
            if (c43 == null)
            {
                c43 = new Customer();
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
                var result = UserManager.Create(c43, "allyrally");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "taylordjay@aoll.com");
            }

            AppUser c44 = db.Users.FirstOrDefault(u => u.UserName == "rtaylor@gogle.com");
            if (c44 == null)
            {
                c44 = new Customer();
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
                var result = UserManager.Create(c44, "taylorbaylor");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "rtaylor@gogle.com");
            }

            AppUser c45 = db.Users.FirstOrDefault(u => u.UserName == "teefrank@noclue.com");
            if (c45 == null)
            {
                c45 = new Customer();
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
                var result = UserManager.Create(c45, "teeoff22");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "teefrank@noclue.com");
            }

            AppUser c46 = db.Users.FirstOrDefault(u => u.UserName == "ctucker@alphabet.co.uk");
            if (c46 == null)
            {
                c46 = new Customer();
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
                var result = UserManager.Create(c46, "tucksack1");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "ctucker@alphabet.co.uk");
            }

            AppUser c47 = db.Users.FirstOrDefault(u => u.UserName == "avelasco@yoho.com");
            if (c47 == null)
            {
                c47 = new Customer();
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
                var result = UserManager.Create(c47, "meow88");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "avelasco@yoho.com");
            }

            AppUser c48 = db.Users.FirstOrDefault(u => u.UserName == "vinovino@grapes.com");
            if (c48 == null)
            {
                c48 = new Customer();
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
                var result = UserManager.Create(c48, "vinovino");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "vinovino@grapes.com");
            }

            AppUser c49 = db.Users.FirstOrDefault(u => u.UserName == "westj@pioneer.net");
            if (c49 == null)
            {
                c49 = new Customer();
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
                var result = UserManager.Create(c49, "gowest");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "westj@pioneer.net");
            }

            AppUser c50 = db.Users.FirstOrDefault(u => u.UserName == "winner@hootmail.com");
            if (c50 == null)
            {
                c50 = new Customer();
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
                var result = UserManager.Create(c50, "louielouie");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "winner@hootmail.com");
            }

            AppUser c51 = db.Users.FirstOrDefault(u => u.UserName == "rwood@voyager.net");
            if (c51 == null)
            {
                c51 = new Customer();
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
                var result = UserManager.Create(c51, "woodyman1");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "rwood@voyager.net");
            }

        }
    }
}
