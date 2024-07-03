using GameZone.Models;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Areas.Admin.Models
{
    public class OwnerViewModel
    {
        public string Name { get; set; } = string.Empty!;
        public string Phone { get; set; } = string.Empty!;
        public string Email { get; set; } = string.Empty!;
        public string Passsword { get; set; } = string.Empty!;
        public Rest? Rest { get; set; }
        [Display(Name = "Rest")]
        public int RestId { get; set; }
    }
}
