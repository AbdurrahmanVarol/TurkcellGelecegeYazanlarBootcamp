using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Dtos.Requests
{
    public class PurchaseGameRequest
    {
        public Guid UserId{ get; set; }
        public List<Guid> GameIds { get; set; }
    }
}
