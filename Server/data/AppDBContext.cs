using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // call base version of this method, else get an error
            base.OnModelCreating(modelBuilder);

            Category[] categoriesToSeed = new Category[3];

            for (int i = 1; i < 4; i++)
            {
                categoriesToSeed[i - 1] = new Category
                {
                    CategoryId = i,
                    ThumbnailImgPath = "uploads.placeholder.jpg",
                    Name = $"Category {i}",
                    Description = $"description of category {i}"
                };
            }
            modelBuilder.Entity<Category>().HasData(categoriesToSeed);
        }
    }
}
