using Microsoft.EntityFrameworkCore;
using MiniTurboAzAPI.Models;

namespace MiniTurboAzAPI.DbContexts
{
    public class MiniTurboAzContext : DbContext
    {
        public MiniTurboAzContext(DbContextOptions<MiniTurboAzContext> options)
     : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Image> Images { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Author)
                .WithMany(a => a.Products)
                .HasForeignKey(p => p.AuthorId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<Image>()
              .HasOne(i => i.Product)
              .WithMany(p => p.Images)
              .HasForeignKey(i => i.ProductId);

        }
    }


}
