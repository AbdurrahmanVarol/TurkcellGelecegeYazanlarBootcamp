namespace SteamCloneApp.MVC.Models
{
    public class NavbarViewModel
    {
        public int CartItemCount { get; set; }
        public bool IsAuthenticated{ get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
