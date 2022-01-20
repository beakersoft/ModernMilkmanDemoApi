using System;

namespace ModernMilkmanDemoApi.Core.Domain
{
    public class Customer : IBaseDomain
    {
        public long Id { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime? UpdatedUtc { get; set; }
        public string Title { get; set; }
        public string Forename { get;set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
    }
}
