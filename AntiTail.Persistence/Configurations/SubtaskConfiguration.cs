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
                .HasKey(s => s.Id);

            builder
                .HasOne(s => s.Task)
                .WithMany(t => t.Subtasks)
                .HasForeignKey(s => s.TaskId);
        }
    }
}
