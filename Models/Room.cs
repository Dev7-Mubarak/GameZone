
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Room
    {
        public int Id { get; set; }
        [MaxLength(length: 250)]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Allowed Peple")]
        public byte? NumberOfPepleAllowed { get; set; }
        [Display(Name = "Price In Hour")]
        //public bool AvilibaltyStatus { get; set; }
        public double? PriceInHour { get; set; }
        public double? Discount { get; set; }
        public string Space { get; set; } = string.Empty!;
        public int RestId { get; set; }
        public virtual Rest? Rest { get; set; }
    }
}
