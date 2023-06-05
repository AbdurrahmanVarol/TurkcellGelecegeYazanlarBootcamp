using SteamCloneApp.Business.Dtos.Requests;
using SteamCloneApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Services
{
    public interface IUserService
    {
        Task<User> GetUserByNickNameAsync(string nickName);
        Task AddAsync(User user);
        Task AddGameToUser(PurchaseGameRequest purchaseGameRequest);
    }
}
