using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team_5_Project.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Team_5_Project.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        //Constructor that invokes the base constructor
        public AppDbContext() : base("MyDBConnection", throwIfV1Schema: false) { }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        //Create the db set
        public DbSet<TwoAirport> twoAirporSets { get; set; }
        public DbSet<RevenueVM> RevenueVms { get; set; }
        public DbSet<ReportTypes> ReportType { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Crew> Crews { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Day> Days { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightNumber> FlightNumbers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<SeatType> SeatType { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<CustomerSearchViewModel> csvms { get; set; }
        //NOTE: This is a dbSet that you need to make roles work
        public DbSet<AppRole> AppRoles { get; set; }

        public System.Data.Entity.DbSet<Team_5_Project.Models.MailModel> MailModels { get; set; }

        //public System.Data.Entity.DbSet<Team_5_Project.Models.AppUser> AppUsers { get; set; }
    }
}