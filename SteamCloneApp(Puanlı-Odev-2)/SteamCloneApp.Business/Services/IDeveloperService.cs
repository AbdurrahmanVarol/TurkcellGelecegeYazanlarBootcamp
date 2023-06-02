using SteamCloneApp.Business.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Services
{
    public interface IDeveloperService
    {
        Task<IEnumerable<DeveloperResponse>> GetAllAsync();
    }
}
