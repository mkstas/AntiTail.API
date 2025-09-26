using AntiTail.Domain.Models;
using AntiTail.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AntiTail.Persistence
{
    public class AntiTailDbContext(DbContextOptions<AntiTailDbContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<SubjectEntity> Subjects { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }

        public DbSet<SubtaskEntity> Subtasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new SubtaskConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
