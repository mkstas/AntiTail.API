using AntiTail.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AntiTail.Persistence.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<SubjectEntity>
    {
        public void Configure(EntityTypeBuilder<SubjectEntity> builder)
        {
            builder
                .ToTable("subjects")
                .HasKey(s => s.Id);

            builder
                .HasOne(s => s.User)
                .WithMany(u => u.Subjects)
                .HasForeignKey(s => s.UserId);

            builder
                .HasMany(s => s.Tasks)
                .WithOne(t => t.Subject)
                .HasForeignKey(t => t.SubjectId);

            builder
                .Property(u => u.Id)
                .HasColumnName("id");

            builder
                .Property(s => s.UserId)
                .IsRequired()
                .HasColumnName("user_id");

            builder
                .Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("title");
        }
    }
}
