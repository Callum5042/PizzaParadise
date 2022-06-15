using Microsoft.EntityFrameworkCore;
using PizzaParadise.Entities.Models;

namespace PizzaParadise.Entities
{
    public class PizzaParadiseContext : DbContext
    {
        public PizzaParadiseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PizzaParadiseContext).Assembly);

            // Seed product categories
            var productCategoriesData = new List<ProductCategory>
            {
                new ProductCategory("Starters") { Id = 1 },
                new ProductCategory("Pizza") { Id = 2 },
                new ProductCategory("Sides") { Id = 3 },
                new ProductCategory("Drinks") { Id = 4 },
                new ProductCategory("Desserts") { Id = 5 }
            };

            modelBuilder.Entity<ProductCategory>().HasData(productCategoriesData);
        }

        public DbSet<User> Users => Set<User>();

        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();

        public DbSet<Product> Products => Set<Product>();
    }
}
