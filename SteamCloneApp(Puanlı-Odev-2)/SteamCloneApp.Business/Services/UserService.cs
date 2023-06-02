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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddAsync(User user) => await _userRepository.AddAsync(user);

        public async Task<User> GetUserByNickNameAsync(string nickName) => await _userRepository.GetAsync(p => p.NickName.Equals(nickName));
    }
}
