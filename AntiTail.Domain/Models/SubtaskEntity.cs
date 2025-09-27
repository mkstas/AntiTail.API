namespace AntiTail.Domain.Models
{
    public class SubtaskEntity(long taskId, string title, string? description = null)
    {
        public long Id { get; set; }

        public long TaskId { get; set; } = taskId;

        public string Title { get; set; } = title;

        public string? Description { get; set; } = description;

        public Status Status { get; set; } = Status.Pending;

        public TaskEntity? Task { get; set; }
    }
}
