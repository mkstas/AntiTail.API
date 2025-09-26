using System.Numerics;

namespace AntiTail.Domain.Models
{
    public class SubjectEntity(BigInteger userId, string title)
    {
        public BigInteger Id { get; set; }

        public BigInteger UserId { get; set; } = userId;

        public string Title { get; set; } = title;

        public UserEntity? User { get; set; }

        public List<TaskEntity> Tasks { get; set; } = [];
    }
}
