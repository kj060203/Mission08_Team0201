using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0201.Models
{
    public class Mission08DbContext : DbContext
    {
        public Mission08DbContext(DbContextOptions<Mission08DbContext> options)
            : base(options) // This ensures proper configuration of the DbContext
        { }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Categories
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { CategoryId = 1, CategoryName = "Home" },
                new CategoryModel { CategoryId = 2, CategoryName = "School" },
                new CategoryModel { CategoryId = 3, CategoryName = "Work" },
                new CategoryModel { CategoryId = 4, CategoryName = "Church" }
            );
        }
    }
}
