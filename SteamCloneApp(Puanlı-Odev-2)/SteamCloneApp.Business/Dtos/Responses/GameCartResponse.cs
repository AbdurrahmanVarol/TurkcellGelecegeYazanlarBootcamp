using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Dtos.Responses
{
    public class GameCartResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string CoverUrl { get; set; }

    }
}
