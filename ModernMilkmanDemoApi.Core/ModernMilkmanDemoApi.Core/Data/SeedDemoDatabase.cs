using ModernMilkmanDemoApi.Core.Domain;
using System;
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
                MobileNumber = "07787877",
                Active = true,
            };

            var customer2 = new Customer
            {
                CreatedUtc = DateTime.UtcNow,
                Title = "Mr",
                Forename = "Luke",
                Surname = "Skywalker",
                EmailAddress = "luke@yavin4.com",
                MobileNumber = "07787878",
                Active = false,
            };

            var address1 = new Address
            {
                CreatedUtc = DateTime.UtcNow,
                AddressLine1 = "Cloud City",
                Town = "Bespin",
                Country = "Bespin",
                PostCode = "BB1 222",
                Customer = customer1,
                PrimaryAddress = true,
            };

            var address2 = new Address
            {
                CreatedUtc = DateTime.UtcNow,
                AddressLine1 = "Rebel Base",
                Town = "Yavin",
                Country = "4",
                PostCode = "BB8 222",
                Customer = customer2,
            };

            var address3 = new Address
            {
                CreatedUtc = DateTime.UtcNow,
                AddressLine1 = "Tatooine",
                Town = "Moss Espa",
                Country = "Tatooine",
                PostCode = "BB8 22X",
                Customer = customer1,
                PrimaryAddress = false,
            };


            context.Customers.Add(customer1);
            context.Addresses.Add(address1);
            context.Customers.Add(customer2);
            context.Addresses.Add(address2);
            context.Addresses.Add(address3);

            context.SaveChanges();

        }
    }
}
