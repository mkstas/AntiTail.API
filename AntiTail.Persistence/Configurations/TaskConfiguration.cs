using AntiTail.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AntiTail.Persistence.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder
                .ToTable("tasks")
                .HasKey(t => t.Id);

            builder
                .HasOne(t => t.Subject)
                .WithMany(s => s.Tasks)
                .HasForeignKey(t => t.SubjectId);

            builder
                .HasMany(t => t.Subtasks)
                .WithOne(s => s.Task)
                .HasForeignKey(s => s.TaskId);

            builder
                .Property(t => t.Id)
                .HasColumnName("id");

            builder
                .Property(t => t.SubjectId)
                .IsRequired()
                .HasColumnName("subject_id");

            builder
                .Property(t => t.Title)
                .HasMaxLength(128)
                .HasColumnName("title");

            builder
                .Property(t => t.Description)
                .HasMaxLength(256)
                .HasDefaultValue(null)
                .HasColumnName("description");

            builder
                .Property(t => t.Status)
                .HasDefaultValue(Status.Pending)
                .HasConversion<string>()
                .HasColumnName("status");

            builder
                .Property(t => t.Mark)
                .HasConversion<string>()
                .HasDefaultValue(null)
                .HasColumnName("mark");
        }
    }
}
