using System.Numerics;

namespace AntiTail.Domain.Models
{
    public enum Status
    {
        Pending,
        Succeeded,
    }

    public class Subtask(BigInteger taskId, string title, string? description = null)
    {
        public BigInteger Id { get; set; }

        public BigInteger TaskId { get; set; } = taskId;

        public string Title { get; set; } = title;

        public string? Description { get; set; } = description;

        public Status Status { get; set; } = Status.Pending;

        public Task? Task { get; set; }
    }
}
