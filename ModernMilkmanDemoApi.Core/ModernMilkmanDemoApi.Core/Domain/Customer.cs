using System;
using System.Collections.Generic;
using ModernMilkmanDemoApi.Core.Models;

namespace ModernMilkmanDemoApi.Core.Domain
{
    public class Customer : IBaseDomain
    {
        public Customer()
        {
            Active = true;
            CreatedUtc = DateTime.UtcNow;
        }

        public string Title { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public string MobileNumber { get; set; }

        public virtual ICollection<Address> Address { get; set; }

        public bool Active { get; set; }

        public long Id { get; set; }

        public DateTime CreatedUtc { get; set; }

        public DateTime? UpdatedUtc { get; set; }

        public static Customer FromModel(CustomerModel model)
        {
            return new Customer
            {
                Title = model.Title,
                Forename = model.Forename,
                Surname = model.Surename,
                EmailAddress = model.EmailAddress,
                MobileNumber = model.MobileNumber
            };
        }
    }
}