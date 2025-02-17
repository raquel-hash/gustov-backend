using backend.Interfaces;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            return await _userRepository.GetByUsernameAndPassword(username, password);
        }

        public async Task<User> Register(User user, string password)
        {
            if (await _userRepository.UsernameExists(user.Username))
                throw new ApplicationException("Usuario \"" + user.Username + "\" ya esta registrado");

            user.Password = password;
            await _userRepository.AddUser(user);
            return user;
        }
    }
}