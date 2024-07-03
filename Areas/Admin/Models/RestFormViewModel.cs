using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Areas.Admin.Models
{
    public class RestFormViewModel
    {
        [MaxLength(length: 250)]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Devices You Have")]
        public List<int> SelectedDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = new List<SelectListItem>();
        [MaxLength(length: 2500)]
        public string Descraption { get; set; } = string.Empty;
        [MaxLength(length: 2500)]
        public string Address { get; set; } = string.Empty;
    }
}
