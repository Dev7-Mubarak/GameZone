using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Device : BaseEntity
    {
        [MaxLength(length: 50)]
        public string Icon { get; set; } = string.Empty;
        public virtual ICollection<RestDivce> Devices { get; set; } = new List<RestDivce>();

    }
}
