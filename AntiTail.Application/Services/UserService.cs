using AntiTail.Domain.Interfaces;
using AntiTail.Domain.Models;

namespace AntiTail.Application.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<List<UserEntity>> GetUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<UserEntity?> GetUserById(long id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<UserEntity?> GetUserByLogin(string login)
        {
            return await _userRepository.GetByLogin(login);
        }

        public async Task<UserEntity?> CreateUser(string login)
        {
            return await _userRepository.Create(login);
        }

        public async Task<UserEntity?> UpdateUser(long id, string login)
        {
            return await _userRepository.Update(id, login);
        }

        public async Task<bool> DeleteUser(long id)
        {
            return await _userRepository.Delete(id);
        }
    }
}
