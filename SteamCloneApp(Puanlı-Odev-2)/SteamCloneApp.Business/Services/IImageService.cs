using SteamCloneApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Services
{
    public interface IImageService
    {
        Task<IEnumerable<string>> GetImageUrlsBtGameIdAsync(Guid gameId);
        Task AddRange(IEnumerable<string> images,Guid gameId);
        Task RemoveRange(IEnumerable<Image> images);
    }
}
