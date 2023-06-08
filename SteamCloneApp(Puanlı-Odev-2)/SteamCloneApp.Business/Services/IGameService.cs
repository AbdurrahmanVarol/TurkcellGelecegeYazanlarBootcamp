using SteamCloneApp.Business.Dtos.Requests;
using SteamCloneApp.Business.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Services
{
    public interface IGameService
    {
        Task AddAsync(CreateGameRequest request);
        Task<IEnumerable<GameDisplayResponse>> GetAllAsync();
        Task<IEnumerable<GameDisplayResponse>> GetGamesByUserIdAsync(Guid userId);
        Task<GameDisplayResponse> GetGameByIdAsync(Guid id);
        Task<GameCartResponse> GetGameByIdForCartAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(UpdateGameRequest updateGameRequest);
    }
}
