using SteamCloneApp.Business.Dtos.Responses;
using SteamCloneApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreResponse>> GetAllAsync();
        Task<IEnumerable<Genre>> GetGenresByIdAsync(List<int> ids);
    }
}
