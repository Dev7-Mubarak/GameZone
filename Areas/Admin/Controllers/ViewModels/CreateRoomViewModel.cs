using GameZone.Models;

namespace GameZone.Areas.Admin.Controllers.ViewModels
{
    public class CreateRoomViewModel
    {
        public Room room { get; set; }
        public Rest? rest { get; set; }
    }
}
