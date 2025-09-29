using AntiTail.Domain.Models;

namespace AntiTail.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserEntity>> GetAll();
        Task<UserEntity?> GetById(long id);
        Task<UserEntity?> GetByLogin(string login);
        Task<UserEntity?> Create(string login);
        Task<UserEntity?> Update(long id, string login);
        Task<bool> Delete(long id);
    }
}
