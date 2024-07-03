namespace GameZone.Models
{
    public class GameDevice
    {
        public int GameId { get; set; }
        public virtual Game Game { get; set; } = default!;
        public int DeviceId { get; set; }
        public virtual Device Device { get; set; } = default!;
    }
}
