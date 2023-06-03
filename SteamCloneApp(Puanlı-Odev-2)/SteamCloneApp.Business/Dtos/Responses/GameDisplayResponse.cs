using SteamCloneApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Dtos.Responses
{
    public class GameDisplayResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseAt { get; set; }
        public decimal Price { get; set; }
        public string PublisherName { get; set; }
        public string DeveloperName { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Images { get; set; }
    }
}
