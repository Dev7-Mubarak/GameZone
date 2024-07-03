using GameZone.Attrbuites;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models.ViewModels
{
    public class EditGameFormViewModel : GameFormViewModel
    {
        public int Id { get; set; }
        public string? currentCover { get; set; }
        [AllowedExtensions(FileSetings.AllowedExtenstions)]
        [MaxFileSize(FileSetings.MaxFileSizeInBytes)]
        public IFormFile? Cover { get; set; } = default!;
    }
}
