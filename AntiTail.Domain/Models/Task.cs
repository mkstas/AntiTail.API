using System.Numerics;

namespace AntiTail.Domain.Models
{
    public enum Grade
    {
        Unsatisfactory = 2,
        Satisfactorily = 3,
        Good = 4,
        Great = 5,
    }

    public class Task(BigInteger subjectId, string title, string? description = null)
    {
        public BigInteger Id { get; set; }

        public BigInteger SubjectId { get; set; } = subjectId;

        public string Title { get; set; } = title;

        public string? Description { get; set; } = description;

        public int? Grade { get; set; } = null;

        public Subject? Subject { get; set; }

        public List<Task> Tasks { get; set; } = [];
    }
}
