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
                .ToTable("users")
                .HasKey(u => u.Id);

            builder
                .HasMany(u => u.Subjects)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);

            builder
                .Property(u => u.Id)
                .HasColumnName("id");

            builder
                .HasIndex(u => u.Login)
                .IsUnique();

            builder
                .Property(u => u.Login)
                .IsRequired()
                .HasMaxLength(24)
                .HasColumnName("login");
        }
    }
}
