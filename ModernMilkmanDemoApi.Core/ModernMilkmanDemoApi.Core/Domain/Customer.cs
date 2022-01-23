using ModernMilkmanDemoApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernMilkmanDemoApi.Core.Domain
{
    public class Customer : IBaseDomain
    {
        public Customer()
        {
            Active = true;
            CreatedUtc = DateTime.UtcNow;
            Address = new List<Address>();
        }

        public long Id { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime? UpdatedUtc { get; set; }
        public string Title { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public bool Active { get; set; }

        public static Customer FromModel(CustomerModel model)
        {
            var addresses = new List<Address>();

            model.Addresses.ToList()
                .ForEach(address => addresses.Add(Domain.Address.FromModel(address)));

            return new Customer
            {
                Title = model.Title,
                Forename = model.Forename,
                Surname = model.Surename,
                EmailAddress = model.EmailAddress,
                MobileNumber = model.MobileNumber,
                Address = addresses
            };
        }
    }
}
