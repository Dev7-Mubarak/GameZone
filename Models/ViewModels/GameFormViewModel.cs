using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models.ViewModels
{
    public class GameFormViewModel
    {
        [MaxLength(length: 250)]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Catigory")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Catigories { get; set; } = new List<SelectListItem>();
        [Display(Name = "Supported Devices")]
        public List<int> SelectedDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = new List<SelectListItem>();
        [MaxLength(length: 2500)]
        public string Descraption { get; set; } = string.Empty;
    }
}
