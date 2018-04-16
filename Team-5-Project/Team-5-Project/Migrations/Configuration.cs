namespace Team_5_Project.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Team_5_Project.DAL.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Team_5_Project.DAL.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            SeedIdentity SeedAdmin = new SeedIdentity();
            SeedAdmin.AddAdmin(context);



            //call methods to add customers and employees
            AddSeedData seedCustomers = new AddSeedData();
            seedCustomers.SeedCustomerData(context);
            //seedCustomers.two(context);
            //seedCustomers.three(context);


            MakeDecemberFlights seedFlights = new MakeDecemberFlights();
            seedFlights.SeedAllFlights(context);
            //var rows = from o in context.Seats
            //           select o;
            //foreach (var row in rows)
            //{
            //    context.Seats.Remove(row);
            //}
            //context.SaveChanges();

            //var rows2 = from o in context.Flights
            //           select o;
            //foreach (var row in rows2)
            //{
            //    context.Flights.Remove(row);
            //}
            //context.SaveChanges();


            //AddSeedData seedEmployees = new AddSeedData();
            //seedEmployees.SeedEmployeeData(context);

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.
        }
    }
}
