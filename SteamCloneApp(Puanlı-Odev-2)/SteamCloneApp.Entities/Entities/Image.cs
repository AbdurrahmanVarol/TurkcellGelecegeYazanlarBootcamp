using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Entities.Entities
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
