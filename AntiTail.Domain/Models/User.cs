using System.Numerics;

namespace AntiTail.Domain.Models
{
    public class User(string userName)
    {
        public BigInteger Id { get; set; }

        public string UserName { get; set; } = userName;

        public List<Subject> Subjects { get; set; } = [];
    }
}
