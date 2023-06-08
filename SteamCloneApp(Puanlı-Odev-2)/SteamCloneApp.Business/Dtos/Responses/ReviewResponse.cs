using SteamCloneApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Dtos.Responses
{
    public class ReviewResponse
    {
        public Guid Id { get; set; }
        public string Post { get; set; }
        public DateTime PostedAt { get; set; }
        public bool IsRecommend { get; set; }
        public Guid GameId { get; set; }
        public Guid UserId { get; set; }
        public string UserName{ get; set; }
    }
}
