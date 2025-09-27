namespace AntiTail.Domain.Models
{
    public class SubjectEntity(long userId, string title)
    {
        public long Id { get; set; }

        public long UserId { get; set; } = userId;

        public string Title { get; set; } = title;

        public UserEntity? User { get; set; }

        public List<TaskEntity> Tasks { get; set; } = [];
    }
}
