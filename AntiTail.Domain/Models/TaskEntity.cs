namespace AntiTail.Domain.Models
{
    public enum Status
    {
        Pending,
        Succeeded,
    }

    public enum Mark
    {
        Unsatisfactory = 2,
        Satisfactorily = 3,
        Good = 4,
        Great = 5,
    }

    public class TaskEntity(long subjectId, string title, string? description = null)
    {
        public long Id { get; set; }

        public long SubjectId { get; set; } = subjectId;

        public string Title { get; set; } = title;

        public string? Description { get; set; } = description;

        public int? Mark { get; set; } = null;

        public Status Status { get; set; } = Status.Pending;

        public SubjectEntity? Subject { get; set; }

        public List<SubtaskEntity> Subtasks { get; set; } = [];
    }
}
