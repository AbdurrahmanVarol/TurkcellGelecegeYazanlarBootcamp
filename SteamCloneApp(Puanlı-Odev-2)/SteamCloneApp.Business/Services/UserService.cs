using SteamCloneApp.Business.Dtos.Requests;
using SteamCloneApp.DataAccess.Repositories;
using SteamCloneApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGameRepository _gameRepository;

        public UserService(IUserRepository userRepository, IGameRepository gameRepository)
        {
            _userRepository = userRepository;
            _gameRepository = gameRepository;
        }

        public async Task AddAsync(User user) => await _userRepository.AddAsync(user);

        public async Task<User> GetUserByNickNameAsync(string nickName) => await _userRepository.GetAsync(p => p.NickName.Equals(nickName));

        public async Task AddGameToUser(PurchaseGameRequest purchaseGameRequest)
        {
            var user = await _userRepository.GetAsync(p=>p.Id == purchaseGameRequest.UserId);
            if(user is null)
            {
                throw new Exception("asaaaa");
            }
            foreach (var gameId in purchaseGameRequest.GameIds)
            {
                var game = await _gameRepository.GetAsync(p=>p.Id ==  gameId);
                user.Games.Add(game);
            }
            await _userRepository.UpdateAsync(user);
        }
    }
}
