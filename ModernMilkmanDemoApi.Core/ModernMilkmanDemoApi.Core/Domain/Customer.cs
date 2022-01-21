using System;
using System.Collections.Generic;

namespace ModernMilkmanDemoApi.Core.Domain
{
    public class Customer : IBaseDomain
    {
        public Customer()
        {
            Active = true;
            Address = new List<Address>();
        }

        public long Id { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime? UpdatedUtc { get; set; }
        public string Title { get; set; }
        public string Forename { get;set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public bool Active { get; set; }    
    }
}
