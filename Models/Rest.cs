
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{

    public class Rest
    {
        public int Id { get; set; }
        [MaxLength(length: 250)]
        [Display(Name = "Rest Name")]
        public string Name { get; set; } = string.Empty;
        public string Dscraption { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Addrees { get; set; } = null!;
        public string? OwnerId { get; set; } = default!;
        public virtual AppUser? Owner { get; set; } = default!;
        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
        public virtual ICollection<RestDivce> Devices { get; set; } = new List<RestDivce>();
    }
}
