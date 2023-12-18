using Kanini.InventoryManagementSystem.API.Interfaces;
using Kanini.InventoryManagementSystem.API.Models.DataTransferObjects;
using Kanini.InventoryManagementSystem.API.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace Kanini.InventoryManagementSystem.API.Services
{
    public class UserService : IManageUserActions
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerate _tokenGenerate;

        public UserService(IUserRepository userRepository, ITokenGenerate tokenGenerate)
        {
            _userRepository = userRepository;
            _tokenGenerate = tokenGenerate;
        }
        public async Task<UserForResponseDto> Login(UserForLoginDto user)
        {
            UserForResponseDto userLoginResponse = null;
            var dbUser = await _userRepository.GetUser(user.Username);
            if (dbUser != null)
            {
                var hmac = new HMACSHA512(dbUser.PasswordKey);
                var userPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                for (int i = 0; i < userPassword.Length; i++)
                {
                    if (userPassword[i] != dbUser.PasswordHash[i])
                        return null;
                }
                userLoginResponse = new UserForResponseDto
                {
                    Username = dbUser.Username,
                    Role = dbUser.Role,
                    Token = _tokenGenerate.GenerateToken(dbUser.Username, dbUser.Role)
                };
            }
            return userLoginResponse;
        }

        public async Task<UserForResponseDto> Register(UserForRegistrationDto user)
        {
            UserForCreationDto userForCreationDto = new UserForCreationDto();
            var hmac = new HMACSHA512();
            userForCreationDto.Username = user.Username;
            userForCreationDto.Role = user.Role;
            userForCreationDto.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            userForCreationDto.PasswordKey = hmac.Key;
            bool userCreated = await _userRepository.CreateUser(userForCreationDto);

            if (userCreated)
            {
                UserForResponseDto userRegisterResponse = new UserForResponseDto
                {
                    Username = user.Username,
                    Role = user.Role,
                    Token = _tokenGenerate.GenerateToken(user.Username, user.Role)
                };

                return userRegisterResponse;
            }
            else
            {
                return null;
            }
        }
    }
}
