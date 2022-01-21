using ModernMilkmanDemoApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernMilkmanDemoApi.Core.Data
{
    public static class SeedDemoDatabase
    {
        public static void Initialize(DemoContext context)
        {
            context.Database.EnsureCreated();

            if (context.Customers.Any())
                return;


            var customer1 = new Customer
            {
                CreatedUtc = DateTime.UtcNow,
                Title = "Mr",
                Forename = "Han",
                Surname = "Solo",
                EmailAddress = "han@bespin.com",
                MobileNumber = "07787877"
            };

            var address1 = new Address
            {
                CreatedUtc = DateTime.UtcNow,
                AddressLine1 = "Cloud City",
                Town = "Bespin",
                Country = "Bespin",
                PostCode = "BB1 222",
                Customer = customer1,
            };

            context.Customers.Add(customer1);
            context.Addresses.Add(address1);

            
            context.SaveChanges();

        }
    }
}
