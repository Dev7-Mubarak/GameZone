using GameZone.Attrbuites;
using GameZone.Models;

namespace GameZone.Areas.Admin.Models
{
    public class EditRestFormViewModel : RestFormViewModel
    {
        public int Id { get; set; }
        public string? currentCover { get; set; }
        [AllowedExtensions(FileSetings.AllowedExtenstions)]
        [MaxFileSize(FileSetings.MaxFileSizeInBytes)]
        public IFormFile? Image { get; set; } = default!;
    }
}
