using System.Numerics;

namespace AntiTail.Domain.Models
{
    public class Subject(BigInteger userId, string title)
    {
        public BigInteger Id { get; set; }

        public BigInteger UserId { get; set; } = userId;

        public string Title { get; set; } = title;

        public User? User { get; set; }

        public List<Task> Tasks { get; set; } = [];
    }
}
