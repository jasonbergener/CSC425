using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrders.Models;

namespace ServiceOrders.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            //Check for any existing customers.
            if (context.Customers.Any())
            {
                return; //The database was already seeded.
            }

            //Create two fictional customers to seed the database.
            var customers = new Customer[]
            {
                new Customer{FirstName="Freddy", LastName="Krueger", Phone="555-1234", Email="freddy@nightmare.com", MailingAddress="123 Elm Street Staten Island NY 10310"},
                new Customer{FirstName="Jason", LastName="Voorhees", Phone="555-5678", Email="jason@itsfriday.com", MailingAddress="6724 Camp Crystal Road Starke FL 32091"}
            };
            //Add the customers to the database.
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();//Commit changes to the database.

            //Create three service orders to seed the database.
            var services = new ServiceOrder[]
            {
                new ServiceOrder{CustomerID=1, Status="Closed", Opened=DateTime.Parse("2017-12-10"), Updated=DateTime.Parse("2017-12-11"), PhysicalAddress="123 Elm Street Staten Island NY 10310", Requested="Blade sharpening.", Notes="Sharpened blades."},
                new ServiceOrder{CustomerID=2, Status="Closed", Opened=DateTime.Parse("2017-10-13"), Updated=DateTime.Parse("2017-10-13"), PhysicalAddress="6724 Camp Crystal Road Starke FL 32091", Requested="Make scary movie.", Notes="Filmed the movie." },
                new ServiceOrder{CustomerID=1, Status="Open", Opened=DateTime.Parse("2017-12-23"), PhysicalAddress="123 Elm Street Staten Island NY 10310", Requested="Scare someone."}
            };
            //Add the service orders to the database.
            foreach (ServiceOrder s in services)
            {
                context.ServiceOrders.Add(s);
            }
            context.SaveChanges();//Commit changes to the database.
        }
    }
}
