using AntiTail.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AntiTail.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .HasMany(u => u.Subjects)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);
        }
    }
}
