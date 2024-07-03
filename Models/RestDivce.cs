
namespace GameZone.Models
{
    public class RestDivce
    {
        public int RestId { get; set; }
        public virtual Rest? Rest { get; set; }
        public int DeviceId { get; set; }
        public virtual Device? Device { get; set; }
    } 
}
