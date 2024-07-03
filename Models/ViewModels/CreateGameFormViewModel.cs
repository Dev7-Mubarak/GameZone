using GameZone.Attrbuites;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace GameZone.Models.ViewModels
{
    public class CreateGameFormViewModel : GameFormViewModel
    {
      
        [AllowedExtensions(FileSetings.AllowedExtenstions)]
        [MaxFileSize(FileSetings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;

    }
}
