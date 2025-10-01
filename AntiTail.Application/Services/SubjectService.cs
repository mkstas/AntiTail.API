using AntiTail.Domain.Interfaces.Subject;
using AntiTail.Domain.Models;

namespace AntiTail.Application.Services
{
    public class SubjectService(ISubjectRepository subjectRepository) : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository = subjectRepository;

        public async Task<List<SubjectEntity>> GetAllSubjects()
        {
            return await _subjectRepository.GetAll();
        }

        public async Task<SubjectEntity?> GetSubjectById(long id)
        {
            return await _subjectRepository.GetById(id);
        }

        public async Task<SubjectEntity?> CreateSubject(long userId, string title)
        {
            return await _subjectRepository.Create(userId, title);
        }

        public async Task<SubjectEntity?> UpdateSubject(long id, string title)
        {
            return await _subjectRepository.Update(id, title);
        }

        public async Task<bool> Delete(long id)
        {
            return await _subjectRepository.Delete(id);
        }
    }
}
