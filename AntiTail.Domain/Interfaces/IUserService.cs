using AntiTail.Domain.Models;

namespace AntiTail.Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<UserEntity>> GetUsers();
        Task<UserEntity?> GetUserById(long id);
        Task<UserEntity?> GetUserByLogin(string login);
        Task<UserEntity?> CreateUser(string login);
        Task<UserEntity?> UpdateUser(long id, string login);
        Task<bool> DeleteUser(long id);
    }
}
