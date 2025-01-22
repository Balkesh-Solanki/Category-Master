using Category_Master.Models;
using Microsoft.EntityFrameworkCore;

namespace Category_Master.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CategoryMst> Categories { get; set; }
        public DbSet<SubCategoryMst> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryMst>()
                .ToTable("CategoryMst")
                .HasKey(c => c.Id);

            modelBuilder.Entity<SubCategoryMst>()
                .ToTable("SubCategoryMst")
                .HasKey(sc => sc.Id);

            modelBuilder.Entity<SubCategoryMst>()
                .HasOne<CategoryMst>()
                .WithMany()
                .HasForeignKey(sc => sc.CategoryId);
        }
    }
}
