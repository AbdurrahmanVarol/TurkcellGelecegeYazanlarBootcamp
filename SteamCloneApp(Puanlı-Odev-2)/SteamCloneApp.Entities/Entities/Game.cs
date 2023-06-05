using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Entities.Entities
{
    public class Game : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseAt { get; set; }
        public decimal Price { get; set; }
        public string IconUrl { get; set; }
        public string CoverUrl { get; set; }

        public int PublishedById { get; set; }
        public Publisher PublishedBy { get; set;}

        public int DevelopedById { get; set; }
        public Developer DevelopedBy { get;set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();

        public ICollection<User> Users { get; set; } = new List<User>();

        public ICollection<Image> Images{ get; set; } = new List<Image>();
    }
}
