using System;
using System.ComponentModel.DataAnnotations;

namespace ModernMilkmanDemoApi.Core.Domain
{
    public class Address : IBaseDomain
    {
        private const string DefaultCountry = "UK";

        public Address()
        {
            Country = DefaultCountry;
        }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Town { get; set; }

        public string County { get; set; }

        public string PostCode { get; set; }

        public string Country { get; set; }

        public bool PrimaryAddress { get; set; }

        [Required]
        public virtual Customer Customer { get; set; }

        public long Id { get; set; }

        public DateTime CreatedUtc { get; set; }

        public DateTime? UpdatedUtc { get; set; }
    }
}