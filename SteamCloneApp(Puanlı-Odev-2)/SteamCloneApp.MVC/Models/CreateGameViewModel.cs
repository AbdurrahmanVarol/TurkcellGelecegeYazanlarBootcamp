using SteamCloneApp.Business.Dtos.Responses;

namespace SteamCloneApp.MVC.Models
{
    public class CreateGameViewModel
    {
        public IEnumerable<DeveloperResponse> Developers { get; set; }
        public IEnumerable<GenreResponse> Genres { get; set; }
        public IEnumerable<PublisherResponse> Publishers { get; set; }
    }
}
