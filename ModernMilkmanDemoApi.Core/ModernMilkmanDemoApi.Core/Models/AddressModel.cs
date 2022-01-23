using System.ComponentModel.DataAnnotations;

namespace ModernMilkmanDemoApi.Core.Models
{
    public class AddressModel
    {
        [Required, StringLength(80)]
        public string AddressLine1 { get; set; }

        [StringLength(80)]
        public string AddressLine2 { get; set; }

        [Required, StringLength(50)]
        public string Town { get; set; }

        [StringLength(50)]
        public string County { get; set; }

        [Required, StringLength(10)]
        public string PostCode { get; set; }

        [Required]
        public bool PrimaryAddress { get; set; }
    }
}
