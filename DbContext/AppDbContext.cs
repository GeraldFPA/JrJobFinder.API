using JrJobFinder.Models;
using Microsoft.EntityFrameworkCore;

namespace JrJobFinder.DA
{
    public class AppDbContext : DbContext
    {
        public DbSet<JobOffer> JobOffers => Set<JobOffer>();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<JobOffer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Company).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PostedDate).IsRequired();
                entity.Property(e => e.experienceLevel).HasMaxLength(50);
                entity.Property(e => e.technologies).HasMaxLength(200);
                entity.Property(e => e.sourceUrl).HasMaxLength(300);
            });
        }

    }
}