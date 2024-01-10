using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEBSITESTEFANKEZDI.Models;

namespace WEBSITESTEFANKEZDI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasMany(a => a.Images)
                .WithOne(ai => ai.Article)
                .HasForeignKey(ai => ai.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleImage> ArticleImages { get; set; }
        public DbSet<Account> Accounts { get; set; }
        
    }
}