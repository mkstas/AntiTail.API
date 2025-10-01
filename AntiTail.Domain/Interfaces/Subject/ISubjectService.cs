using AntiTail.Domain.Models;

namespace AntiTail.Domain.Interfaces.Subject
{
    public interface ISubjectService
    {
        Task<List<SubjectEntity>> GetAllSubjects();

        Task<SubjectEntity?> GetSubjectById(long id);

        Task<SubjectEntity?> CreateSubject(long userId, string title);

        Task<SubjectEntity?> UpdateSubject(long id, string title);

        Task<bool> Delete(long id);
    }
}
