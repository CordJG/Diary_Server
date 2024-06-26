using Diary_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Diary_Server.Contexts
{
    public class DiaryContext : DbContext
    {
        public DiaryContext(DbContextOptions<DiaryContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Diary> Diaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Diaries)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);
        }
    }
}
