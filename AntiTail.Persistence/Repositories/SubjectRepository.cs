using AntiTail.Domain.Interfaces.Subject;
using AntiTail.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AntiTail.Persistence.Repositories
{
    public class SubjectRepository(AntiTailDbContext dbContext) : ISubjectRepository
    {
        private readonly AntiTailDbContext _dbContext = dbContext;

        public async Task<List<SubjectEntity>> GetAll()
        {
            return await _dbContext.Subjects
                .ToListAsync();
        }

        public async Task<SubjectEntity?> GetById(long id)
        {
            return await _dbContext.Subjects
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<SubjectEntity?> Create(long userId, string title)
        {
            var subject = new SubjectEntity(userId, title);

            await _dbContext.AddAsync(subject);
            await _dbContext.SaveChangesAsync();

            return subject;
        }

        public async Task<SubjectEntity?> Update(long id, string title)
        {
            var updatedRows = await _dbContext.Subjects
                .Where(s => s.Id == id)
                .ExecuteUpdateAsync(
                    s => s
                    .SetProperty(s => s.Title, title));

            if (updatedRows == 0)
            {
                return null;
            }

            return await _dbContext.Subjects
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> Delete(long id)
        {
            var deletedRows = await _dbContext.Subjects
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync();

            return deletedRows > 0;
        }
    }
}
