using AutoMapper;
using SteamCloneApp.Business.Dtos.Requests;
using SteamCloneApp.Business.Dtos.Responses;
using SteamCloneApp.Entities.Entities;
using System.Text;

namespace SteamCloneApp.Business.Services
{
    public class AuthService : IAuthService
    {      
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public AuthService(IUserService userService, IMapper mapper, IRoleService roleService)
        {
            _userService = userService;
            _mapper = mapper;
            _roleService = roleService;
        }

        public void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = Convert.ToBase64String(hmac.Key);
            passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        public async Task<UserResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userService.GetUserByNickNameAsync(loginRequest.NickName);
            var errorMessage = "Kullanıcı adı ya da şifre hatalı.\nLütfen tekrar deneyin.";
            if (user == null)
            {
                throw new ArgumentException(errorMessage);
            }
            if (!VerifyPasswordHash(loginRequest.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new ArgumentException(errorMessage);
            }
            return _mapper.Map<UserResponse>(user);
        }

        public bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(Convert.FromBase64String(passwordSalt));

            var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));

            return passwordHash.Equals(computedHash);
        }

        public async Task RegisterAsync(RegisterRequest registerRequest)
        {
            CreatePasswordHash(registerRequest.Password, out string passwordHash, out string passwordSalt);

            var role = await _roleService.GetRoleById(2);

            var user = new User
            {
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Email = registerRequest.Email,
                NickName = registerRequest.NickName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Roles = new List<Role>() { role }
            };
            await _userService.AddAsync(user);
        }
    }
}
