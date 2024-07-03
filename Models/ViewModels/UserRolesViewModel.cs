namespace GameZone.Models.ViewModels
{
    public class UserRolesViewModel
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
