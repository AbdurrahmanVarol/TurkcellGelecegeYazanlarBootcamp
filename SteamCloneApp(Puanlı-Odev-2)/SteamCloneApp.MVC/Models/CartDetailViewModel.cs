using SteamCloneApp.Business.Dtos.Responses;

namespace SteamCloneApp.MVC.Models
{
    public class CartDetailViewModel
    {
        public IEnumerable<GameCartResponse> Games{ get; set; }
        public bool IsAuthenticated { get; set; }

    }
}
