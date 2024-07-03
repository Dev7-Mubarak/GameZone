namespace GameZone.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UsreName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
