using AntiTail.Domain.Interfaces;
using AntiTail.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AntiTail.Persistence.Repositories
{
    public class UserRepository(AntiTailDbContext dbContext) : IUserRepository
    {
        private readonly AntiTailDbContext _dbContext = dbContext;

        public async Task<List<UserEntity>> GetAll()
        {
            return await _dbContext.Users
                .ToListAsync();
        }

        public async Task<UserEntity?> GetById(long id)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserEntity?> GetByLogin(string login)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task<UserEntity?> Create(string login)
        {
            var userIsExists = await _dbContext.Users
                .AnyAsync(u => u.Login == login);

            if (userIsExists)
            {
                return null;
            }

            var user = new UserEntity(login);

            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserEntity?> Update(long id, string login)
        {
            var updatedRows = await _dbContext.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(
                    u => u
                    .SetProperty(u => u.Login, login));

            if (updatedRows == 0)
            {
                return null;
            }

            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> Delete(long id)
        {
            var deletedRows = await _dbContext.Users
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();

            return deletedRows > 0;
        }
    }
}
