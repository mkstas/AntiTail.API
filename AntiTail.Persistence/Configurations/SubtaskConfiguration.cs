using AntiTail.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AntiTail.Persistence.Configurations
{
    public class SubtaskConfiguration : IEntityTypeConfiguration<SubtaskEntity>
    {
        public void Configure(EntityTypeBuilder<SubtaskEntity> builder)
        {
            builder
                .ToTable("subtasks")
                .HasKey(s => s.Id);

            builder
                .HasOne(s => s.Task)
                .WithMany(t => t.Subtasks)
                .HasForeignKey(s => s.TaskId);

            builder
                .Property(s => s.Id)
                .HasColumnName("id");

            builder
                .Property(s => s.TaskId)
                .IsRequired()
                .HasColumnName("task_id");

            builder
                .Property(s => s.Title)
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
        }
    }
}
