using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Game : BaseEntity
    {
        [MaxLength(length: 2500)]
        public string Descraption { get; set; } = string.Empty;
        [MaxLength(length: 2500)]
        public string Cover { get; set; } = string.Empty;
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; } = default!;
        public virtual ICollection<GameDevice> GameDevices { get; set; } = new List<GameDevice>();
    }
}
