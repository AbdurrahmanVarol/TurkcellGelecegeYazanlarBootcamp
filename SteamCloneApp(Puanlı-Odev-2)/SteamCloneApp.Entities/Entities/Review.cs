using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Entities.Entities
{
    public class Review : IEntity
    {
        public Guid Id { get; set; }
        public string Post { get; set; }
        public DateTime PostedAt { get; set; }
        public bool IsRecommend { get; set; }

        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
