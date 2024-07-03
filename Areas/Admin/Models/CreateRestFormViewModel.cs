using GameZone.Attrbuites;
using GameZone.Models;

namespace GameZone.Areas.Admin.Models
{
    public class CreateRestFormViewModel : RestFormViewModel
    {
        [AllowedExtensions(FileSetings.AllowedExtenstions)]
        [MaxFileSize(FileSetings.MaxFileSizeInBytes)]
        public IFormFile Image { get; set; } = default!;
    }
}
