using SteamCloneApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Dtos.Requests
{
    public class CreateGameRequest
    {        
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseAt { get; set; }
        public decimal Price { get; set; }
        public string IconUrl { get; set; }
        public string CoverUrl { get; set; }
        public int PublishedById { get; set; }
        public int DevelopedById { get; set; }
        public List<int> Genres { get; set; } = new();
        public List<string> ImageUrls { get; set; } = new();
    }
}
