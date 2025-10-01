using AntiTail.API.Contracts;
using AntiTail.API.Contracts.Subjects;
using AntiTail.Domain.Interfaces.Subject;
using Microsoft.AspNetCore.Mvc;

namespace AntiTail.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectsController(ISubjectService subjectService) : ControllerBase
    {
        private readonly ISubjectService _subjectService = subjectService;

        [HttpGet]
        public async Task<ActionResult<List<SubjectResponse>>> GetAllSubjects()
        {
            var subjectEntities = await _subjectService.GetAllSubjects();

            if (subjectEntities.Count == 0)
            {
                return NotFound(new { message = "Subjects are not found" });
            }

            List<SubjectResponse> subjects = [.. subjectEntities.Select(
                s => new SubjectResponse(s.Id, s.UserId, s.Title))];

            return Ok(subjects);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<SubjectResponse>> GetSubjectById(long id)
        {
            var subject = await _subjectService.GetSubjectById(id);

            if (subject == null)
            {
                return NotFound("Subject is not found");
            }

            return Ok(new SubjectResponse(subject.Id, subject.UserId, subject.Title));
        }
    }
}
