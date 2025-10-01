using AntiTail.Domain.Models;

namespace AntiTail.Domain.Interfaces.Subject
{
    public interface ISubjectRepository
    {
        Task<List<SubjectEntity>> GetAll();

        Task<SubjectEntity?> GetById(long id);

        Task<SubjectEntity?> Create(long userId, string title);

        Task<SubjectEntity?> Update(long id, string title);

        Task<bool> Delete(long id);
    }
}
