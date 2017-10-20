using GBaldera.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GBaldera.Data.Ef
{
    public class StorageContext : DbContext
    {
        public StorageContext(DbContextOptions<StorageContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(256).IsRequired(false);
                entity.Property(e => e.FileName).HasMaxLength(256);
                entity.ToTable("Projects");
            });
        }
    }
}