using System.Numerics;

namespace AntiTail.Domain.Models
{
    public class UserEntity(string userName)
    {
        public BigInteger Id { get; set; }

        public string UserName { get; set; } = userName;

        public List<SubjectEntity> Subjects { get; set; } = [];
    }
}
