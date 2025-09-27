namespace AntiTail.Domain.Models
{
    public class UserEntity(string login)
    {
        public long Id { get; set; }

        public string Login { get; set; } = login;

        public List<SubjectEntity> Subjects { get; set; } = [];
    }
}
