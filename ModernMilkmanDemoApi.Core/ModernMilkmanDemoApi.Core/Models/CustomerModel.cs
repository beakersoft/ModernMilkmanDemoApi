using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModernMilkmanDemoApi.Core.Models
{
    public class CustomerModel
    {
        [Required]
        public string Title { get; set; }

        [Required, StringLength(50)]
        public string Forename { get; set; }

        [Required, StringLength(50)]
        public string Surename { get; set; }

        [Required, EmailAddress, StringLength(75)]
        public string EmailAddress { get; set; }

        [Required, Phone, StringLength(15)]
        public string MobileNumber { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public IList<AddressModel> Addresses { get; set; }
    }
}
